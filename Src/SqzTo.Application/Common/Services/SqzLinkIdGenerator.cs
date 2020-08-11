using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SqzTo.Domain.Entities;
using System;
using System.Diagnostics.CodeAnalysis;

namespace SqzTo.Application.Common.Services
{
    public class SqzLinkIdGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object NextValue([NotNull] EntityEntry entry)
        {
            var sqzLinkEntity = (SqzLinkEntity)entry.Entity;
            return sqzLinkEntity.Domain + "/" + sqzLinkEntity.Path;
        }
    }
}
