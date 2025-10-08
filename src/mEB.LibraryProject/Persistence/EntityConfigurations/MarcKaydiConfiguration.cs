using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MarcKaydiConfiguration : IEntityTypeConfiguration<MarcKaydi>
{
	public void Configure(EntityTypeBuilder<MarcKaydi> builder)
	{
		builder.ToTable("MarcKayitlari");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Isbn).HasMaxLength(32);
		builder.HasIndex(x => x.Isbn);
		builder.Property(x => x.Baslik).HasMaxLength(512);
	}
}


