using Coelsa.Domain.CustomEntitites;
using Coelsa.Domain.Interfaces;
using Coelsa.Domain.Interfaces.Repositories;
using Coelsa.Domain.Interfaces.Services;
using Coelsa.Domain.Services;
using Coelsa.Infra.Data.DbContexts;
using Coelsa.Infra.Data.Interfaces;
using Coelsa.Infra.Data.Repositories;
using Coelsa.Infra.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Coelsa.Infra.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoelsaChallengeContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("CoelsaChallenge"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IContactsService, ContactsService>();
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Coelsa API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
