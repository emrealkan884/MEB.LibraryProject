using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapConfiguration
{
    public void Configure(EntityTypeBuilder<Kitap> builder)
    {
        builder.ToTable("Kitap").HasKey(k => k.Id);

        builder.Property(k => k.Id).HasColumnName("Id").IsRequired();
        builder.Property(k => k.BasimYili).HasColumnName("BasimYili").IsRequired();
        builder.Property(k => k.BasimYeri).HasColumnName("BasimYeri").IsRequired();
        builder.Property(k => k.BaskiBilgisi).HasColumnName("BaskiBilgisi").IsRequired();
        builder.Property(k => k.ISBN).HasColumnName("ISBN").IsRequired();
        builder.Property(k => k.SayfaSayisi).HasColumnName("SayfaSayisi").IsRequired();
        builder.Property(k => k.YayinEviId).HasColumnName("YayinEviId").IsRequired();
        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(k => k.Kopyalar);
        builder.HasMany(k => k.KitapYayınEvleri);


        builder.HasQueryFilter(kk => !kk.DeletedDate.HasValue);
    }
}