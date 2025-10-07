using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapYayinEviConfiguration: IEntityTypeConfiguration<KitapYayınEvi>
{
    public void Configure(EntityTypeBuilder<KitapYayınEvi> builder)
    {
        builder.ToTable("KitaplarYayinEvleri");
        builder.HasKey(kye => kye.Id);

        builder.Property(kye => kye.KitapId).IsRequired();
        builder.Property(kye => kye.YayinEviId).IsRequired();

        // 🔑 İlişkiler
        builder.HasOne(kye => kye.Kitap)
            .WithMany(k => k.KitaplarYayinEvleri)
            .HasForeignKey(kye => kye.KitapId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(kye => kye.YayinEvi)
            .WithMany(ye => ye.KitaplarYayinEvleri)
            .HasForeignKey(kye => kye.YayinEviId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasQueryFilter(ky => !ky.DeletedDate.HasValue);
    }
}