using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MidiControl.OptionsManagment;
using System.Web;

namespace MidiControl
{
    partial class WebViewLoginTwitch : Form
    {
        private readonly System.ComponentModel.IContainer components = null;
        private WebServer server;
        private WebView2 webview;

        public WebViewLoginTwitch(Options options)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            InitializeComponent();
            Icon = (System.Drawing.Icon)(resources.GetObject("icon"));

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var ConfFolder = Path.Combine(folder, "MIDIControl");
            var optionsWebView = new CoreWebView2EnvironmentOptions();
            var env = CoreWebView2Environment.CreateAsync("", ConfFolder, optionsWebView).GetAwaiter().GetResult();
            webview.EnsureCoreWebView2Async(env);

            var uriBuilder = new UriBuilder("https://id.twitch.tv/oauth2/authorize?");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Add("response_type", "code");
            query.Add("client_id", ConfigurationManager.AppSettings["TwitchClientId"]);
            query.Add("redirect_uri", ConfigurationManager.AppSettings["TwitchLocalUrl"]);
            query.Add("scope", ConfigurationManager.AppSettings["TwitchScope"]);
            query.Add("state", "c3ab8aa609ea11e793ae92361f002671");
            uriBuilder.Query = query.ToString();
            webview.Source = uriBuilder.Uri;
            FormClosed += WebView_FormClosing;

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
                    Close();
                    Dispose();
                }));
            }

            var thread = new Thread(() =>
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
            webview = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(webview)).BeginInit();
            SuspendLayout();
            // 
            // webview
            // 
            webview.CreationProperties = null;
            webview.DefaultBackgroundColor = System.Drawing.Color.White;
            webview.Location = new System.Drawing.Point(0, 0);
            webview.Margin = new System.Windows.Forms.Padding(0);
            webview.Name = "webview";
            webview.Size = new System.Drawing.Size(500, 750);
            webview.TabIndex = 0;
            webview.ZoomFactor = 1D;
            // 
            // WebViewLoginTwitch
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 750);
            Controls.Add(webview);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(500, 750);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(500, 750);
            Name = "WebViewLoginTwitch";
            Text = "Twitch Chat Login";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(webview)).EndInit();
            ResumeLayout(false);

        }

        private void WebView_FormClosing(object sender, FormClosedEventArgs e)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["TwitchLocalUrl"]);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.GetResponse();
            }
            catch (WebException)
            {
            }
            Close();
            Dispose();
        }
    }

    class WebServer
    {
        public HttpListener listener;
        public string OAuthCode = string.Empty;
        public string RefreshToken = string.Empty;
        public string Login = string.Empty;
        public WebServer()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(ConfigurationManager.AppSettings["TwitchLocalUrl"]);
            try
            {
                listener.Start();
                var listenTask = HandleIncomingConnections();
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
            var httpclient = new HttpClient();
            var parameters = new Dictionary<string, string> { 
                { "client_id", ConfigurationManager.AppSettings["TwitchClientId"] }, 
                { "client_secret", ConfigurationManager.AppSettings["TwitchClientSecret"] }, 
                { "grant_type", "refresh_token" }, 
                { "refresh_token", options.TwitchRefreshToken }
            };
            var encodedContent = new FormUrlEncodedContent(parameters);
            var response = httpclient.PostAsync("https://id.twitch.tv/oauth2/token", encodedContent).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var _json = JObject.Parse(responseBody);
                options.TwitchToken = _json["access_token"].ToString();
                options.TwitchRefreshToken = _json["refresh_token"].ToString();
            }
        }

        public async Task HandleIncomingConnections()
        {
            var ctx = await listener.GetContextAsync();
            var req = ctx.Request;
            var resp = ctx.Response;
            try
            {
                var code = GetParameterFromUrl(req.Url.ToString(), "code");
                var httpclient = new HttpClient();
                var parameters = new Dictionary<string, string> { 
                    { "client_id", ConfigurationManager.AppSettings["TwitchClientId"] }, 
                    { "client_secret", ConfigurationManager.AppSettings["TwitchClientSecret"] }, 
                    { "code", code }, 
                    { "grant_type", "authorization_code" }, 
                    { "redirect_uri", ConfigurationManager.AppSettings["TwitchLocalUrl"] } };
                var encodedContent = new FormUrlEncodedContent(parameters);

                var response = await httpclient.PostAsync("https://id.twitch.tv/oauth2/token", encodedContent).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
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
            var data = Encoding.UTF8.GetBytes("<html></html>");
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;

            await resp.OutputStream.WriteAsync(data, 0, data.Length);
            resp.Close();
            listener.Stop();
        }
    }
}
