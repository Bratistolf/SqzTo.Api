using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsQueryHandler : IRequestHandler<GetSqzLinkDetailsQuery, GetSqzLinkDetailsDto>
    {
        private readonly ISqzToDbContext _context;

        public GetSqzLinkDetailsQueryHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<GetSqzLinkDetailsDto> Handle(GetSqzLinkDetailsQuery request, CancellationToken cancellationToken)
        {
            var sqzLink = await _context.SqzLinks.FirstOrDefaultAsync(link => link.Route == request.Route);

            var dto = new GetSqzLinkDetailsDto
            {
                Link = sqzLink.Route,
                Url = sqzLink.OriginalUrl,
                Clicks = sqzLink.Clicks,
                Created = sqzLink.Created.ToString()
            };

            return dto;
        }
    }
}
