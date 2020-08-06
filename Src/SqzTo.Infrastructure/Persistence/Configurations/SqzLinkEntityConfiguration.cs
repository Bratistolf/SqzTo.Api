using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqzTo.Domain.Entities;

namespace SqzTo.Infrastructure.Persistence.Configurations
{
    public class SqzLinkEntityConfiguration : IEntityTypeConfiguration<SqzLinkEntity>
    {
        public void Configure(EntityTypeBuilder<SqzLinkEntity> builder)
        {
            builder.Property(entity => entity.Domain)
                .IsRequired()
                .HasColumnName("domain");

            builder.Property(entity => entity.Path)
                .IsRequired()
                .HasColumnName("path");

            builder.Property(entity => entity.DestinationUrl)
                .IsRequired()
                .HasColumnName("destination_url");

            builder.Property(entity => entity.Description)
                .HasMaxLength(120)
                .HasColumnName("description");
        }
    }
}
