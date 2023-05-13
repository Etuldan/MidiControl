using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static MidiControl.OptionsManagment;

namespace MidiControl
{
    class WebServer
    {
        public HttpListener listener;
        public string OAuthCode { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
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
                var json = JObject.Parse(responseBody);
                options.TwitchToken = json["access_token"].ToString();
                options.TwitchRefreshToken = json["refresh_token"].ToString();
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
                    var json = JObject.Parse(responseBody);
                    this.OAuthCode = json["access_token"].ToString();
                    this.RefreshToken = json["refresh_token"].ToString();

                    httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", OAuthCode);
                    response = await httpclient.GetAsync("https://id.twitch.tv/oauth2/validate");
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        responseBody = await response.Content.ReadAsStringAsync();
                        json = JObject.Parse(responseBody);
                        this.Login = json["login"].ToString();
                    }
                }

            }
            catch (ArgumentOutOfRangeException)
            {
            }
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\redirect.html");
            var data = File.ReadAllBytes(path);
            resp.ContentType = "text/html";
            resp.ContentEncoding = Encoding.UTF8;
            resp.ContentLength64 = data.LongLength;

            await resp.OutputStream.WriteAsync(data, 0, data.Length);
            resp.Close();
            listener.Stop();
        }
    }
}
