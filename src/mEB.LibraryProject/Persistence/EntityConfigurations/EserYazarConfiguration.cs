using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EserYazarConfiguration : IEntityTypeConfiguration<EserYazar>
{
    public void Configure(EntityTypeBuilder<EserYazar> builder)
    {
        builder.ToTable("EserYazars").HasKey(ey => ey.Id);

        builder.Property(ey => ey.Id).HasColumnName("Id").IsRequired();
        builder.Property(ey => ey.EserId).HasColumnName("EserId").IsRequired();
        builder.Property(ey => ey.YazarId).HasColumnName("YazarId").IsRequired();
        builder.Property(ey => ey.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ey => ey.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ey => ey.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ey => ey.Eser);
        builder.HasOne(ey => ey.Yazar);
        
        builder.HasQueryFilter(ey => !ey.DeletedDate.HasValue);
    }
}