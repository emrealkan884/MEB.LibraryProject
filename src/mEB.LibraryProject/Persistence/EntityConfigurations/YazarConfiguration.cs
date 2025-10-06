using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class YazarConfiguration : IEntityTypeConfiguration<Yazar>
{
    public void Configure(EntityTypeBuilder<Yazar> builder)
    {
        builder.ToTable("Yazars").HasKey(y => y.Id);

        builder.Property(y => y.Id).HasColumnName("Id").IsRequired();
        builder.Property(y => y.Adi).HasColumnName("Adi").IsRequired();
        builder.Property(y => y.Soyadi).HasColumnName("Soyadi").IsRequired();
        builder.Property(y => y.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(y => y.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(y => y.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(e => e.EserYazarlar);

        builder.HasQueryFilter(y => !y.DeletedDate.HasValue);
    }
}