using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Eser> Eserler { get; set; }
    public DbSet<EserYazar> EserlerYazarlar { get; set; }
    public DbSet<Konum> Konumlar { get; set; }
    public DbSet<Kopya> Kopyalar { get; set; }
    public DbSet<KopyaKonum> KopyalarKonumlar { get; set; }
    public DbSet<Kutuphane> Kutuphaneler { get; set; }
    public DbSet<Odunc> Oduncler { get; set; }
    public DbSet<YayinEvi> YayinEvleri { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
