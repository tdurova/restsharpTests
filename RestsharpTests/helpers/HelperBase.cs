﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using RestSharp.Authenticators;

namespace RestsharpTests.helpers
{
    public class HelperBase
    {
        public string AccessToken { get; set; }

        public ResponseToken GetAuthToken(string username, string password)
        {
            ILogger logger = LogManager.GetCurrentClassLogger();
            RestApi Api = new RestApi(RestsharpClient.Client, logger);

            var cookieJar = new CookieContainer();
            RestsharpClient.Client.CookieContainer = cookieJar;

            var request = new RestRequest("api/oauth/v2/token", Method.GET);

            request.AddParameter("client_id", Config.ClientId);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("client_secret", Config.ClientSecret);

            var response = RestsharpClient.Client.Execute(request);

            Api.Execute(request);

            var token = JsonConvert.DeserializeObject<ResponseToken>(response.Content);

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
