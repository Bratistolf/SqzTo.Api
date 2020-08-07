using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.EditDescription
{
    public class EditDescriptionCommandHandler : IRequestHandler<EditDescriptionCommand>
    {
        private readonly ISqzToDbContext _sqzToDbContext;

        public EditDescriptionCommandHandler(ISqzToDbContext sqzToDbContext)
        {
            _sqzToDbContext = sqzToDbContext;
        }

        public async Task<Unit> Handle(EditDescriptionCommand request, CancellationToken cancellationToken)
        {
            var sqzLink = request.SqzLink;
            var description = request.Description;

            var sqzLinkEntity = await _sqzToDbContext.SqzLinks.FirstOrDefaultAsync(link => link.Domain == sqzLink);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException();
            }

            sqzLinkEntity.Description = description;
            _sqzToDbContext.SqzLinks.Update(sqzLinkEntity);
            var savingResult = await _sqzToDbContext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
