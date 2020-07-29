using MediatR;

namespace SqzTo.Application.CQS.ShortUrl.Commands.CreateShortUrl
{
    public partial class CreateSqzLinkCommand : IRequest<string>
    {
        public string Url { get; set; }
    }
}
