using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace RestsharpTests.helpers
{
    public class HelperBase
    {
        private RestRequest _request;
        private IRestResponse _response;

        public string AccessToken { get; set; }

        public ResponseToken GetAuthToken(string username, string password)
        {
            var cookieJar = new CookieContainer();

            RestsharpClient.Client.CookieContainer = cookieJar;

            _request = new RestRequest("api/oauth/v2/token", Method.GET);

            _request.AddParameter("client_id", Config.ClientId);
            _request.AddParameter("grant_type", "password");
            _request.AddParameter("username", username);
            _request.AddParameter("password", password);
            _request.AddParameter("client_secret", Config.ClientSecret);


            //Run once to get cookie.
            _response = RestsharpClient.Client.Execute(_request);

            //Run second time to get actual data
            _response = RestsharpClient.Client.Execute(_request);

            var token = JsonConvert.DeserializeObject<ResponseToken>(_response.Content);

            return token;
        }

        public class ResponseToken
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
            public string refresh_token { get; set; }
        }
    }
}
