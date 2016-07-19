﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestsharpTests
{
    // the main detail is that this uses a different base class
    public class ServiceTestAppHost : AppHostHttpListenerBase
    {
        public const string BaseUrl = "http://localhost:8082/";

        public override void Configure(Container container)
        {
            // Add some request/response filters to set up the correct database
            // connection for the integration test database (may not be necessary
            // depending on your implementation)
            RequestFilters.Add((httpRequest, httpResponse, requestDto) =>
            {
                var dbContext = MakeSomeDatabaseContext();
                httpRequest.Items["DatabaseIntegrationTestContext"] = dbContext;
            });
            ResponseFilters.Add((httpRequest, httpResponse, responseDto) =>
            {
                var dbContext = httpRequest.Items["DatabaseIntegrationTestContext"] as DbContext;
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    httpRequest.Items.Remove("DatabaseIntegrationTestContext");
                }
            });

            // now include any configuration you want to share between this 
            // and your regular AppHost, e.g. IoC setup, EndpointHostConfig,
            // JsConfig setup, adding Plugins, etc.
            SharedAppHost.Configure(container);
        }
    }
}
