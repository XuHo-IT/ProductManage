using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BusinessObjects;

namespace DataAccessLayer;

public partial class MyStoreContext : DbContext
{
    public MyStoreContext()
    {
    }

    public MyStoreContext(DbContextOptions<MyStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountMember> AccountMembers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }
    }

    string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        return config["ConnectionStrings:MyStoreDB"];
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, CategoryName = "Snacks" },
            new Category { CategoryID = 2, CategoryName = "Beverages" },
            new Category { CategoryID = 3, CategoryName = "Bakery" },
            new Category { CategoryID = 4, CategoryName = "Frozen Foods" },
            new Category { CategoryID = 5, CategoryName = "Fresh Produce" },
            new Category { CategoryID = 6, CategoryName = "Meat" },
            new Category { CategoryID = 7, CategoryName = "Seafood" },
            new Category { CategoryID = 8, CategoryName = "Dairy" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Potato Chips", CategoryID = 1, UnitsInStock = 50, Price = 2.50m },
            new Product { ProductId = 2, ProductName = "Orange Juice", CategoryID = 2, UnitsInStock = 30, Price = 3.00m },
            new Product { ProductId = 3, ProductName = "Croissant", CategoryID = 3, UnitsInStock = 15, Price = 1.75m },
            new Product { ProductId = 4, ProductName = "Frozen Pizza", CategoryID = 4, UnitsInStock = 25, Price = 5.00m },
            new Product { ProductId = 5, ProductName = "Bananas", CategoryID = 5, UnitsInStock = 40, Price = 0.50m },
            new Product { ProductId = 6, ProductName = "Chicken Breast", CategoryID = 6, UnitsInStock = 20, Price = 6.50m },
            new Product { ProductId = 7, ProductName = "Salmon Fillet", CategoryID = 7, UnitsInStock = 15, Price = 9.00m },
            new Product { ProductId = 8, ProductName = "Greek Yogurt", CategoryID = 8, UnitsInStock = 35, Price = 1.00m },
            new Product { ProductId = 9, ProductName = "Bagel", CategoryID = 3, UnitsInStock = 20, Price = 1.25m },
            new Product { ProductId = 10, ProductName = "Lemonade", CategoryID = 2, UnitsInStock = 25, Price = 2.00m }
        );

        modelBuilder.Entity<AccountMember>().HasData(
            new AccountMember { MemberID = "PS1001", MemberPassword = "@admin01", MemberName = "Admin User", EmailAddress = "admin@newstore.com", MemberRole = 1 },
            new AccountMember { MemberID = "PS1002", MemberPassword = "@staff02", MemberName = "John Staff", EmailAddress = "john.staff@newstore.com", MemberRole = 2 },
            new AccountMember { MemberID = "PS1003", MemberPassword = "@member03", MemberName = "Alice Member", EmailAddress = "alice.member@newstore.com", MemberRole = 3 },
            new AccountMember { MemberID = "PS1004", MemberPassword = "@member04", MemberName = "Bob Member", EmailAddress = "bob.member@newstore.com", MemberRole = 3 }
        );
    }

}
