using Microsoft.AspNetCore.Mvc;
using SqzTo.Application.CQS.ShortUrl.Commands.CreateShortUrl;
using SqzTo.Application.CQS.ShortUrl.Commands.NavigateToUrl;
using System.Threading.Tasks;

namespace SqzTo.Api.Controllers.V1
{
    public class SqzLinkController : SqzToController
    {
        /// <summary>
        /// Converts a long url into a SqzLink.
        /// </summary>
        /// <param name="createSqzLinkCommand"></param>
        /// <returns></returns>
        [HttpPost, Route("api/v1/sqzlink")]
        public async Task<ActionResult<string>> CreateSqzLink([FromBody] CreateSqzLinkCommand createSqzLinkCommand)
        {
            return await Mediator.Send(createSqzLinkCommand);
        }

        /// <summary>
        /// TODO: ...
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet("api/v1/sqzlink/{route}")]
        public async Task<ActionResult<string>> NavigateSqzLink([FromRoute] string route)
        {
            return await Mediator.Send(new NavigateToCommand { Route = route });
        }

        /// <summary>
        /// Generates a QR code for a SqzLink
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet("api/v1/sqzlink/{route}/clicks")]
        public async Task<ActionResult> GetSqzLinkQr([FromRoute] string route)
        {
            //TODO: ...
            return BadRequest();
        }

        /// <summary>
        /// TODO: ...
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpPatch("api/v1/sqzlink/{route}")]
        public async Task<ActionResult> UpdateSqzLink([FromRoute] string route)
        {
            //TODO: ...
            return BadRequest();
        }

        

        /// <summary>
        /// Returns the click counts for a specified SqzLink.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet("api/v1/sqzlink/{route}/clicks")]
        public async Task<ActionResult> GetSqzLinkClicks([FromRoute] string route)
        {
            //TODO: ...
            return BadRequest();
        }
    }
}