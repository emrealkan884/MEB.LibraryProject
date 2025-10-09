using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EserConfiguration : IEntityTypeConfiguration<Eser>
{
    public void Configure(EntityTypeBuilder<Eser> builder)
    {
        builder.ToTable("Eserler").HasKey(e => e.Id);

        builder.Property(e => e.Adi).HasColumnName("Adi").IsRequired();
        builder.Property(e => e.DilKodu).HasColumnName("DilKodu").IsRequired();
        builder.Property(e => e.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(e => e.DeweyKodu).HasColumnName("DeweyKodu");
        builder.Property(e => e.MarcVerisi).HasColumnName("MarcVerisi");
        builder.Property(e => e.EserTipi).HasColumnName("EserTipi").IsRequired().HasConversion<int>();
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(e => e.Kategori).HasColumnName("Kategori").IsRequired().HasConversion<int>();


        builder.HasMany(e => e.Yazarlar)
            .WithOne(ey => ey.Eser)
            .HasForeignKey(ey => ey.EserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue); //Soft delete yapılmış kayıtları otomatik gizle.

        #region Restrict ve Cascade farkı

        //Bir Kitap silinirse (Cascade): bağlı Kopyalar, KitapYayinEvleri de DeletedDate alır.
        //Bir Kopya silinirse (Restrict): Odunc kayıtları silinmez (geçmiş ödünç bilgisi korunur).

        #endregion
    }
}