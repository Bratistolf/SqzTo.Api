using MediatR;
using SqzTo.Application.Common.Interfaces;
using System;
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
            var sqzLink = _urlShorteningService.ShortenUrl(destinationUrl);

            var sqzLinkEntity = new Domain.Entities.SqzLinkEntity
            {
                DestinationUrl = destinationUrl,
                SqzLink = sqzLink,
                Created = DateTime.UtcNow,
                Clicks = 0
            };

            _context.SqzLinks.Add(sqzLinkEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateSqzLinkDto { SqzLink = sqzLinkEntity.SqzLink };
        }
    }
}
