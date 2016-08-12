using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public string GetAuthenticityToken(string username, string password)
        {
            RestsharpClient.Client.CookieContainer = new System.Net.CookieContainer();
            

            return AccessToken;
        }
    }

}
