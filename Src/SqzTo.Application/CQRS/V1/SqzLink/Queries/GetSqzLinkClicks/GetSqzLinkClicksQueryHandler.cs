using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkClicks
{
    public class GetSqzLinkQrQueryHandler : IRequestHandler<GetSqzLinkClicksQuery, GetSqzLinkClicksDto>
    {
        private readonly ISqzToDbContext _context;

        public GetSqzLinkQrQueryHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<GetSqzLinkClicksDto> Handle(GetSqzLinkClicksQuery request, CancellationToken cancellationToken)
        {
            var sqzLink = request.SqzLink;

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.Domain + "%2F" + entity.Path == request.SqzLink);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLink}\" was not found.");
            }

            return new GetSqzLinkClicksDto { Clicks = sqzLinkEntity.Clicks };
        }
    }
}
