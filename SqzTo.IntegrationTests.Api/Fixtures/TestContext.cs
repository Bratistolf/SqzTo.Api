using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SqzTo.Api;
using System;
using System.Net.Http;

namespace SqzTo.IntegrationTests.Api.Fixtures
{
    public class TestContext : IDisposable
    {
        private TestServer _server;

        public HttpClient Client { get; private set; }

        public TestContext()
        {
            SetUpClient();
        }

        private void SetUpClient()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server?.Dispose();
            Client?.Dispose();
        }
    }
}
