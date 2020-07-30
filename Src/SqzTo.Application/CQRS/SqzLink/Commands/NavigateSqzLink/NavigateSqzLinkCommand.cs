using MediatR;

namespace SqzTo.Application.CQRS.SqzLink.Commands.NavigateSqzLink
{
    public class NavigateSqzLinkCommand : IRequest<NavigateSqzLinkDto>
    {
        public string Route { get; set; }
    }
}
