using MediatR;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.NavigateSqzLink
{
    public class NavigateSqzLinkCommand : IRequest<NavigateSqzLinkDto>
    {
        public string Link { get; set; }
    }
}
