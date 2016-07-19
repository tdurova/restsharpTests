using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace RestsharpTests.tests
{
    class MyTests : TestBase
    {
        [Test]
        public void MyTest () { // first do any necessary database setup. Or you could have a
            // test be a whole end-to-end use case where you do Post/Put 
            // requests to create a resource, Get requests to query the 
            // resource, and Delete request to delete it.

            // I use RestSharp as a way to test the request/response 
            // a little more independently from the ServiceStack framework.
            // Alternatively you could a ServiceStack client like JsonServiceClient.
            var  client  = new RestClient  ( ServiceTestAppHost  . BaseUrl  ); client  . Authenticator  =
            new HttpBasicAuthenticator  ( Config.AppLogin, Config.AppPassword  );
            var request = new RestRequest(Method.POST);
            var  response  = client  . Execute  < ResponseClass  >( request  );

            // do assertions on the response object now
        }

        [Test(Description = "Ticket # where you implemented the use case the client is paying for")]
        public void MySchemaValidationTest()
        {
            // Send a raw request with a hard-coded URL and request body.
            // Use a non-ServiceStack client for this.
            var request = new RestRequest("/service/endpoint/url", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(requestBodyObject);
            var response = Client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            RestSchemaValidator.ValidateResponse("ExpectedResponse.json", response.Content);
        }
    }

}
