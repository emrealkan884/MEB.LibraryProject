using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EserConfiguration : IEntityTypeConfiguration<Eser>
{
    public void Configure(EntityTypeBuilder<Eser> builder)
    {
        builder.ToTable("Esers").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Adi).HasColumnName("Adi").IsRequired();
        builder.Property(e => e.DilKodu).HasColumnName("DilKodu").IsRequired();
        builder.Property(e => e.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(e => e.DeweyKodu).HasColumnName("DeweyKodu");
        builder.Property(e => e.MarcVerisi).HasColumnName("MarcVerisi");
        builder.Property(e => e.EserTipi).HasColumnName("EserTipi").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        
        builder.HasMany(e => e.EserYazarlar);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}