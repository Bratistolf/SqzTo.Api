using Microsoft.EntityFrameworkCore;
using SqzTo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Application.Common
{
    public interface ISqzToDbContext
    {
        DbSet<ShortUrl> ShortUrls { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
