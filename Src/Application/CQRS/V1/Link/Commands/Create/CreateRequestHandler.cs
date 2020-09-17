using AutoMapper;
using MediatR;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Create
{
    /// <summary>
    /// Defines a handler for the <see cref="CreateCommand"/>.
    /// </summary>
    public class CreateRequestHandler : IRequestHandler<CreateCommand, SqzLinkDto>
    {
        private readonly ISqzToDbContext _context;
        private readonly IUrlShorteningService _urlShorteningService;
        private readonly IMapper _mapper;

        public CreateRequestHandler(ISqzToDbContext context, IUrlShorteningService urlShorteningService, IMapper mapper)
        {
            _context = context;
            _urlShorteningService = urlShorteningService;
            _mapper = mapper;
        }

        public async Task<SqzLinkDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var sqzLinkEntity = _mapper.Map<SqzLink>(request);
            sqzLinkEntity.Key = _urlShorteningService.ShortenUrl(request.DestinationUrl);

            _context.Set<SqzLink>().Add(sqzLinkEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return new SqzLinkDto { SqzLink = sqzLinkEntity.Link };
        }
    }
}
