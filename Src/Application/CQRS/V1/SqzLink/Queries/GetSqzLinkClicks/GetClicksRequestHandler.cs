using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Exceptions;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetClicks
{
    public class GetClicksRequestHandler : IRequestHandler<GetClicksRequest, GetClicksResponce>
    {
        private readonly ISqzToDbContext _context;
        private readonly IMapper _mapper;

        public GetClicksRequestHandler(ISqzToDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>TODO...</remarks>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Thrown when SqzLink is not found</exception>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public async Task<GetClicksResponce> Handle(GetClicksRequest request, CancellationToken cancellationToken)
        {
            var sqzLinkSplit = request.SqzLink.Split(new string[] { "%2F", "/" }, System.StringSplitOptions.None);
            var domain = sqzLinkSplit[0];
            var path = sqzLinkSplit[1];

            var sqzLinkEntity = await _context.Set<SqzLinkEntity>().FirstOrDefaultAsync(entity => entity.Domain == domain && entity.Key == path);
            if (sqzLinkEntity == null)
            {
                throw new NotFoundException($"SqzLink \"{domain + '/' + path}\" was not found.");
            }

            var getClicksResponce = _mapper.Map<GetClicksResponce>(sqzLinkEntity);
            return getClicksResponce;
        }
    }
}
