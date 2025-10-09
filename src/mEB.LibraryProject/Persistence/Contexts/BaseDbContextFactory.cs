using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Persistence.Contexts;

// public class BaseDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
// {
// 	public BaseDbContext CreateDbContext(string[] args)
// 	{
// 		var basePath = Directory.GetCurrentDirectory();
// 		var configuration = new ConfigurationBuilder()
// 			.SetBasePath(basePath)
// 			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
// 			.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
// 			.AddEnvironmentVariables()
// 			.Build();
//
// 		var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();
// 		optionsBuilder.UseSqlServer(configuration.GetConnectionString("MEBLibrary"));
//
// 		return new BaseDbContext(optionsBuilder.Options, configuration);
// 	}
// }


