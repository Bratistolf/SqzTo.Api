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
    public class EditCommandHandler : IRequestHandler<EditCommand, Unit>
    {
        private readonly ISqzToDbContext _context;
        private readonly IMapper _mapper;

        public EditCommandHandler(ISqzToDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var sqzLinkToFind = request.SqzLink.Replace("%2F", "/");

            var sqzLink = await _context.Set<SqzLink>()
                                              .FirstOrDefaultAsync(entity => entity.Link == sqzLinkToFind);
            if (sqzLink is null)
                throw new NotFoundException($"SqzLink \"{sqzLinkToFind}\" was not found.");

            _mapper.Map(request, sqzLink);

            _context.Set<SqzLink>().Update(sqzLink);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
