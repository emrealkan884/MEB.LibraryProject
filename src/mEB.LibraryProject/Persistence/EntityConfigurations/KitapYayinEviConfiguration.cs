using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapYayinEviConfiguration: IEntityTypeConfiguration<KitapYayınEvi>
{
    public void Configure(EntityTypeBuilder<KitapYayınEvi> builder)
    {
        builder.ToTable("KitapsYayinEvis");

        builder.HasKey(kye => kye.Id);

        builder.Property(kye => kye.KitapId).IsRequired();
        builder.Property(kye => kye.YayinEviId).IsRequired();

        // 🔑 İlişkiler
        builder.HasOne(kye => kye.Kitap)
            .WithMany(k => k.KitapsYayinEvis)
            .HasForeignKey(kye => kye.KitapId)
            .IsRequired(false); // Buraya ekliyorsun

        builder.HasOne(kye => kye.YayinEvi)
            .WithMany(y => y.KitapsYayinEvis)
            .HasForeignKey(kye => kye.YayinEviId)
            .IsRequired(false);
    }
}