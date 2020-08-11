using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditRequest, Unit>
    {
        private readonly ISqzToDbContext _context;
        private readonly IMapper _mapper;

        public EditCommandHandler(ISqzToDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditRequest request, CancellationToken cancellationToken)
        {
            var sqzLinkToFind = request.SqzLink;
            sqzLinkToFind.Replace("%2F", "/");

            var requestBody = request.Body;

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.SqzLink == sqzLinkToFind);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{sqzLinkToFind}\" was not found.");
            }

            _mapper.Map(requestBody, sqzLinkEntity);

            _context.SqzLinks.Update(sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
