using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TrainTimings.Application.Interfaces;
using TrainTimings.Application.Interfaces.IRepository;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Persistence.Data.Context;
using TrainTimings.Persistence.Helpers;
using TrainTimings.Persistence.Repositories;
using TrainTimings.Persistence.Services;

namespace TrainTimings.Persistence.Extentions;

public static class DiExtentions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
        var connectionString = configuration.GetConnectionString("PostgresContainer");

        var dataContext = new DataContext();
        dataContext.Database.EnsureCreated();

        try
        {
            dataContext.Database.Migrate();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICitiesTrainRepository, CitiesTrainRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ITimingsRepository, TimingsRepository>();
        services.AddScoped<ITrainsRepository, TrainsRepository>();
        services.AddScoped<ITypesFollowingRepository, TypesFollowingRepository>();
        services.AddScoped<ITypesRepository, TypesRepository>();
        services.AddScoped<IAccountService, AccountService>();
        
        return services;
    }
    
    public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options => 
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
        
        return services;
    }
    
    public static IServiceCollection AddKeycloakAuthentication(
        this IServiceCollection services, IConfiguration configuration)
    {
       
        services.AddKeycloakWebApiAuthentication(configuration, options =>
        {
            options.RequireHttpsMetadata = false;
        });
        
        return services;
    }

    public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
    {
        services
            .AddAuthorization()
            .AddKeycloakAuthorization(options =>
            {
                options.EnableRolesMapping = RolesClaimTransformationSource.Realm;
                options.RoleClaimType = KeycloakConstants.RoleClaimType;
            })
            .AddAuthorizationBuilder()
            .AddPolicy(
                "AdminPolicy",
                policy => policy.RequireRole("Admin")
            )
            .AddPolicy(
                "DefaultPolicy", 
                policy => policy.RequireRole("Default"));

        return services;
    }
}