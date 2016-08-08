using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestsharpTests.helpers
{
    public class TestHelper
    {
        public void Login(string login, string password)
        {
            var client = new RestClient("http://192.168.0.1");
            var request = new RestRequest("api/item/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Item
            {
                ItemName = someName,
                Price = 19.99
            });
            client.Execute(request);
        }
    }
}
