using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DijitalIcerikConfiguration : IEntityTypeConfiguration<DijitalIcerik>
{
	public void Configure(EntityTypeBuilder<DijitalIcerik> builder)
	{
		builder.ToTable("DijitalIcerikler");
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Tur).IsRequired().HasMaxLength(32);
		builder.Property(x => x.Url).IsRequired().HasMaxLength(1024);
	}
}


