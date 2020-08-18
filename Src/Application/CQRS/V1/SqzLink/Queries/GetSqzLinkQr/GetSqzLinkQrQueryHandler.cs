using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkQr
{
    public class GetSqzLinkQrQueryHandler : IRequestHandler<GetSqzLinkQrQuery, GetSqzLinkQrDto>
    {
        private readonly ISqzToDbContext _context;

        public GetSqzLinkQrQueryHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<GetSqzLinkQrDto> Handle(GetSqzLinkQrQuery request, CancellationToken cancellationToken)
        {
            var sqzLinkSplit = request.SqzLink.Split(new string[] { "%2F", "/" }, StringSplitOptions.None);
            var domain = sqzLinkSplit[0];
            var path = sqzLinkSplit[1];

            var sqzLinkEntity = await _context.Set<SqzLinkEntity>().FirstOrDefaultAsync(entity => entity.Domain == domain && entity.Key == path);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{domain + '/' + path}\" was not found.");
            }

            throw new NotImplementedException();
        }
    }
}
