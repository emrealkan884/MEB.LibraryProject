using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KonumConfiguration : IEntityTypeConfiguration<Konum>
{
    public void Configure(EntityTypeBuilder<Konum> builder)
    {
        builder.ToTable("Konumlar").HasKey(k => k.Id);
        
        builder.Property(k => k.KutuphaneId).HasColumnName("KutuphaneId").IsRequired();
        builder.Property(k => k.UstKonumId).HasColumnName("UstKonumId");
        builder.Property(k => k.KonumTip).HasColumnName("KonumTip").IsRequired();
        builder.Property(k => k.Ad).HasColumnName("Ad").IsRequired();

        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(k => k.Kutuphane)
            .WithMany(kut => kut.Konumlar)
            .HasForeignKey(k => k.KutuphaneId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(k => k.UstKonum)
            .WithMany(k => k.AltKonumlar)
            .HasForeignKey(k => k.UstKonumId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Konum -> KopyaKonum
        builder.HasMany(k => k.Kopyalar)
            .WithOne(kk => kk.Konum)
            .HasForeignKey(kk => kk.KonumId);

        builder.HasQueryFilter(k => !k.DeletedDate.HasValue);
    }
}