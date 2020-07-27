using Microsoft.AspNetCore.Mvc;
using SqzTo.Application.CQS.ShortUrl.Commands.CreateShortUrl;
using SqzTo.Application.CQS.ShortUrl.Commands.NavigateToUrl;
using System.Threading.Tasks;

namespace SqzTo.Api.Controllers.V1
{
    public class UrlController : SqzToController
    {
        [HttpPost]
        public async Task<ActionResult<string>> GetOrCreateFrom([FromBody] CreateShortUrlCommand createShortUrlCommand)
        {
            return await Mediator.Send(createShortUrlCommand);
        }

        [HttpGet("{route}")]
        public async Task<ActionResult<string>> NavigateTo([FromRoute] string route)
        {
            return await Mediator.Send(new NavigateToCommand { Route = route });
        }
    }
}
