using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Extensions;
using Newtonsoft.Json;
using RestsharpTests.helpers;

namespace RestsharpTests.tests
{
    public class MyTests : TestBase
    {
        HelperBase helperBase = new HelperBase();

        [Test]
        public void Login()
        {
            var accessToken = helperBase.GetAuthToken(Config.AppLogin, Config.AppPassword);

            Console.WriteLine(accessToken);

        }
    }
}
