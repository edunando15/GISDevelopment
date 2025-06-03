using GISDevelopment.Abstractions;
using GISDevelopment.API;
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
        services.AddScoped<IGenericService<Municipality, MunicipalityDTO>>(provider =>
            new MunicipalityService(provider.GetRequiredService<DatabaseContext>()));
        
        services.AddScoped<IGenericService<Monument, MonumentDTO>>(provider =>
            new MonumentService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<Restaurant, RestaurantDTO>>(provider =>
            new RestaurantService(provider.GetRequiredService<ItalyCentreContext>()));

        services.AddScoped<IGenericService<Shop, ShopDTO>>(provider =>
            new ShopService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<PlaceOfWorship, PlaceOfWorshipDTO>>(provider =>
            new PlaceOfWorshipService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<UserPoint, UserPointDTO>>(provider =>
            new UserPointService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<UserLine, UserLineDTO>>(provider =>
            new UserLineService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<UserPolygon, UserPolygonDTO>>(provider =>
            new UserPolygonService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<PlanetOsmPoint, PlanetOsmPointDTO>>(provider =>
            new PlanetOsmPointService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<PlanetOsmLine, PlanetOsmLineDTO>>(provider =>
            new PlanetOsmLineService(provider.GetRequiredService<ItalyCentreContext>()));
        
        services.AddScoped<IGenericService<PlanetOsmPolygon, PlanetOsmPolygonDTO>>(provider =>
            new PlanetOsmPolygonService(provider.GetRequiredService<ItalyCentreContext>()));
        
        return services;
    }
    
    public static IServiceCollection AddMvcControllers(this IServiceCollection services)
    {
        services.AddScoped<Controllers.MunicipalityController>(provider =>
            new Controllers.MunicipalityController(
                provider.GetRequiredService<IGenericService<Municipality, MunicipalityDTO>>(),
                provider.GetRequiredService<DatabaseContext>()
            ));
        
        services.AddScoped<Controllers.MonumentController>(provider =>
            new Controllers.MonumentController(
                provider.GetRequiredService<IGenericService<Monument, MonumentDTO>>(),
                provider.GetRequiredService<ItalyCentreContext>()
            ));
        
        services.AddScoped<Controllers.RestaurantController>(provider =>
            new Controllers.RestaurantController(
                provider.GetRequiredService<IGenericService<Restaurant, RestaurantDTO>>(),
                provider.GetRequiredService<ItalyCentreContext>()
            ));
        
        services.AddScoped<Controllers.ShopController>(provider =>
            new Controllers.ShopController(
                provider.GetRequiredService<IGenericService<Shop, ShopDTO>>(),
                provider.GetRequiredService<ItalyCentreContext>()
            ));
        
        services.AddScoped<Controllers.PlaceOfWorshipController>(provider =>
            new Controllers.PlaceOfWorshipController(
                provider.GetRequiredService<IGenericService<PlaceOfWorship, PlaceOfWorshipDTO>>(),
                provider.GetRequiredService<ItalyCentreContext>()
            ));
        
        services.AddScoped<Controllers.MapController>(provider =>
            new Controllers.MapController(
                provider.GetRequiredService<ItalyCentreContext>(),
                provider.GetRequiredService<IGenericService<Monument, MonumentDTO>>(),
                provider.GetRequiredService<IGenericService<Restaurant, RestaurantDTO>>(),
                provider.GetRequiredService<IGenericService<Shop, ShopDTO>>(),
                provider.GetRequiredService<IGenericService<PlaceOfWorship, PlaceOfWorshipDTO>>()
            ));
        return services;
    }

    public static IServiceCollection AddAPIControllers(this IServiceCollection services)
    {
        services.AddScoped<MunicipalityController>(provider =>
            new MunicipalityController(provider.GetRequiredService<IGenericService<Municipality, MunicipalityDTO>>()));
            
        services.AddScoped<RestaurantController>(provider =>
            new RestaurantController(provider.GetRequiredService<IGenericService<Restaurant, RestaurantDTO>>()));
        
        services.AddScoped<MonumentController>(provider =>
            new MonumentController(provider.GetRequiredService<IGenericService<Monument, MonumentDTO>>()));
        
        services.AddScoped<ShopController>(provider =>
            new ShopController(provider.GetRequiredService<IGenericService<Shop, ShopDTO>>()));
        
        services.AddScoped<PlaceOfWorshipController>(provider =>
            new PlaceOfWorshipController(provider.GetRequiredService<IGenericService<PlaceOfWorship, PlaceOfWorshipDTO>>()));
        
        services.AddScoped<UserPointController>(provider =>
            new UserPointController(provider.GetRequiredService<IGenericService<UserPoint, UserPointDTO>>()));
        
        services.AddScoped<UserLineController>(provider =>
            new UserLineController(provider.GetRequiredService<IGenericService<UserLine, UserLineDTO>>()));
        
        services.AddScoped<UserPolygonController>(provider =>
            new UserPolygonController(provider.GetRequiredService<IGenericService<UserPolygon, UserPolygonDTO>>()));
        
        services.AddScoped<PlanetOsmPointController>(provider =>
            new PlanetOsmPointController(provider.GetRequiredService<IGenericService<PlanetOsmPoint, PlanetOsmPointDTO>>()));
        
        services.AddScoped<PlanetOsmLineController>(provider =>
            new PlanetOsmLineController(provider.GetRequiredService<IGenericService<PlanetOsmLine, PlanetOsmLineDTO>>()));
        
        services.AddScoped<PlanetOsmPolygonController>(provider =>
            new PlanetOsmPolygonController(provider.GetRequiredService<IGenericService<PlanetOsmPolygon, PlanetOsmPolygonDTO>>()));
        return services;
    }
}