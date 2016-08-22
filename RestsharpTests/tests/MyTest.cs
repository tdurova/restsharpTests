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
using NLog;
using RestsharpTests.helpers;
using RestsharpTests;

namespace RestsharpTests.tests
{
    public class MyTests : TestBase
    {
        HelperBase helperBase = new HelperBase();

        [Test]
        public void Login()
        {
            var token = helperBase.GetAuthToken(Config.AppLogin, Config.AppPassword);
            var request = new RestRequest("api/frontend/v1/profiles/5", Method.GET);
            
            helperBase.SetAccessToken(request, token.access_token);
            RestClient.Execute(request);

            helperBase.ClearAccessToken();
            RestClient.Execute(request);

        }
    }
}
