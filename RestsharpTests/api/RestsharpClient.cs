using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace RestsharpExtension
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
                    _client = Run();
                }
                return _client;
            }
        }

        private static RestClient Run()
        {
            return new RestClient();
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
