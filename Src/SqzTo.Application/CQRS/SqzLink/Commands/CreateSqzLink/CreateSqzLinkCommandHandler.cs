using MediatR;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.SqzLink.Commands.CreateShortUrl
{
    public class CreateSqzLinkCommandHandler : IRequestHandler<CreateSqzLinkCommand, string>
    {
        private readonly ISqzToDbContext _context;
        private readonly IUrlShorteningService _urlShorteningService;

        public CreateSqzLinkCommandHandler(ISqzToDbContext context, IUrlShorteningService urlShorteningService)
        {
            _context = context;
            _urlShorteningService = urlShorteningService;
        }

        public async Task<string> Handle(CreateSqzLinkCommand request, CancellationToken cancellationToken)
        {
            var originalUrl = request.Url;
            var newSqzLink = new Domain.Entities.SqzLink
            {
                OriginalUrl = request.Url,
                Route = _urlShorteningService.ShortenUrl(originalUrl),
                Clicks = 0
            };

            _context.SqzLinks.Add(newSqzLink);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return newSqzLink.Route;
        }
    }
}
