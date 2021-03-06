﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RestsharpExtension;
using RestSharp;

namespace RestsharpTests
{
/**
* Класс расширяет базовый применимо к тестируемому API,
* добавляя обработку заголовков, в т.ч. аксесс токенов (для OAuth 2.0)
*/

    public class RestApi : RestApiBase
    {
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

        /*public static IRestClient Client
        {
            get { return RestsharpClient.Client; }
        }*/

        public static ILogger Logger { get; set; }

    }
}
