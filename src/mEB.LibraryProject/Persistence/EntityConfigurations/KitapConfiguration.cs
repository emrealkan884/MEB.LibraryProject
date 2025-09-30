using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapConfiguration:IEntityTypeConfiguration<Kitap>
{
    public void Configure(EntityTypeBuilder<Kitap> builder)
    {
        builder.ToTable("Kitaps");
        //Ortak alanlar (Id, CreatedDate vs) de EserConfiguration'da zaten var
        
        builder.Property(k => k.BasimYili).HasColumnName("BasimYili").IsRequired();
        builder.Property(k => k.BasimYeri).HasColumnName("BasimYeri").IsRequired();
        builder.Property(k => k.BaskiBilgisi).HasColumnName("BaskiBilgisi").IsRequired();
        builder.Property(k => k.ISBN).HasColumnName("ISBN").IsRequired();
        builder.Property(k => k.SayfaSayisi).HasColumnName("SayfaSayisi").IsRequired();

        builder.HasMany(k => k.KitapsYayinEvis)
            .WithOne(kye => kye.Kitap)
            .HasForeignKey(kye => kye.KitapId);

        builder.HasMany(k => k.Kopyalar)
            .WithOne(k => k.Kitap)
            .HasForeignKey(k => k.KitapId);
        
        //builder.HasQueryFilter(kk => !kk.DeletedDate.HasValue);//EserConfiguration da var
    }
}