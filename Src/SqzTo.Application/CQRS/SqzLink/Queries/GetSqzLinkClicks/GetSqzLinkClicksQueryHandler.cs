using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkClicks
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
            var sqzLink = await _context.SqzLinks.FirstOrDefaultAsync(link => link.Route == request.Route);
            return new GetSqzLinkClicksDto { Clicks = sqzLink.Clicks };
        }
    }
}
