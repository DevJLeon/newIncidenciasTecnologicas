using Dominio.Interfaces;
using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace API.Extensions;
public static class ApplicationServicesExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder => 
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    });
    public static void AddAplicacionServices(this IServiceCollection services)
    {
        //Services.AddScoped<IpaisInterface,PaisRepository>();
        //Services.AddScoped<ITipoPersona,TipoPeronsaRepository>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options =>
        {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = true;
            options.HttpStatusCode =429;
            options.RealIpHeader = "X-real-ip";
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };
        });
    }
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new QueryStringApiVersionReader("ver");
        });
    }
    
}
