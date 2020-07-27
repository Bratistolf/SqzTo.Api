using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQS.ShortUrl.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, string>
    {
        private readonly ISqzToDbContext _context;
        private readonly IUrlShorteningService _urlShorteningService;

        public CreateShortUrlCommandHandler(ISqzToDbContext context, IUrlShorteningService urlShorteningService)
        {
            _context = context;
            _urlShorteningService = urlShorteningService;
        }

        public async Task<string> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            var existingUrl = await _context.ShortUrls.FirstOrDefaultAsync(url => url.OriginalUrl == request.Url);
            if (existingUrl != null)
            {
                return existingUrl.Route;
            }

            existingUrl = new Domain.Entities.ShortUrl
            {
                OriginalUrl = request.Url,
                Clicks = 0
            };
            _context.ShortUrls.Add(existingUrl);

            existingUrl.Route = _urlShorteningService.ShortenUrl(existingUrl);

            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return existingUrl.Route;
        }
    }
}
