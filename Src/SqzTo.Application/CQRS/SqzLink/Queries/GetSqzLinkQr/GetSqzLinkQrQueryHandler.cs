using MediatR;
using SqzTo.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.SqzLink.Queries.GetSqzLinkQr
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
            throw new NotImplementedException();
        }
    }
}
