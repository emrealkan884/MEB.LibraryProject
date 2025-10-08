using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Application.Services.Repositories;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MEBLibrary")));
        // Map DbContext to BaseDbContext so handlers injecting DbContext resolve properly
        services.AddScoped<DbContext>(sp => sp.GetRequiredService<BaseDbContext>());
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());


        services.AddScoped<IEserRepository, EserRepository>();
        services.AddScoped<IEserYazarRepository, EserYazarRepository>();
        services.AddScoped<IKonumRepository, KonumRepository>();
        services.AddScoped<IKopyaRepository, KopyaRepository>();
        services.AddScoped<IKopyaKonumRepository, KopyaKonumRepository>();
        services.AddScoped<IKopyaBirimRepository, KopyaBirimRepository>();
        services.AddScoped<IKutuphaneRepository, KutuphaneRepository>();
        services.AddScoped<IOduncRepository, OduncRepository>();
        services.AddScoped<IYayinEviRepository, YayinEviRepository>();
        services.AddScoped<IYazarRepository, YazarRepository>();
        services.AddScoped<IKitapRepository, KitapRepository>();
        return services;
    }
}
