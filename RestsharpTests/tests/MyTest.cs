using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using Newtonsoft.Json;
using RestsharpTests.helpers;
using static RestsharpTests.helpers.HelperBase;
using RestsharpTests;

namespace RestsharpTests.tests
{
    public class MyTests : TestBase
    {
        [Test]
        public void Login()
        {
            HelperBase helperBase = new HelperBase();
            var token = helperBase.GetAuthToken(Config.AppLogin, Config.AppPassword);

            Console.WriteLine(token.access_token);

            RestsharpClient.Client.Authenticator = new OAuth2UriQueryParameterAuthenticator(token.access_token); //works
            var request = new RestRequest("api/frontend/v1/profiles/5", Method.GET);

            RestsharpClient.Client.Authenticator.Authenticate(RestsharpClient.Client, request);

            // execute the request
            IRestResponse response = RestsharpClient.Client.Execute(request);
            var content = response.Content; // raw content as string
            Console.WriteLine(content);

          
        }
    }
}
