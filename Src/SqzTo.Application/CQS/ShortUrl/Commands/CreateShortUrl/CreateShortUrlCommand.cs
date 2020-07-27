using MediatR;

namespace SqzTo.Application.CQS.ShortUrl.Commands.CreateShortUrl
{
    public partial class CreateShortUrlCommand : IRequest<string>
    {
        public string Url { get; set; }
    }
}
