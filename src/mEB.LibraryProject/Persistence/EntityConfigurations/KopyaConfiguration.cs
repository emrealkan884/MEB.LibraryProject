using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KopyaConfiguration : IEntityTypeConfiguration<Kopya>
{
    public void Configure(EntityTypeBuilder<Kopya> builder)
    {
        builder.ToTable("Kopyalar").HasKey(k => k.Id);
        
        builder.Property(k => k.KitapBaskiId).HasColumnName("KitapBaskiId").IsRequired();
        builder.Property(k => k.KutuphaneId).HasColumnName("KutuphaneId").IsRequired();
        builder.Property(k => k.Barkod).HasColumnName("Barkod").IsRequired();

        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        // Kopya -> KitapBaski
        builder.HasOne(k => k.KitapBaski)
            .WithMany()
            .HasForeignKey(k => k.KitapBaskiId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(k => k.Kutuphane)
            .WithMany(kut => kut.Kopyalar)
            .HasForeignKey(k => k.KutuphaneId)
            .OnDelete(DeleteBehavior.Restrict);

        // Kopya -> KopyaKonum
        builder.HasMany(k => k.Konumlar)
            .WithOne(kk => kk.Kopya)
            .HasForeignKey(kk => kk.KopyaId);

        builder.HasQueryFilter(k => !k.DeletedDate.HasValue);
    }
}