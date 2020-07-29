using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Infrastructure.Persistence
{
    public class SqzToDbContext : DbContext, ISqzToDbContext
    {
        public DbSet<SqzLink> ShortUrls { get; set; }

        public SqzToDbContext(DbContextOptions<SqzToDbContext> options) : base(options)
        {
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<SqzLink>())
            {
                //TODO: Proper state modifier...
                //entry.Entity.Created = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
