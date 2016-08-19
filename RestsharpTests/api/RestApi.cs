using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RestSharp;

namespace RestsharpTests
{
/**
* Класс расширяет базовый применимо к тестируемому API,
* добавляя обработку заголовков, в т.ч. аксесс токенов (для OAuth 2.0)
*/
 public class RestApi : RestApiBase
    {
       private static IRestClient _client = null;

        public RestApi(IRestClient restClient, ILogger logger) : base(restClient, logger)
        {
        }

        public new ApiModel Execute<ApiModel>(IRestRequest request) where ApiModel : new()
        {
            return base.Execute<ApiModel>(request);
        }

        public new IRestResponse Execute(IRestRequest request)
        {
            return base.Execute(request);
        }

        public static IRestClient Client
        {
            get
            {
                if (_client == null)
                {
                    return new RestClient();
                }
                return _client;
              
            }
        }

        public static ILogger Logger { get; set; }
    }
}
