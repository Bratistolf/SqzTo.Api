using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using SqzTo.Api;
using SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SqzTo.IntegrationTests.Api.SqzLinkTests
{
    public class CreateSqzLinkTests
    {
        private readonly HttpClient _client;

        public CreateSqzLinkTests()
        {
            var _server = new TestServer(new WebHostBuilder()
                   .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task Create_ShouldReturn200StatusCode()
        {
            // Arrange
            var createSqzLinkCommand = new CreateSqzLinkCommand
            {
                Domain = "sqz.to",
                DestinationUrl = "https://www.youtube.com/"
            };
            var json = JsonConvert.SerializeObject(createSqzLinkCommand);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var httpResponse = await _client.PostAsync("/1.0/sqzlink", stringContent);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
