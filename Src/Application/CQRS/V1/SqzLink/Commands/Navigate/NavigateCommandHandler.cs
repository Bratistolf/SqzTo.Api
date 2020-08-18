using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Navigate
{
    public class NavigateCommandHandler : IRequestHandler<NavigateRequest, NavigateResponse>
    {
        private readonly ISqzToDbContext _context;

        public NavigateCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<NavigateResponse> Handle(NavigateRequest request, CancellationToken cancellationToken)
        {
            var sqzLinkToFind = request.SqzLink.Replace("%2F", "/");

            var sqzLinkEntity = await _context.Set<SqzLinkEntity>().FirstOrDefaultAsync(entity => entity.SqzLink == sqzLinkToFind);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLinkToFind}\" was not found.");
            }

            sqzLinkEntity.Clicks++;

            _context.Set<SqzLinkEntity>().Update(sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new NavigateResponse { DestinationUrl = sqzLinkEntity.DestinationUrl };
        }
    }
}
