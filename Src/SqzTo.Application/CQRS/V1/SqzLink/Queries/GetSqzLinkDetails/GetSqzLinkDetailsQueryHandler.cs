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
            var sqzLinkSplit = request.SqzLink.Split(new string[] { "%2F", "/" }, StringSplitOptions.None);
            var domain = sqzLinkSplit[0];
            var path = sqzLinkSplit[1];

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.Domain == domain && entity.Path == path);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{domain + '/' + path}\" was not found.");
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
