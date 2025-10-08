using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DeweySiniflamaConfiguration : IEntityTypeConfiguration<DeweySiniflama>
{
	public void Configure(EntityTypeBuilder<DeweySiniflama> builder)
	{
		builder.ToTable("DeweySiniflamalar");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Kod).IsRequired().HasMaxLength(32);
		builder.Property(x => x.Ad).IsRequired().HasMaxLength(256);
		builder.HasIndex(x => x.Kod).IsUnique();
	}
}


