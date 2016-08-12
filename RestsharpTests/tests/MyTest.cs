using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ImplicitConsoleClient;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using Newtonsoft.Json;
using RestsharpTests.helpers;

namespace RestsharpTests.tests
{
    public class MyTests : TestBase
    {
        HelperBase helperBase = new HelperBase();

        [Test]
        public void Login()
        {
            // first do any necessary database setup. Or you could have a

            //var accessToken = helperBase.GetAuthenticityToken(Config.AppLogin, Config.AppPassword);

            //Console.WriteLine(accessToken);


            ImplicitClient implicitClient = new ImplicitClient(Config.ApplicationMainUrl, Config.ConsumerId,
                Config.RedirectUrl,Config.ResponseType,"","","");

            var token = implicitClient.GetResponseTokenAsync(Config.AppLogin, Config.AppPassword);
            Console.WriteLine(token.Result.AccessToken);

            /*RestRequest request = new RestRequest("api/frontend/v1/stones", Method.GET);
            request.AddParameter("Authorization",
            string.Format("Bearer " + accessToken),
                        ParameterType.HttpHeader);
            request.AddQueryParameter("limit","1");

            var response = client.Execute(request); */

            //DirAppend.LogMessageToFile(response.Content);
        }

       
    }
}
