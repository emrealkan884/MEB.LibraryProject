using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OduncConfiguration : IEntityTypeConfiguration<Odunc>
{
    public void Configure(EntityTypeBuilder<Odunc> builder)
    {
        builder.ToTable("Oduncs").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.KopyaId).HasColumnName("KopyaId").IsRequired();
        builder.Property(o => o.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(o => o.KutuphaneId).HasColumnName("KutuphaneId").IsRequired();
        builder.Property(o => o.OduncAlmaTarihi).HasColumnName("OduncAlmaTarihi").IsRequired();
        builder.Property(o => o.SonTeslimTarihi).HasColumnName("SonTeslimTarihi").IsRequired();
        builder.Property(o => o.GercekTeslimTarihi).HasColumnName("GercekTeslimTarihi");
        builder.Property(o => o.Durum).HasColumnName("Durum").IsRequired();

        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        // Odunc -> Kopya
        builder.HasOne(o => o.Kopya)
            .WithMany()
            .HasForeignKey(o => o.KopyaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Odunc -> Kullanici
        builder.HasOne(o => o.Kullanici)
            .WithMany(u => u.OduncKayitlari)
            .HasForeignKey(o => o.KullaniciId)
            .OnDelete(DeleteBehavior.Cascade);

        // Odunc -> Kutuphane (❌ Burada Cascade yerine Restrict kullanıyoruz)
        builder.HasOne(o => o.Kutuphane)
            .WithMany()
            .HasForeignKey(o => o.KutuphaneId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}