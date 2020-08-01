using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkDetails
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
            var route = request.Link;

            var sqzLink = await _context.SqzLinks.FirstOrDefaultAsync(link => link.SqzLink == route);
            if (sqzLink == null)
            {
                throw new NotFoundException($"SqzLink with the route '{route}' is not found");
            }

            var dto = new GetSqzLinkDetailsDto
            {
                Link = sqzLink.SqzLink,
                Url = sqzLink.DestinationUrl,
                Clicks = sqzLink.Clicks,
                Created = sqzLink.Created.ToString()
            };

            return dto;
        }
    }
}
