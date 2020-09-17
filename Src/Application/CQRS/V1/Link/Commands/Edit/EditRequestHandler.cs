using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Edit
{
    public class EditRequestHandler : IRequestHandler<EditRequest, Unit>
    {
        private readonly ISqzToDbContext _context;
        private readonly IMapper _mapper;

        public EditRequestHandler(ISqzToDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditRequest request, CancellationToken cancellationToken)
        {
            var sqzLinkToFind = request.SqzLink.Replace("%2F", "/");

            var requestBody = request.Body;

            var sqzLinkEntity = await _context.Set<SqzLink>().FirstOrDefaultAsync(entity => entity.Link == sqzLinkToFind);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLinkToFind}\" was not found.");
            }

            _mapper.Map(requestBody, sqzLinkEntity);

            _context.Set<Domain.Entities.SqzLink>().Update((Domain.Entities.SqzLink)sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
