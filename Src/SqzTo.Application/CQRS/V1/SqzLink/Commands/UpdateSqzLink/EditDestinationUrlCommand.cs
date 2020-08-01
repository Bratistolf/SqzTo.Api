using MediatR;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.UpdateSqzLink
{
    public class EditDestinationUrlCommand : IRequest
    {
        public string DestinationUrl { get; set; }
    }
}
