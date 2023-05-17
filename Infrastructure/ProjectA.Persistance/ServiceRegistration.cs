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
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
            services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();
            services.AddScoped<IProjectFileWriteRepository, ProjectFileWriteRepository>();
            services.AddScoped<IProjectFileReadRepository, ProjectFileReadRepository>();
            services.AddScoped<IOrderFileReadRepository, OrderFileReadRepository>();
            services.AddScoped<IOrderFileWriteRepository, OrderFileWriteRepository>();

            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
