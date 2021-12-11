using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MidiControl.OptionsManagment;

namespace MidiControl
{
    partial class WebViewLoginTwitch : Form
    {
        private readonly System.ComponentModel.IContainer components = null;
        private WebServer server;
        private WebView2 webview;

        public WebViewLoginTwitch(OptionsManagment.Options options)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ConfFolder = Path.Combine(folder, "MIDIControl");
            CoreWebView2EnvironmentOptions optionsWebView = new CoreWebView2EnvironmentOptions();
            CoreWebView2Environment env = CoreWebView2Environment.CreateAsync("", ConfFolder, optionsWebView).GetAwaiter().GetResult();
            webview.EnsureCoreWebView2Async(env);

            string baseURL = "https://id.twitch.tv/oauth2/authorize?response_type=code";
            string clientId = "client_id=" + WebServer.ClientID;
            string redirectUri = "redirect_uri=" + WebServer.URL;
            string scope = "scope=chat:read chat:edit channel:moderate whispers:read whispers:edit";
            string state = "state=c3ab8aa609ea11e793ae92361f002671";
            this.webview.Source = new System.Uri(baseURL + "&" + clientId + "&" + redirectUri + "&" + scope + "&" + state, System.UriKind.Absolute);
            this.FormClosed += WebView_FormClosing;

            void onCompleted()
            {
                BeginInvoke(new Action(() =>
                {
                    if (server.Login != "" && server.OAuthCode != "" && server.RefreshToken != "")
                    {
                        options.TwitchLogin = server.Login;
                        options.TwitchToken = server.OAuthCode;
                        options.TwitchRefreshToken = server.RefreshToken;
                    }
                    this.Close();
                    this.Dispose();
                }));
            }

            Thread thread = new Thread(() =>
            {
                try
                {
                    server = new WebServer();
                }
                finally
                {
                    onCompleted();
                }
            });
            thread.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.webview = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webview)).BeginInit();
            this.SuspendLayout();
            // 
            // webview
            // 
            this.webview.CreationProperties = null;
            this.webview.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webview.Location = new System.Drawing.Point(0, 0);
            this.webview.Margin = new System.Windows.Forms.Padding(0);
            this.webview.Name = "webview";
            this.webview.Size = new System.Drawing.Size(500, 750);
            this.webview.TabIndex = 0;
            this.webview.ZoomFactor = 1D;
            // 
            // WebViewLoginTwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 750);
            this.Controls.Add(this.webview);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 750);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 750);
            this.Name = "WebViewLoginTwitch";
            this.Text = "Twitch Chat Login";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.webview)).EndInit();
            this.ResumeLayout(false);

        }

        private void WebView_FormClosing(object sender, FormClosedEventArgs e)
        {
            try
            {
                string url = WebServer.URL + "/";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.GetResponse();
            }
            catch (WebException)
            {
            }
            this.Close();
            this.Dispose();
        }
    }

    class WebServer
    {
        public HttpListener listener;
        public readonly static string URL = "http://localhost:65432";
        public readonly static string ClientID = "gvhpl3qeui9p0n1eih18569fds7z5n";
        private static readonly string ClientSecret = "[REDACTED]";
        public string OAuthCode = "";
        public string RefreshToken = "";
        public string Login = "";
        public WebServer()
        {
            listener = new HttpListener();
            string url = WebServer.URL + "/";
            listener.Prefixes.Add(url);
            try
            {
                listener.Start();
                Task listenTask = HandleIncomingConnections();
                listenTask.GetAwaiter().GetResult();
            }
            catch (HttpListenerException)
            {
            }
        }
        public void Close()
        {
            listener.Close();
        }
        private string GetParameterFromUrl(string url, string parameter)
        {
            parameter += "=";
            var index = url.IndexOf(parameter);
            return url.Substring(index + parameter.Length, url.IndexOf("&", index) - index - parameter.Length);
        }

        public static void RefreshTwitchToken(Options options)
        {
            HttpClient httpclient = new HttpClient();
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "client_id", WebServer.ClientID }, { "client_secret", WebServer.ClientSecret }, { "grant_type", "refresh_token" }, { "refresh_token", options.TwitchRefreshToken } };
            var encodedContent = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = httpclient.PostAsync("https://id.twitch.tv/oauth2/token", encodedContent).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var _json = JObject.Parse(responseBody);
                options.TwitchToken = _json["access_token"].ToString();
                options.TwitchRefreshToken = _json["refresh_token"].ToString();
            }
        }

        public async Task HandleIncomingConnections()
        {
            HttpListenerContext ctx = await listener.GetContextAsync();
            HttpListenerRequest req = ctx.Request;
            HttpListenerResponse resp = ctx.Response;
            try
            {
                string code = GetParameterFromUrl(req.Url.ToString(), "code");
                HttpClient httpclient = new HttpClient();
                Dictionary<string, string> parameters = new Dictionary<string, string> { { "client_id", WebServer.ClientID }, { "client_secret", ClientSecret }, { "code", code }, { "grant_type", "authorization_code" }, { "redirect_uri", WebServer.URL } };
                var encodedContent = new FormUrlEncodedContent(parameters);

                HttpResponseMessage response = await httpclient.PostAsync("https://id.twitch.tv/oauth2/token", encodedContent).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var _json = JObject.Parse(responseBody);
                    OAuthCode = _json["access_token"].ToString();
                    RefreshToken = _json["refresh_token"].ToString();

                    httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", OAuthCode);
                    response = await httpclient.GetAsync("https://id.twitch.tv/oauth2/validate");
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        responseBody = await response.Content.ReadAsStringAsync();
                        _json = JObject.Parse(responseBody);
                        Login = _json["login"].ToString();
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
            }
            byte[] data = Encoding.UTF8.GetBytes("<html></html>");
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;

            await resp.OutputStream.WriteAsync(data, 0, data.Length);
            resp.Close();
            listener.Stop();
        }
    }
}
