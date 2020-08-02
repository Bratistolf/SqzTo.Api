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
            var sqzLink = request.SqzLink;

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.Domain + '/' + entity.Path == sqzLink);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLink}\" was not found.");
            }

            var dto = new GetSqzLinkDetailsDto
            {
                Link = sqzLinkEntity.Domain + '/' + sqzLinkEntity.Path,
                Url = sqzLinkEntity.DestinationUrl,
                Clicks = sqzLinkEntity.Clicks,
                Created = sqzLinkEntity.Created.ToString()
            };

            return dto;
        }
    }
}
