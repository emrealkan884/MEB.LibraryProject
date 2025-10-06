using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KonumConfiguration : IEntityTypeConfiguration<Konum>
{
    public void Configure(EntityTypeBuilder<Konum> builder)
    {
        builder.ToTable("Konums").HasKey(k => k.Id);

        builder.Property(k => k.Id).HasColumnName("Id").IsRequired();
        builder.Property(k => k.KutuphaneId).HasColumnName("KutuphaneId").IsRequired();
        builder.Property(k => k.UstKonumId).HasColumnName("UstKonumId");
        builder.Property(k => k.KonumTip).HasColumnName("KonumTip").IsRequired();
        builder.Property(k => k.Ad).HasColumnName("Ad").IsRequired();

        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        // Konum -> AltKonum
        builder.HasMany(k => k.AltKonumlar)
            .WithOne(k => k.UstKonum)
            .HasForeignKey(k => k.UstKonumId)
            .OnDelete(DeleteBehavior.Restrict);

        // Konum -> KopyaKonum
        builder.HasMany(k => k.KopyaKonumlar)
            .WithOne(kk => kk.Konum)
            .HasForeignKey(kk => kk.KonumId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(k => !k.DeletedDate.HasValue);
    }
}