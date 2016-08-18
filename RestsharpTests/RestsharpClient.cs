using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RestSharp;

namespace RestsharpTests
{
    public class RestsharpClient : RestsharpClientBase
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

        private IRestRequest _request = null;
        public IRestRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }

        private IRestResponse _response = null;
        public IRestResponse Response
        {
            get
            {
                _response = MyExecute(Request);
                return _response;
            }
            set { _response = value; }
        }


        public RestsharpClient TRestsharpClient
        {
            get { return MyExecute<RestsharpClient>(Request); }
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

        public RestsharpClient(IRestClient restClient, ILogger logger) : base(restClient, logger)
        {
        }

        public RestsharpClient()
        {
            Run();
        }
    }
}
