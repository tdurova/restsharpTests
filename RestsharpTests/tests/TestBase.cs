using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace RestsharpTests.tests
{
    public class TestBase
    {
        
        [SetUp]
        public void RunBeforeAnyTests()
        {
            //var client = new RestClient();
            RestsharpClient.Client.BaseUrl = new Uri(Config.ApplicationMainUrl);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            // Clear up code here.
            
        }
    }
}
