using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SqzTo.Api.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}")]
    [AdvertiseApiVersions("1.0")]
    public abstract class SqzToController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
