using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KopyaKonumConfiguration : IEntityTypeConfiguration<KopyaKonum>
{
    public void Configure(EntityTypeBuilder<KopyaKonum> builder)
    {
        builder.ToTable("KopyaKonums").HasKey(kk => kk.Id);

        builder.Property(kk => kk.Id).HasColumnName("Id").IsRequired();
        builder.Property(kk => kk.KopyaId).HasColumnName("KopyaId").IsRequired();
        builder.Property(kk => kk.KonumId).HasColumnName("KonumId").IsRequired();
        builder.Property(kk => kk.KutuphaneId).HasColumnName("KutuphaneId").IsRequired();
        builder.Property(kk => kk.Adet).HasColumnName("Adet").IsRequired();

        builder.Property(kk => kk.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(kk => kk.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(kk => kk.DeletedDate).HasColumnName("DeletedDate");

        // KopyaKonum -> Kopya
        builder.HasOne(kk => kk.Kopya)
            .WithMany(k => k.KopyaKonumlar)
            .HasForeignKey(kk => kk.KopyaId)
            .OnDelete(DeleteBehavior.Restrict);

        // KopyaKonum -> Konum
        builder.HasOne(kk => kk.Konum)
            .WithMany(kn => kn.KopyaKonumlar)
            .HasForeignKey(kk => kk.KonumId)
            .OnDelete(DeleteBehavior.Restrict);

        // KopyaKonum -> Kutuphane
        builder.HasOne(kk => kk.Kutuphane)
            .WithMany() // navigation koymadık
            .HasForeignKey(kk => kk.KutuphaneId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(kk => !kk.DeletedDate.HasValue);
    }
}