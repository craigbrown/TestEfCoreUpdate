using Microsoft.EntityFrameworkCore;

namespace TestEfCoreUpdate.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Variant> Variant { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().Property<int>("CompanyId");
            modelBuilder.Entity<Subscription>().Property<int>("ProductId");
            modelBuilder.Entity<Variant>().Property<int>("ProductId");
            modelBuilder.Entity<Subscription>().HasIndex("CompanyId", "ProductId").IsUnique();
            modelBuilder.Entity<Subscription>().HasOne(s => s.Variant).WithMany().HasForeignKey("ProductId", "VariantId").HasPrincipalKey("ProductId", "VariantId");

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        ProductId = 1,
                        Name = "Flagship"
                    }
                );

            modelBuilder.Entity<Variant>()
                .HasData(
                    new { VariantId = 1, ProductId = 1, Name = "Beta" }
                );

            modelBuilder.Entity<Company>()
                .HasData(
                    new Company
                    {
                        CompanyId = 1,
                        CompanyName = "ABC Corp"
                    }
                );

            modelBuilder.Entity<Subscription>()
                .HasData(
                    new { SubscriptionId = 1, CompanyId = 1, ProductId = 1, VariantId = 1 }
                );
        }
    }
}
