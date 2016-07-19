using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RestsharpTests.tests
{
    class TestBase
    {

        [SetUp]
        public void RunBeforeAnyTests()
        {
            // Set up code here.
            Console.WriteLine("setup");

            AppHost = new ServiceTestAppHost();
            AppHost.Init();
            AppHost.Start(ServiceTestAppHost.BaseUrl);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            // Clear up code here.
            AppHost.Dispose();
        }
    }
}
