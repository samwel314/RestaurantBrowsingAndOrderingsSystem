using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantSystemModels.Models;

namespace RestaurantSystemDataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Meal> Meals { get; set; }  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<Menu>().ToTable("Menus");
            builder.Entity<Meal>().ToTable("Meals");
            builder.Entity<Restaurant>().HasMany(r => r.Menus)
                .WithOne(m => m.Restaurant); 
        }
      
    }

  
}