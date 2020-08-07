using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SqzTo.IntegrationTests
{
    [TestClass]
    public class CreateSqzLinkTests : IntegrationTestInitializer
    {
        [TestMethod]
        public async Task Ok()
        {
            var command = new CreateSqzLinkCommand
            {
                Domain = "sqz.to",
                DestinationUrl = "https://www.youtube.com/watch?v=2VR7Hl6SuXE"
            };
            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await _client.PostAsync("1.0/sqzlink", content);

            responce.EnsureSuccessStatusCode();
        }
    }
}
