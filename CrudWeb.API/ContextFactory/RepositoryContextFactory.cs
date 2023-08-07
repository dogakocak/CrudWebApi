using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.Contexts;

namespace WebApplication3.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<CrudDbContext>
{
    public CrudDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<CrudDbContext>()
            .UseMySQL(configuration.GetConnectionString("DefaultConnection"),
                prj => prj.MigrationsAssembly("CrudWeb.API")
                );

        return new CrudDbContext(builder.Options);
    }
}