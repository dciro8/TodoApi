using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todo.UnitTest
{
  public  class TestServices:IDisposable
    {

        private readonly TestServer _testSserver;
        public TestServices()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();
            _testSserver = new TestServer(webBuilder);
        }

        public void Dispose()
        {
            _testSserver.Dispose();
        }

        [Fact]
        public void TestConsept()
        {

        }
    }
}
