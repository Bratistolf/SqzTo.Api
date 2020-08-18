using AutoMapper;
using MediatR;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Create
{
    /// <summary>
    /// Defines a handler for the <see cref="CreateRequest"/>.
    /// </summary>
    public class CreateRequestHandler : IRequestHandler<CreateRequest, CreateResponse>
    {
        private readonly ISqzToDbContext _context;
        private readonly IUrlShorteningService _urlShorteningService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">DbContext used for database manipulations.</param>
        /// <param name="urlShorteningService"></param>
        /// <param name="mapper"></param>
        public CreateRequestHandler(ISqzToDbContext context, IUrlShorteningService urlShorteningService, IMapper mapper)
        {
            _context = context;
            _urlShorteningService = urlShorteningService;
            _mapper = mapper;
        }

        public async Task<CreateResponse> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var sqzLinkEntity = _mapper.Map<SqzLinkEntity>(request);
            sqzLinkEntity.Key = _urlShorteningService.ShortenUrl(request.DestinationUrl);

            _context.Set<SqzLinkEntity>().Add(sqzLinkEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateResponse { SqzLink = sqzLinkEntity.SqzLink };
        }
    }
}
