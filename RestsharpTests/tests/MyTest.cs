using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestsharpTests.helpers;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using Newtonsoft.Json;

namespace RestsharpTests.tests
{
    public class MyTests : TestBase
    {
        [Test]
        public void GetLogIn () { // first do any necessary database setup. Or you could have a

            HelperBase helper = new HelperBase();

            var accessToken = helper.GetAuthenticityToken(Config.AppLogin, Config.AppPassword);

            Console.WriteLine(accessToken);

            RestClient client = new RestClient(Config.ApplicationMainUrl);

            /*RestRequest request = new RestRequest("api/frontend/v1/stones", Method.GET);
            request.AddParameter("Authorization",
            string.Format("Bearer " + accessToken),
                        ParameterType.HttpHeader);
            request.AddQueryParameter("limit","1");

            var response = client.Execute(request); */

            Console.WriteLine(accessToken);
            
            //DirAppend.LogMessageToFile(response.Content);

        }

        /*[Test(Description = "Ticket # where you implemented the use case the client is paying for")]
        public void MySchemaValidationTest()
        {
            
        }*/
    }

}
