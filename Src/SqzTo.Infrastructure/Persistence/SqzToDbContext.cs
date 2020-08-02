﻿using Microsoft.EntityFrameworkCore;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SqzTo.Infrastructure.Persistence
{
    public class SqzToDbContext : DbContext, ISqzToDbContext
    {
        public DbSet<SqzLinkEntity> SqzLinks { get; set; }

        public SqzToDbContext(DbContextOptions<SqzToDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<SqzLinkEntity>())
            {
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
