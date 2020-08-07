using MediatR;
using SqzTo.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.EditDestinationUrl
{
    public class EditDestinationUrlCommandHandler : IRequestHandler<EditDestinationUrlCommand, Unit>
    {
        private readonly ISqzToDbContext _sqzToDbContext;

        public EditDestinationUrlCommandHandler(ISqzToDbContext sqzToDbContext)
        {
            _sqzToDbContext = sqzToDbContext;
        }

        public Task<Unit> Handle(EditDestinationUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
