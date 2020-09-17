using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SqzTo.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace SqzTo.Application.Common.Services
{
    /// <inheritdoc/>
    public class SqzLinkGenerator : ValueGenerator
    {
        /// <inheritdoc/>
        public override bool GeneratesTemporaryValues => false;

        /// <summary>
        /// Generates the new value for a 'sqzlink' field.
        /// </summary>
        /// <param name="entry">Entity entry.</param>
        /// <returns>Generated value.</returns>
        protected override object NextValue([NotNull] EntityEntry entry)
        {
            var sqzLinkEntity = entry.Entity as SqzLink;
            return sqzLinkEntity.Domain + "/" + sqzLinkEntity.Key;
        }
    }
}
