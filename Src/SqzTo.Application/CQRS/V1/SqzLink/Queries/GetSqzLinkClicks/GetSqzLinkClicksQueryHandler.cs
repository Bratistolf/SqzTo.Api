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
            var route = request.SqzLink;

            var sqzLink = await _context.SqzLinks.FirstOrDefaultAsync(link => link.SqzLink == request.SqzLink);
            if (sqzLink == null)
            {
                throw new NotFoundException($"SqzLink with the route '{route}' is not found");
            }

            return new GetSqzLinkClicksDto { Clicks = sqzLink.Clicks };
        }
    }
}
