using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Common;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Context
{
    public class IIvT_ProjectAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public IIvT_ProjectAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<ProductMediaFile> ProductMediaFiles { get; set; }
        public DbSet<NewsItemMediaFile> NewsItemMediaFiles { get; set; }
        public DbSet<AnnouncementMediaFile> AnnouncementMediaFiles { get; set; }
        public DbSet<EventMediaFile> EventMediaFiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Enum
            builder.Entity<Category>()
                .Property(c => c.ContentType)
                .HasConversion<int>()
                .HasColumnName("ContentType");


            // Category <=> NewsItem / Announcement (1:1)
            builder.Entity<Category>()
                .HasMany(c => c.NewsItem)
                .WithOne(n => n.Category)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
                .HasMany(c => c.Announcement)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // AppUser <=> NewsItem / Announcement (1:N)
            builder.Entity<NewsItem>()
                .HasOne(n => n.Publisher)
                .WithMany()
                .HasForeignKey(n => n.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Announcement>()
                .HasOne(a => a.Publisher)
                .WithMany()
                .HasForeignKey(a => a.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            // AppUser <=> UserAddress (1:N)
            builder.Entity<UserAddress>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(ua => ua.UserId);

            // OrderStatus <=> Order (1:N)
            builder.Entity<OrderStatus>()
                .HasMany(os => os.Orders)
                .WithOne(o => o.OrderStatus)
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order <=> OrderDetail (1:N)
            builder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            builder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            builder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            // Basket <=> BasketItem (1:N)
            builder.Entity<BasketItem>()
                .HasKey(bi => new { bi.BasketId, bi.ProductId });

            builder.Entity<BasketItem>()
                .HasOne(bi => bi.Basket)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(bi => bi.BasketId)
                .IsRequired(false);

            builder.Entity<BasketItem>()
                .HasOne(bi => bi.Product)
                .WithMany(p => p.BasketItems)
                .HasForeignKey(bi => bi.ProductId);

            // Basket <=> AppUser (1:1)
            builder.Entity<Basket>()
                .HasOne(b => b.User)
                .WithOne()
                .HasForeignKey<Basket>(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order <=> AppUser (N:1)
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId);

            builder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithMany()
                .HasForeignKey(o => o.BillingAddressId);


            // 1) Map the base
            builder.Entity<MediaFile>()
                .ToTable("MediaFiles");

            // 2) Map each derived type to its own table
            builder.Entity<ProductMediaFile>()
                .ToTable("ProductMediaFiles");

            builder.Entity<NewsItemMediaFile>()
                .ToTable("NewsItemMediaFiles");

            builder.Entity<AnnouncementMediaFile>()
                .ToTable("AnnouncementMediaFiles");

            builder.Entity<EventMediaFile>()
                .ToTable("EventMediaFiles");


            // 1) Index on District.CityId
            builder.Entity<District>()
                .HasIndex(d => d.CityId)
                .HasDatabaseName("IX_District_CityId");

            // 2) Index on Neighborhood.DistrictId
            builder.Entity<Neighborhood>()
                .HasIndex(n => n.DistrictId)
                .HasDatabaseName("IX_Neighborhood_DistrictId");

            builder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Pending", Description = "Order has been placed, awaiting payment." },
                new OrderStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Processing", Description = "Order is preparing" },
                new OrderStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Shipped", Description = "Order has been shipped." },
                new OrderStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Completed", Description = "Order delivered/completed." },
                new OrderStatus { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Cancelled", Description = "Order was cancelled." }
            );


            // Soft Delete
            var softDeleteInterface = typeof(ISoftDelete);
            foreach (var entityType in builder.Model.GetEntityTypes()
                .Where(t => softDeleteInterface.IsAssignableFrom(t.ClrType)))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var prop = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                var condition = Expression.Equal(prop, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                builder.Entity(entityType.ClrType)
                    .HasQueryFilter(lambda);
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
