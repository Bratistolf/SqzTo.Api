using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqzTo.Application.Common.Services;
using SqzTo.Domain.Entities;

namespace SqzTo.Infrastructure.Persistence.Configurations
{
    public class SqzLinkEntityConfiguration : IEntityTypeConfiguration<SqzLinkEntity>
    {
        public void Configure(EntityTypeBuilder<SqzLinkEntity> builder)
        {
            builder.ToTable("sqzlinks")
                .HasKey(enitiy => enitiy.SqzLink)
                .HasName("sqzlink");

            builder.Property(entity => entity.SqzLink)
                .IsRequired()
                .HasColumnName("sqzlink")
                .HasValueGenerator(typeof(SqzLinkIdGenerator));

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
