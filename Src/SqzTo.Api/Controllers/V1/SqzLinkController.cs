using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink;
using SqzTo.Application.CQRS.V1.SqzLink.Commands.NavigateSqzLink;
using SqzTo.Application.CQRS.V1.SqzLink.Commands.UpdateSqzLink;
using SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkClicks;
using SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkDetails;
using SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkQr;
using System.Threading.Tasks;

namespace SqzTo.Api.Controllers.V1
{
    /// <summary>
    /// Primary SqzLink controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class SqzLinkController : SqzToController
    {
        // POST: v1.0/sqzlink/ 
        /// <summary>
        /// Converts a long url into a SqzLink.
        /// </summary>
        /// <param name="createSqzLinkCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(CreateSqzLinkDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<CreateSqzLinkDto>> CreateSqzLink([FromBody] CreateSqzLinkCommand createSqzLinkCommand)
        {
            return await Mediator.Send(createSqzLinkCommand);
        }

        // GET: v1.0/sqzlink/{route}
        /// <summary>
        /// Returns original url by SqzLink route.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{sqzlink}")]
        [ProducesResponseType(typeof(NavigateSqzLinkDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<NavigateSqzLinkDto>> NavigateSqzLink([FromRoute] string sqzlink)
        {
            return await Mediator.Send(new NavigateSqzLinkCommand { Link = sqzlink });
        }

        // GET: v1.0/sqzlink/{route}/qr
        /// <summary>
        /// Generates a QR code for a SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{sqzlink}/qr")]
        [ProducesResponseType(typeof(GetSqzLinkQrDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<GetSqzLinkQrDto>> GetSqzLinkQr([FromRoute] string sqzlink)
        {
            return BadRequest();
        }

        // GET: v1.0/sqzlink/ 
        /// <summary>
        /// Returns the click counts for a specified SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{sqzlink}/clicks")]
        [ProducesResponseType(typeof(GetSqzLinkClicksDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<GetSqzLinkClicksDto>> GetSqzLinkClicks([FromRoute] string sqzlink)
        {
            return await Mediator.Send(new GetSqzLinkClicksQuery { SqzLink = sqzlink });
        }

        // GET: v1.0/sqzlink/{route}/details
        /// <summary>
        /// Returns public information for a SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{sqzlink}/details")]
        [ProducesResponseType(typeof(GetSqzLinkDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<GetSqzLinkDetailsDto>> GetSqzLinkDetails([FromRoute] string sqzlink)
        {
            return await Mediator.Send(new GetSqzLinkDetailsQuery { Link = sqzlink });
        }

        // PATCH: v1.0/sqzlink/{route}
        /// <summary>
        /// Edit destination URL for a SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <param name="updateSqzLinkCommand"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{sqzlink}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<Unit>> EditDestinationUrl([FromRoute] string sqzlink, [FromBody] EditDestinationUrlCommand updateSqzLinkCommand)
        {
            return await Mediator.Send(updateSqzLinkCommand);
        }
    }
}