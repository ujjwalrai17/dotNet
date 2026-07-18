using Microsoft.EntityFrameworkCore;

namespace RetailStoreMigration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               "Server=(localdb)\\ProjectModels;Database=RetailStoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}