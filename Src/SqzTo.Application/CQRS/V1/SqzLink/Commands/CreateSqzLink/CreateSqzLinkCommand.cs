using MediatR;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink
{
    public partial class CreateSqzLinkCommand : IRequest<CreateSqzLinkDto>
    {
        public string DestinationUrl { get; set; }
    }
}
