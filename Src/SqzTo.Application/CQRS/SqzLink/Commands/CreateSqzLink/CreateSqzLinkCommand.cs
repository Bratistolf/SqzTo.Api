using MediatR;

namespace SqzTo.Application.CQRS.SqzLink.Commands.CreateShortUrl
{
    public partial class CreateSqzLinkCommand : IRequest<string>
    {
        public string Url { get; set; }
    }
}
