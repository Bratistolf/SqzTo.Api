using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqzTo.Domain.Entities;

namespace SqzTo.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Default configuration for the <see cref="SqzLink"/>.
    /// </summary>
    public class SqzLinkEntityConfiguration : IEntityTypeConfiguration<SqzLink>
    {
        public void Configure(EntityTypeBuilder<SqzLink> builder)
        {
            builder.ToTable("sqzlinks")
                   .HasKey(link => link.Id);

            builder.Property(link => link.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(link => link.Group)
                   .WithMany(group => group.SqzLinks)
                   .HasForeignKey(entity => entity.GroupId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(link => link.Domain)
                   .IsRequired()
                   .HasColumnName("domain");

            builder.Property(link => link.Key)
                   .IsRequired()
                   .HasColumnName("key");

            builder.Property(link => link.DestinationUrl)
                   .IsRequired()
                   .HasColumnName("destination_url");

            builder.Property(link => link.Description)
                   .HasMaxLength(256)
                   .HasColumnName("description");
        }
    }
}
