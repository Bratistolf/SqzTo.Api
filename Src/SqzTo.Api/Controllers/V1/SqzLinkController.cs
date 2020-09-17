using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqzTo.Api.Common;
using SqzTo.Application.CQRS.V1.Link.Commands.BulkCreate;
using SqzTo.Application.CQRS.V1.Link.Commands.Create;
using SqzTo.Application.CQRS.V1.Link.Commands.Edit;
using SqzTo.Application.CQRS.V1.Link.Commands.Navigate;
using SqzTo.Application.CQRS.V1.Link.Queries.GetClicks;
using SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkDetails;
using SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkQr;
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
        /// Generates a SqzLinks from the long urls.
        /// </summary>
        /// <returns>Generated SqzLinks within the <see cref="SqzLinkDto"/> DTO.</returns>
        /// <response code="200">
        /// SqzLinks were successfully created.
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
        /// <param name="bulkCreateRequest">Request from the user.</param>
        [HttpPost]
        [Route(ApiRoutes.BulkCreateSqzLink)]
        [ProducesResponseType(typeof(ActionResult<BulkCreateResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<BulkCreateResponse>> BulkCreateSqzLink([FromBody] BulkCreateRequest bulkCreateRequest)
        {
            return Ok(await Mediator.Send(bulkCreateRequest));
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

        /// <summary>
        /// Sets up an expiration date for a SqzLink.
        /// </summary>
        /// <response code="204">SqzLink's edit was a success</response>
        /// <response code="400">Validation error</response>
        /// <param name="sqzlink"></param>
        /// <param name="editRequestBody"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route(ApiRoutes.EditSqzLink)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult> EditSqzLink([FromRoute] string sqzlink, [FromBody] EditRequestBody editRequestBody)
        {
            await Mediator.Send(new EditRequest { SqzLink = sqzlink, Body = editRequestBody });
            return NoContent();
        }

        /// <summary>
        /// Returns public information for a SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.GetSqzLinkDetails)]
        [ProducesResponseType(typeof(GetDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<GetDetailsResponse>> GetSqzLinkDetails([FromRoute] string sqzlink)
        {
            return Ok(await Mediator.Send(new GetDetailsRequest { SqzLink = sqzlink }));
        }

        /// <summary>
        /// Returns the click counts for a specified SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.GetSqzLinkClicks)]
        [ProducesResponseType(typeof(GetClicksResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<GetClicksResponce>> GetSqzLinkClicks([FromRoute] string sqzlink)
        {
            return Ok(await Mediator.Send(new GetClicksRequest { SqzLink = sqzlink }));
        }

        /// <summary>
        /// Generates a QR code for a SqzLink.
        /// </summary>
        /// <param name="sqzlink"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.GetSqzLinkQr)]
        [ProducesResponseType(typeof(GetSqzLinkQrDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<GetSqzLinkQrDto>> GetSqzLinkQr([FromRoute] string sqzlink)
        {
            return Ok(await Mediator.Send(new GetSqzLinkQrQuery { SqzLink = sqzlink }));
        }
    }
}