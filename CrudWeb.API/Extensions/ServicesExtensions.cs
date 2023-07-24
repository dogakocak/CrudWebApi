using Microsoft.EntityFrameworkCore;
using Repositories.Contexts;

namespace WebApplication3.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureMysqlContext(this IServiceCollection services, 
        IConfiguration configuration) => 
        services.AddDbContext<CrudDbContext>(options => 
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
        );
}