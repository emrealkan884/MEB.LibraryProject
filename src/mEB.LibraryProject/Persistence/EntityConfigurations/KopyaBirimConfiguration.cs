using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KopyaBirimConfiguration : IEntityTypeConfiguration<KopyaBirim>
{
	public void Configure(EntityTypeBuilder<KopyaBirim> builder)
	{
		builder.ToTable("KopyaBirimler");
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Barkod).IsRequired().HasMaxLength(64);
		builder.HasIndex(x => x.Barkod).IsUnique();
		builder.Property(x => x.RafSira).IsRequired();
		builder.Property(x => x.Durum).IsRequired();

		builder.HasOne(x => x.Kopya)
			.WithMany()
			.HasForeignKey(x => x.KopyaId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Kutuphane)
			.WithMany()
			.HasForeignKey(x => x.KutuphaneId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Konum)
			.WithMany()
			.HasForeignKey(x => x.KonumId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(x => new { x.KonumId, x.RafSira }).IsUnique();
	}
}


