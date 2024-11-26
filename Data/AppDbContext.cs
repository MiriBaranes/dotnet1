namespace dotnet1.Data;

using dotnet1.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // הגדרת קשרים בין טבלאות
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany()
            .HasForeignKey(od => od.ProductId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        // Seed Data לקטגוריות
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Electronics" },
            new Category { CategoryId = 2, Name = "Books" },
            new Category { CategoryId = 3, Name = "Clothing" }
        );

        // Seed Data למוצרים
        modelBuilder.Entity<Product>().HasData(
            // מוצרים בקטגוריה "Electronics"
            new Product { ProductId = 1, Name = "Smartphone", Price = 799.99m, CategoryId = 1 },
            new Product { ProductId = 2, Name = "Laptop", Price = 1299.99m, CategoryId = 1 },
            new Product { ProductId = 3, Name = "Tablet", Price = 499.99m, CategoryId = 1 },
            new Product { ProductId = 4, Name = "Headphones", Price = 199.99m, CategoryId = 1 },

            // מוצרים בקטגוריה "Books"
            new Product { ProductId = 5, Name = "C# Programming Guide", Price = 39.99m, CategoryId = 2 },
            new Product { ProductId = 6, Name = "Learning ASP.NET Core", Price = 29.99m, CategoryId = 2 },
            new Product { ProductId = 7, Name = "Mastering Entity Framework", Price = 49.99m, CategoryId = 2 },

            // מוצרים בקטגוריה "Clothing"
            new Product { ProductId = 8, Name = "T-Shirt", Price = 19.99m, CategoryId = 3 },
            new Product { ProductId = 9, Name = "Jeans", Price = 49.99m, CategoryId = 3 },
            new Product { ProductId = 10, Name = "Jacket", Price = 99.99m, CategoryId = 3 },
            new Product { ProductId = 11, Name = "Sneakers", Price = 89.99m, CategoryId = 3 }
        );
    }

}
