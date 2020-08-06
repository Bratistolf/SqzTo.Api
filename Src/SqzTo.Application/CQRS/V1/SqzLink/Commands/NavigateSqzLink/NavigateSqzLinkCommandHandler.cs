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
            var sqzLink = request.SqzLink;

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => (entity.Domain + "%2F" + entity.Path) == sqzLink);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLink}\" was not found.");
            }

            sqzLinkEntity.Clicks++;
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new NavigateSqzLinkDto { DestinationUrl = sqzLinkEntity.DestinationUrl };
        }
    }
}
