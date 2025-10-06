using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KopyaConfiguration : IEntityTypeConfiguration<Kopya>
{
    public void Configure(EntityTypeBuilder<Kopya> builder)
    {
        builder.ToTable("Kopyas").HasKey(k => k.Id);

        builder.Property(k => k.Id).HasColumnName("Id").IsRequired();
        builder.Property(k => k.KitapId).HasColumnName("KitapId").IsRequired();
        builder.Property(k => k.KutuphaneId).HasColumnName("KutuphaneId").IsRequired();
        builder.Property(k => k.Barkod).HasColumnName("Barkod").IsRequired();

        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        // Kopya -> Kitap
        builder.HasOne(k => k.Kitap)
            .WithMany(kp => kp.Kopyalar)
            .HasForeignKey(k => k.KitapId)
            .OnDelete(DeleteBehavior.Cascade);

        // Kopya -> KopyaKonum
        builder.HasMany(k => k.KopyaKonumlar)
            .WithOne(kk => kk.Kopya)
            .HasForeignKey(kk => kk.KopyaId)
            .OnDelete(DeleteBehavior.Restrict); // 🔑 cycle engellendi

        builder.HasQueryFilter(k => !k.DeletedDate.HasValue);
    }
}