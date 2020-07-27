using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQS.ShortUrl.Commands.NavigateToUrl
{
    public class NavigateToCommandHandler : IRequestHandler<NavigateToCommand, string>
    {
        private readonly ISqzToDbContext _context;

        public NavigateToCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(NavigateToCommand request, CancellationToken cancellationToken)
        {
            var existingUrl = await _context.ShortUrls.FirstOrDefaultAsync(url => url.Route == request.Route);
            if (existingUrl == null)
            {
                throw new NotFoundException();
            }

            existingUrl.Clicks++;
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return existingUrl.OriginalUrl;
        }
    }
}
