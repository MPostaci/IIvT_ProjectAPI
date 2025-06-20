﻿using FluentValidation;
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

            services.AddScoped<IEventReadRepository, EventReadRepository>();
            services.AddScoped<IEventWriteRepository, EventWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();

            services.AddScoped<IOrderStatusReadRepository, OrderStatusReadRepository>();
            services.AddScoped<IOrderStatusWriteRepository, OrderStatusWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductMediaFileReadRepository, ProductMediaFileReadRepository>();
            services.AddScoped<IProductMediaFileWriteRepository, ProductMediaFileWriteRepository>();

            services.AddScoped<IAnnouncementMediaFileReadRepository, AnnouncementMediaFileReadRepository>();
            services.AddScoped<IAnnouncementMediaFileWriteRepository, AnnouncementMediaFileWriteRepository>();

            services.AddScoped<INewsItemMediaFileReadRepository, NewsItemMediaFileReadRepository>();
            services.AddScoped<INewsItemMediaFileWriteRepository, NewsItemMediaFileWriteRepository>();

            services.AddScoped<IEventMediaFileReadRepository, EventMediaFileReadRepository>();
            services.AddScoped<IEventMediaFileWriteRepository, EventMediaFileWriteRepository>();

            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();

            services.AddScoped<ICityReadRepository, CityReadRepository>();
            services.AddScoped<IDistrictReadRepository, DistrictReadRepository>();
            services.AddScoped<INeighborhoodReadRepository, NeighborhoodReadRepository>();

            services.AddScoped<IUserAddressReadRepository, UserAddressReadRepository>();
            services.AddScoped<IUserAddressWriteRepository, UserAddressWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IIdentityRoleEndpointReadRepository, IdentityRoleEndpointReadRepository>();
            services.AddScoped<IIdentityRoleEndpointWriteRepository, IdentityRoleEndpointWriteRepository>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<INewsItemService, NewsItemService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            services.AddScoped<IRoleService, RoleService>();





            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)
                );


            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(EfTransactionBehavior<,>)
                );


            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>)
                );
        }
    }
}
