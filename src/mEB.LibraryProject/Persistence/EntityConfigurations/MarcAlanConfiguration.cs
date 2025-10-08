using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MarcAlanConfiguration : IEntityTypeConfiguration<MarcAlan>
{
	public void Configure(EntityTypeBuilder<MarcAlan> builder)
	{
		builder.ToTable("MarcAlanlar");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Tag).IsRequired().HasMaxLength(10);
		builder.Property(x => x.Deger).IsRequired();
		builder.HasOne(x => x.MarcKaydi)
			.WithMany(y => y.Alanlar)
			.HasForeignKey(x => x.MarcKaydiId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasIndex(x => new { x.MarcKaydiId, x.Tag });
	}
}


