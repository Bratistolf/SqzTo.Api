using MediatR;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink
{
    public class CreateSqzLinkCommandHandler : IRequestHandler<CreateSqzLinkCommand, CreateSqzLinkDto>
    {
        private readonly ISqzToDbContext _context;
        private readonly IUrlShorteningService _urlShorteningService;

        public CreateSqzLinkCommandHandler(ISqzToDbContext context, IUrlShorteningService urlShorteningService)
        {
            _context = context;
            _urlShorteningService = urlShorteningService;
        }

        public async Task<CreateSqzLinkDto> Handle(CreateSqzLinkCommand request, CancellationToken cancellationToken)
        {
            var destinationUrl = request.DestinationUrl;
            var domain = request.Domain == string.Empty ? "bit.ly" : request.Domain;
            var path = _urlShorteningService.ShortenUrl(destinationUrl);

            var sqzLinkEntity = new Domain.Entities.SqzLinkEntity
            {
                DestinationUrl = destinationUrl,
                Domain = domain,
                Path = path
            };

            _context.SqzLinks.Add(sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new CreateSqzLinkDto { SqzLink = sqzLinkEntity.Domain + '/' + sqzLinkEntity.Path };
        }
    }
}
