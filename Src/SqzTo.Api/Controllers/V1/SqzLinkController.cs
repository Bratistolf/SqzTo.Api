using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqzTo.Api.Common;
using SqzTo.Application.CQRS.V1.Link.Commands.Create;
using SqzTo.Application.CQRS.V1.Link.Commands.Navigate;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Api.Controllers.V1
{
    /// <summary>
    /// Primary SqzLink controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SqzLinkController : SqzToController
    {
        /// <summary>
        /// Generates a SqzLink from the long url.
        /// </summary>
        /// <returns>Generated SqzLink within the <see cref="SqzLinkDto"/> DTO.</returns>
        /// <response code="200">
        /// SqzLink was successfully created.
        /// </response>
        /// <response code="400">
        /// The server cannot process the request due to a client error.
        /// </response>
        /// <response code="500">
        /// An error occurred while processing request.
        /// </response>
        /// <response code="503">
        /// The server is currently unable to handle the request due to a temporary overload or 
        /// scheduled maintenance, which will likely be alleviated after some delay.
        /// </response>
        /// <param name="createRequest">Request from the user.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [Route(ApiRoutes.CreateSqzLink)]
        [ProducesResponseType(typeof(ActionResult<SqzLinkDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<SqzLinkDto>> CreateSqzLink([FromBody] CreateCommand createRequest, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(createRequest, cancellationToken));
        }

        /// <summary>
        /// Returns original url by SqzLink route.
        /// </summary>
        /// <returns>Destination URL.</returns>
        /// <response code="200">
        /// Destination URL for the SqzLink was successfully found.
        /// </response>
        /// <response code="400">
        /// The server cannot process the request due to a client error.
        /// </response>
        /// <response code="404">
        /// The specified resource was not found.
        /// </response>
        /// <response code="500">
        /// An error occurred while processing request.
        /// </response>
        /// <response code="503">
        /// The server is currently unable to handle the request due to a temporary overload or 
        /// scheduled maintenance, which will likely be alleviated after some delay.
        /// </response>
        /// <param name="sqzlink">SqzLink</param>
        [HttpGet]
        [Route(ApiRoutes.NavigateSqzLink)]
        [ProducesResponseType(typeof(NavigateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<NavigateResponse>> NavigateSqzLink([FromRoute] string sqzlink)
        {
            return Ok(await Mediator.Send(new NavigateRequest { SqzLink = sqzlink }));
        }
    }
}