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
            var sqzLinkSplit = request.SqzLink.Split(new string[] { "%2F", "/" }, System.StringSplitOptions.None);
            var domain = sqzLinkSplit[0];
            var path = sqzLinkSplit[1];

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.Domain == domain && entity.Path == path);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{domain + '/' + path}\" was not found.");
            }

            return new GetSqzLinkClicksDto { Clicks = sqzLinkEntity.Clicks };
        }
    }
}
