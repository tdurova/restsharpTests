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
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;

        public string AccessToken { get; set; }

        public string GetAuthenticityToken(string username, string password)
        {
            _client = new RestClient(Config.ApplicationMainUrl);
            _client.CookieContainer = new System.Net.CookieContainer();

            Authorize();
            SignIn(username, password);

            IAuthenticator iAuthenticator = new OAuth2UriQueryParameterAuthenticator(AccessToken);
            iAuthenticator.

            return AccessToken;
        }


        public IRestResponse SignIn(string username, string password)
        {
            Console.WriteLine("Begin Signin");

            _client.Authenticator = new SimpleAuthenticator("user[email]", username, "user[password]", password);
            _request = new RestRequest("users/sign_in", Method.POST);
            _request.AddHeader("Accept", "*/*");
            _request.AddParameter("commit", "Sign in");
            _response = _client.Execute(_request);

            Console.WriteLine("Done Signin");

            Console.WriteLine(_response.ResponseUri.AbsoluteUri);
            Console.WriteLine(_response.Content);

            return _response;
        }

        public IRestResponse Authorize()
        {
            _request = new RestRequest("oauth/authorize", Method.GET);
            _request.AddHeader("Accept", "*/*");
            _request.AddParameter("response_type", "code");
            _request.AddParameter("client_id", Config.ConsumerId);
            _request.AddParameter("redirect_uri", Config.RedirectUrl);
            _response = _client.Execute(_request);

            Console.WriteLine(_response.ResponseUri);
            Console.WriteLine(_response.Content);

            return _response;
        }
    }
}
