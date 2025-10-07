using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapConfiguration:IEntityTypeConfiguration<Kitap>
{
    public void Configure(EntityTypeBuilder<Kitap> builder)
    {
        builder.ToTable("Kitaplar");
        //Ortak alanlar (Id, CreatedDate vs) de EserConfiguration'da zaten var
        
        builder.Property(k => k.BasimYili).HasColumnName("BasimYili").IsRequired();
        builder.Property(k => k.BasimYeri).HasColumnName("BasimYeri").IsRequired();
        builder.Property(k => k.BaskiBilgisi).HasColumnName("BaskiBilgisi");
        builder.Property(k => k.ISBN).HasColumnName("ISBN").IsRequired();
        builder.Property(k => k.SayfaSayisi).HasColumnName("SayfaSayisi");

        // Navigation
        builder.HasMany(k => k.KitaplarYayinEvleri)
            .WithOne(kye => kye.Kitap)
            .HasForeignKey(kye => kye.KitapId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(k => k.Kopyalar)// Kitabın birden fazla Kopyası vardır
            .WithOne(kp => kp.Kitap)//Kopyanın bir tane Kitabı vardır."
            .HasForeignKey(kp => kp.KitapId)//Kopya tablosundaki KitapId kolonunu foreign key olarak kullan.
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasQueryFilter(kk => !kk.DeletedDate.HasValue);//EserConfiguration da var
    }
}