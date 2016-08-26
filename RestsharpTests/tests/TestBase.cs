using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
using RestsharpExtension;
using RestSharp;
using Logger = NUnit.Framework.Internal.Logger;

namespace RestsharpTests.tests
{
    public class TestBase
    {
        protected IRestClient RestClient = RestsharpClient.Client;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            //var client = new RestClient();
            RestClient.BaseUrl = new Uri(Config.ApplicationMainUrl);
            
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            // Clear up code here.
        }
    }
}
