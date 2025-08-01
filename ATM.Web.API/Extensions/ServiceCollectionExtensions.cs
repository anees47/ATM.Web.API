using Microsoft.EntityFrameworkCore;
using ATM.Web.API.Data;

namespace ATM.Web.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddATMDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ATMDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        return services;
    }

    public static IServiceCollection RegisterATMServices(this IServiceCollection services)
    {
       
        

        return services;
    }
} 