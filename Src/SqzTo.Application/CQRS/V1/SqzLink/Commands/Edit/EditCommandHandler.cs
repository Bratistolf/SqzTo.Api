using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Edit
{
    public class EditCommandHandler : IRequestHandler<EditCommand, Unit>
    {
        private readonly ISqzToDbContext _context;

        public EditCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var sqzLinkSplit = request.SqzLink.Split(new string[] { "%2F", "/" }, System.StringSplitOptions.None);
            var domain = sqzLinkSplit[0];
            var path = sqzLinkSplit[1];

            var sqzLinkEntity = await _context.SqzLinks.FirstOrDefaultAsync(entity => entity.Domain == domain && entity.Path == path);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{domain + '/' + path}\" was not found.");
            }

            foreach (var property in request.PropertiesToPatch)
            {
                var entityProperty = typeof(SqzLinkEntity).GetProperty(property.Property);
                if (entityProperty == null)
                {
                    throw new NotFoundException();
                }
                entityProperty.SetValue(sqzLinkEntity, property.Value);
            }

            _context.SqzLinks.Update(sqzLinkEntity);
            var savingResult = await _context.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
