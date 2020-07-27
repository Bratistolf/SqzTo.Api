using MediatR;
using SqzTo.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQS.ShortUrl.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, string>
    {
        private readonly ISqzToDbContext _context;

        public CreateShortUrlCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            return "TOSSBMMS";
        }
    }
}
