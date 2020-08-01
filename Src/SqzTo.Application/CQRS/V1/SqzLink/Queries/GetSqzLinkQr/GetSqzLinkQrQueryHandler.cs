using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
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
            var route = request.Link;

            var sqzLink = await _context.SqzLinks.FirstOrDefaultAsync(link => link.SqzLink == route);
            if (sqzLink == null)
            {
                throw new NotFoundException($"SqzLink with the route '{route}' is not found");
            }

            throw new NotImplementedException();
        }
    }
}
