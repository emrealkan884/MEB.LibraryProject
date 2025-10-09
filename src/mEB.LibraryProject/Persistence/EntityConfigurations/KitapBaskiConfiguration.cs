using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapBaskiConfiguration : IEntityTypeConfiguration<KitapBaski>
{
    public void Configure(EntityTypeBuilder<KitapBaski> builder)
    {
        builder.ToTable("KitapBaskilari");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Isbn).HasMaxLength(32).IsRequired();
        builder.Property(x => x.BasimYeri).HasMaxLength(128);
        builder.Property(x => x.BaskiBilgisi).HasMaxLength(64);
        builder.Property(x => x.SayfaSayisi).HasMaxLength(16);

        builder.HasIndex(x => x.Isbn).IsUnique();
        builder.HasIndex(x => new { x.KitapId, x.YayinEviId, x.BaskiBilgisi, x.CiltTipi }).IsUnique();

        builder.HasOne(x => x.Kitap)
            .WithMany(k => k.Baskilar)
            .HasForeignKey(x => x.KitapId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.YayinEvi)
            .WithMany()
            .HasForeignKey(x => x.YayinEviId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


