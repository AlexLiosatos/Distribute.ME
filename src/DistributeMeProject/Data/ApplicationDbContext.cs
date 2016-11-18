using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DistributeMeProject.Models;

namespace DistributeMeProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Distributor> Distributors { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<Restaurant> Restaurants { get; set; } 
        public DbSet<RestaurantProduct> RestaurantProducts { get; set; } 
        public DbSet<UserDistributor> UserDistributors { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RestaurantProduct>().HasKey(x => new {x.ProductId, x.RestaurantId});
            builder.Entity<ApplicationUser>().HasMany(a => a.Restaurants).WithOne(r => r.User);
            builder.Entity<UserDistributor>().HasKey(x => new { x.DistributorId, x.UserId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
