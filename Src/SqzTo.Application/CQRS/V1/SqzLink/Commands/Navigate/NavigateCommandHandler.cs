using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Navigate
{
    public class NavigateCommandHandler : IRequestHandler<NavigateCommand, NavigateDto>
    {
        private readonly ISqzToDbContext _context;

        public NavigateCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<NavigateDto> Handle(NavigateCommand request, CancellationToken cancellationToken)
        {
            var sqzLinkToFind = request.SqzLink;
            sqzLinkToFind.Replace("%2F", "/");

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.SqzLink == sqzLinkToFind);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLinkToFind}\" was not found.");
            }

            sqzLinkEntity.Clicks++;

            _context.SqzLinks.Update(sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new NavigateDto { DestinationUrl = sqzLinkEntity.DestinationUrl };
        }
    }
}
