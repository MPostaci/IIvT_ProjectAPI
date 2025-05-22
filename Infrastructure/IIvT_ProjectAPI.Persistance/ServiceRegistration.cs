using FluentValidation;
using IIvT_ProjectAPI.Application;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using IIvT_ProjectAPI.Persistence.Behaviors;
using IIvT_ProjectAPI.Persistence.Context;
using IIvT_ProjectAPI.Persistence.Repositories;
using IIvT_ProjectAPI.Persistence.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IIvT_ProjectAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<IIvT_ProjectAPIDbContext>(option => option.UseNpgsql(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<IIvT_ProjectAPIDbContext>()
            .AddDefaultTokenProviders();


            services.AddScoped<IAnnouncementReadRepository, AnnouncementReadRepository>();
            services.AddScoped<IAnnouncementWriteRepository, AnnouncementWriteRepository>();

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IMediaFileReadRepository, MediaFileReadRepository>();
            services.AddScoped<IMediaFileWriteRepository, MediaFileWriteRepository>();

            services.AddScoped<INewsItemReadRepository, NewsItemReadRepository>();
            services.AddScoped<INewsItemWriteRepository, NewsItemWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();

            services.AddScoped<IOrderStatusReadRepository, OrderStatusReadRepository>();
            services.AddScoped<IOrderStatusWriteRepository, OrderStatusWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();





            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)
                );


            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(EfTransactionBehavior<,>)
                );
        }
    }
}
