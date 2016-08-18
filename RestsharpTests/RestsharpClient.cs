using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RestSharp;

namespace RestsharpTests
{
    public static class RestsharpClient
    {
        private static Logger _logger = null; 
        public static Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetCurrentClassLogger();
                }
                return _logger;
            }
        }

        
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
