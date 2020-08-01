using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.NavigateSqzLink
{
    public class NavigateSqzLinkCommandHandler : IRequestHandler<NavigateSqzLinkCommand, NavigateSqzLinkDto>
    {
        private readonly ISqzToDbContext _context;

        public NavigateSqzLinkCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<NavigateSqzLinkDto> Handle(NavigateSqzLinkCommand request, CancellationToken cancellationToken)
        {
            var route = request.Link;

            var existingUrl = await _context.SqzLinks.FirstOrDefaultAsync(url => url.SqzLink == route);
            if (existingUrl == null)
            {
                throw new NotFoundException($"SqzLink with the route '{route}' is not found");
            }

            existingUrl.Clicks++;
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new NavigateSqzLinkDto { Url = existingUrl.DestinationUrl };
        }
    }
}
