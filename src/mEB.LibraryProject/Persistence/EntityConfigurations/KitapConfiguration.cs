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
        // Edition-specific properties are modeled in KitapBaski

        // Navigation
        builder.HasMany(k => k.Baskilar)
            .WithOne(b => b.Kitap)
            .HasForeignKey(b => b.KitapId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasQueryFilter(kk => !kk.DeletedDate.HasValue);//EserConfiguration da var
    }
}