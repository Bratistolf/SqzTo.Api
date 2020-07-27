using MediatR;

namespace SqzTo.Application.CQS.ShortUrl.Commands.NavigateToUrl
{
    public class NavigateToCommand : IRequest<string>
    {
        public string Route { get; set; }
    }
}
