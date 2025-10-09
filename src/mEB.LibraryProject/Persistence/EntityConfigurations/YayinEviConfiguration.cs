using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class YayinEviConfiguration : IEntityTypeConfiguration<YayinEvi>
{
    public void Configure(EntityTypeBuilder<YayinEvi> builder)
    {
        builder.ToTable("YayinEvleri").HasKey(ye => ye.Id);

        builder.Property(ye => ye.Id).HasColumnName("Id").IsRequired();
        builder.Property(ye => ye.Adi).HasColumnName("Adi").IsRequired();
        builder.Property(ye => ye.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ye => ye.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ye => ye.DeletedDate).HasColumnName("DeletedDate");
        // Legacy KitapYayinEvi ilişkisi kaldırıldı; baskı düzeyinde YayinEvi referansı var

        builder.HasQueryFilter(ye => !ye.DeletedDate.HasValue);
    }
}