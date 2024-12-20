using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using TodoApp.Application.Behaviors;

namespace TodoApp.Application.Extensions;

public static class ServiceCollection
{
    private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    public static void LoadCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TodoContext>(options => options.UseSqlServer(configuration.GetConnectionString("TodoApp"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    public static void LoadMediatRService(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        });
        //services.AddValidatorsFromAssembly(assembly);
    }
    public static void LoadCorsPolicy(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
            {
                if (environment.IsProduction())
                {
                    policy.WithOrigins("https://*.test.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
                else
                {
                    policy.WithOrigins("http://localhost:7004", "http://localhost:5177")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            });
        });

    }
    public static void LoadConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = configuration.GetSection("OpenApiInfoTitle").Value,
                    Version = configuration.GetSection("OpenApiVersion").Value,
                    Description = configuration.GetSection("OpenApiDescription").Value,
                });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme{
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
                },
                new string[] { }
            }});
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }
    public static void LoadConfigureJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Settings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }

}
