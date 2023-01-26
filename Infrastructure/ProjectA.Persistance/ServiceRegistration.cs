using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectA.Application;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.Repositories;
using ProjectA.Core.Entities.Identity;
using ProjectA.Persistance.Context;
using ProjectA.Persistance.Repositories;
using ProjectA.Persistance.Services;

namespace ProjectA.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ProjectADbContext>(opt =>
            {
                ConfigurationManager manager = new();
                manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ProjectA.API"));
                manager.AddJsonFile("appsettings.json");
                opt.UseSqlServer(manager.GetConnectionString("MSSql"));
            }).AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<ProjectADbContext>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IUnitOfWorks, UnitOfWorks>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
