using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KitapYayinEviConfiguration: IEntityTypeConfiguration<KitapYayinEvi>
{
    public void Configure(EntityTypeBuilder<KitapYayinEvi> builder)
    {
        builder.ToTable("KitaplarYayinEvleri");
        builder.HasKey(kye => kye.Id);

        builder.Property(kye => kye.KitapId).IsRequired();
        builder.Property(kye => kye.YayinEviId).IsRequired();

        // Legacy join entity kept for backward compatibility; new model uses KitapBaski.YayinEviId
    }
}