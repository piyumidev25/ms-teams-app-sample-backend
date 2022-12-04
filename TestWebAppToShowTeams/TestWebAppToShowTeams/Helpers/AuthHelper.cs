using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System;
using System.Threading.Tasks;
using TestWebAppToShowTeams.Models;
using System.Text.Json.Serialization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TestWebAppToShowTeams.Helpers
{
    public class AuthHelper
    {
        private static IConfiguration _configuration;

        public AuthHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetAuthUrl()
        {
            var scope = _configuration.GetValue<string>("AzureAd:Scope");
            var clientId = _configuration.GetValue<string>("AzureAd:ClientId");
            var redirectUrl = _configuration.GetValue<string>("AzureAd:RedirectUrl");
            var aadInstance = _configuration.GetValue<string>("AzureAd:Instance");
            var url =
                  aadInstance +
                  "common" +
                  "/oauth2/v2.0/authorize?" +
                  "client_id=" +
                  clientId +
                  "&" +
                  "response_mode=query&" +
                  "response_type=code&" +
                  "scope=" +
                  scope +
                  "&" +
                  "redirect_uri=" +
                    redirectUrl;
            return url;
        }
        public static async Task<string> HttpPostAsync(string url, string payload)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] data = Encoding.UTF8.GetBytes(payload);
            req.ContentLength = data.Length;
            using (Stream responseStream = req.GetRequestStream())
            {
                responseStream.Write(data, 0, data.Length);
                responseStream.Close();
            }

            // Process the response
            var resp = await req.GetResponseAsync();

            if (resp == null)
                // No HTTP response content obtained for web POST request;
                return null;

            var sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string retval = sr.ReadToEnd().Trim();
            return retval;
        }

        public async Task<MSAuthTokenResponse> GetMSTokenAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException($"{nameof(code)} cannot be null or empty");
            }
            try
            {
                var scope = _configuration.GetValue<string>("AzureAd:Scope");
                var clientId = _configuration.GetValue<string>("AzureAd:ClientId");
                var redirectUrl = _configuration.GetValue<string>("AzureAd:RedirectUrl");
                var aadInstance = _configuration.GetValue<string>("AzureAd:Instance");
                var clientSecret = _configuration.GetValue<string>("AzureAd:ClientSecret");
                var tenant = _configuration.GetValue<string>("AzureAd:TenantId");
                var content = "grant_type=authorization_code&" +
                                "scope=" + scope + "&" +
                                "code=" + code + "&" +
                                "client_id=" + clientId + "&" +
                                "client_secret=" + clientSecret + "&" +
                                "redirect_uri=" + redirectUrl;
                var apiurl = $"{aadInstance}{tenant}/oauth2/v2.0/token";
                var response = await HttpPostAsync(apiurl, content);
                var msTokenResponse = JsonConvert.DeserializeObject<MSAuthTokenResponse>(response);
                return msTokenResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
