using MediatR;
using SqzTo.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQS.ShortUrl.Commands.NavigateToUrl
{
    public class NavigateToCommandHandler : IRequestHandler<NavigateToCommand, string>
    {
        private readonly ISqzToDbContext _context;

        public NavigateToCommandHandler(ISqzToDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(NavigateToCommand request, CancellationToken cancellationToken)
        {
            return "https://natribu.org/en/";
        }
    }
}
