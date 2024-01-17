using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartShop.Core;
using SmartShop.Infrastructure;
using static SmartShop.Core.Constants.DocumentationConstants;

namespace SmartShop.API.Extensions;

public static class ApplicationServicesExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config, IWebHostEnvironment hostingEnvironment)
    {
        services.AddEndpointsApiExplorer();
        // need to change this because it will not work on the server side and make it in one file and take it to the output code 
        services.AddSwaggerGen(options =>
        {
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SmartShop",
                });
                // Get the current working directory
                string apiPath = hostingEnvironment.ContentRootPath;

                //var x = AppContext.BaseDirectory;
                foreach (var xmlFile in XmlFiles)
                {
                    var xmlPath = Path.Combine(apiPath + DocumentationFolderPath + xmlFile);
                    options.IncludeXmlComments(xmlPath);
                }
            }

        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection"),
                sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    // Additional SQL Server options if needed
                    // sqlServerOptions.CommandTimeout(60);
                }
            );
        });


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
            };
        });

        services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });



        return services;
    }
}

