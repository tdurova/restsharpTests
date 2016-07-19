using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace RestsharpTests.tests
{
    class Test1 : TestBase
    {
        [Test]
        public void TestGetStones()
        {
            Console.WriteLine("test 1");
        }

        [Test]
        public void TestGetStones2()
        {
            Console.WriteLine("test 1");

            var client = new RestClient("http://testing.cutwise.com/");
            var request = new RestRequest("api/frontend/v1/stones", Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            client.ExecuteAsync(request, response1 => {
                                                          Console.WriteLine(response1.Content); });

        }
    }
}
