using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.ViewModels;
using Restaurant.Models;

namespace Restaurant.Models
{
    public class myContext: IdentityDbContext<ApplicationUser>
    {
        public myContext()
        {            
        }
        public myContext(DbContextOptions<myContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-235UHFB\\SQLEXPRESS;Initial Catalog = Restaurant;Integrated Security = True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Restaurant.ViewModels.RegistrationVM> RegistrationVM { get; set; } = default!;
        public DbSet<Restaurant.ViewModels.LoginVM> LoginVM { get; set; } = default!;
        public DbSet<Restaurant.Models.Table> Table { get; set; } = default!;
        public DbSet<Restaurant.Models.MenuItem> menuItems { get; set; } = default!;
        public DbSet<Restaurant.Models.MenuCategory> menuCategories { get; set; } = default!;
        public DbSet<Restaurant.Models.Chef> Chefs { get; set; } = default!;
        public DbSet<Restaurant.Models.BookedTable> BookedTable { get; set; } = default!;





    }
}
