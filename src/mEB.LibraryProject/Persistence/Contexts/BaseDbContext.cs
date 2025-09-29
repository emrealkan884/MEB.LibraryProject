using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Eser> Esers { get; set; }
    public DbSet<EserYazar> EserYazars { get; set; }
    public DbSet<Konum> Konums { get; set; }
    public DbSet<Kopya> Kopyas { get; set; }
    public DbSet<KopyaKonum> KopyaKonums { get; set; }
    public DbSet<Kutuphane> Kutuphanes { get; set; }
    public DbSet<Odunc> Oduncs { get; set; }
    public DbSet<Rezerve> Rezerves { get; set; }
    public DbSet<YayinEvi> YayinEvis { get; set; }
    public DbSet<Yazar> Yazars { get; set; }
    public DbSet<Kitap> Kitaps { get; set; }

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
