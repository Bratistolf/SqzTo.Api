using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Create
{
    public class CreateRequestHandler : IRequestHandler<CreateRequest, CreateResponce>
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

        public async Task<CreateResponce> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var destinationUrl = request.DestinationUrl;
            var domain = request.Domain == string.Empty ? "sqz.to" : request.Domain;
            var path = _urlShorteningService.ShortenUrl(destinationUrl);

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(link => link.SqzLink == domain + '/' + path);
            if (sqzLinkEntity != null)
            {
                throw new NotImplementedException();
            }

            sqzLinkEntity = _mapper.Map<SqzLinkEntity>(request);
            sqzLinkEntity.Path = path;

            _context.SqzLinks.Add(sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            var savedSqzLink = await _context.SqzLinks.FindAsync(sqzLinkEntity);

            return new CreateResponce { SqzLink = savedSqzLink.SqzLink };
        }
    }
}
