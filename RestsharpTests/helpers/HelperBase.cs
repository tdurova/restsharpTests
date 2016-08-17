using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace RestsharpTests.helpers
{
    public class HelperBase
    {
        private RestRequest _request;
        private IRestResponse _response;

        public string AccessToken { get; set; }

        public string GetAuthToken(string username, string password)
        {
            var cookieJar = new CookieContainer();
            
            var client = new RestClient("http://staging.cutwise.com")
            {
                Authenticator = new HttpBasicAuthenticator("test", "1234567"),
                CookieContainer = cookieJar
            };
            var request = new RestRequest("api/oauth/v2/token", Method.GET);

            string client_id = Config.ClientId;
            Console.WriteLine(client_id);

            request.AddParameter("client_id", Config.ClientId);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", Config.AppLogin);
            request.AddParameter("password", Config.AppPassword);
            request.AddParameter("client_secret", Config.ClientSecret);


            //Run once to get cookie.
            var response = client.Execute(request);

            //Run second time to get actual data
            response = client.Execute(request);

            return response.Content;
        }
    }
}
