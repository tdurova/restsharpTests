using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestsharpTests
{
    public static class RestsharpClient
    {
        private static RestClient _client = null;

        public static IRestClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new RestClient();
                }
                return _client;
            }
        }

        public static void CloseClient()
        {
            if (_client != null)
            {
                _client = null;
            }
        }

        static readonly Finalizer finalizer = new Finalizer();
        sealed class Finalizer
        {
            ~Finalizer()
            {
                CloseClient();
            }
        }
    }
}
