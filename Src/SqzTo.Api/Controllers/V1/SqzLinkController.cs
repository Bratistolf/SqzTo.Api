using Microsoft.AspNetCore.Mvc;
using SqzTo.Application.CQRS.SqzLink.Commands.CreateShortUrl;
using SqzTo.Application.CQRS.SqzLink.Commands.NavigateSqzLink;
using SqzTo.Application.CQRS.SqzLink.Commands.UpdateSqzLink;
using SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkClicks;
using SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkDetails;
using SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkQr;
using System.Threading.Tasks;

namespace SqzTo.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class SqzLinkController : SqzToController
    {
        /// <summary>
        /// Converts a long url into a SqzLink.
        /// </summary>
        /// <param name="createSqzLinkCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<string>> CreateSqzLink([FromBody] CreateSqzLinkCommand createSqzLinkCommand)
        {
            return await Mediator.Send(createSqzLinkCommand);
        }

        /// <summary>
        /// Returns original url by SqzLink route.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{route}")]
        [ProducesResponseType(typeof(NavigateSqzLinkDto), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<NavigateSqzLinkDto>> NavigateSqzLink([FromRoute] string route)
        {
            return await Mediator.Send(new NavigateSqzLinkCommand { Route = route });
        }

        /// <summary>
        /// Generates a QR code for a SqzLink.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{route}/qr")]
        [ProducesResponseType(typeof(GetSqzLinkQrDto), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<GetSqzLinkQrDto>> GetSqzLinkQr([FromRoute] string route)
        {
            return BadRequest();
        }

        /// <summary>
        /// Returns the click counts for a specified SqzLink.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{route}/clicks")]
        [ProducesResponseType(typeof(GetSqzLinkClicksDto), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<GetSqzLinkClicksDto>> GetSqzLinkClicks([FromRoute] string route)
        {
            return await Mediator.Send(new GetSqzLinkClicksQuery { Route = route });
        }

        /// <summary>
        /// Returns public information for a SqzLink.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{route}/details")]
        [ProducesResponseType(typeof(GetSqzLinkDetailsDto), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<GetSqzLinkDetailsDto>> GetSqzLinkDetails([FromRoute] string route)
        {
            return await Mediator.Send(new GetSqzLinkDetailsQuery { Route = route });
        }

        /// <summary>
        /// Updates SqzLink.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{route}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateSqzLink([FromRoute] string route, [FromBody] UpdateSqzLinkCommand updateSqzLinkCommand)
        {
            //TODO: ...
            return BadRequest();
        }
    }
}