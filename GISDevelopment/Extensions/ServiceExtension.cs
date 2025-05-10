using GISDevelopment.Abstractions;
using GISDevelopment.Data;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;
using GISDevelopment.Services;
using Microsoft.EntityFrameworkCore;

namespace GISDevelopment.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(conf =>
        {
            conf.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                o => o.UseNetTopologySuite());
        });
        services.AddDbContext<ItalyCentreContext>(conf =>
        {
            conf.UseNpgsql(configuration.GetConnectionString("ItalyCentreConnection"),
                o => o.UseNetTopologySuite());
        });
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMunicipalityService, MunicipalityService>();
        services.AddScoped<IGenericService<Restaurant, RestaurantDTO>, RestaurantService>();
        return services;
    }
}