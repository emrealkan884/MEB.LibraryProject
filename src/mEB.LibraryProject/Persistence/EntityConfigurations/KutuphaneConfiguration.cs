using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KutuphaneConfiguration : IEntityTypeConfiguration<Kutuphane>
{
    public void Configure(EntityTypeBuilder<Kutuphane> builder)
    {
        builder.ToTable("Kutuphaneler").HasKey(k => k.Id);

        builder.Property(k => k.Id).HasColumnName("Id").IsRequired();
        builder.Property(k => k.Adi).HasColumnName("Adi").IsRequired();
        builder.Property(k => k.Adres).HasColumnName("Adres").IsRequired();
        builder.Property(k => k.KurumTuru).HasColumnName("KurumTuru").IsRequired();
        builder.Property(k => k.UstKutuphaneId).HasColumnName("UstKutuphaneId");

        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        // Kutuphane -> Kopya
        builder.HasMany(k => k.Kopyalar)
            .WithOne(kp => kp.Kutuphane)
            .HasForeignKey(kp => kp.KutuphaneId)
            .OnDelete(DeleteBehavior.Cascade);

        // Kutuphane -> Konum
        builder.HasMany(k => k.Konumlar)
            .WithOne(kn => kn.Kutuphane)
            .HasForeignKey(kn => kn.KutuphaneId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(k => !k.DeletedDate.HasValue);
    }
}