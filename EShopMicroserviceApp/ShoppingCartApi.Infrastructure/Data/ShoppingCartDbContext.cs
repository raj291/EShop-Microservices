using Microsoft.EntityFrameworkCore;
using ShopingCartApi.Core.Entity;

namespace ShoppingCartApi.Infrastructure.Data;

public class ShoppingCartDbContext : DbContext
{
    public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
    {
        
    }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingCart>()
            .HasMany(s => s.ShoppingCartItems)
            .WithOne(s => s.ShoppingCart)
            .HasForeignKey(s => s.CartId);

        // modelBuilder.Entity<ShoppingCartItem>()
        //     .HasOne(s => s.ShoppingCart)
        //     .WithMany(s => s.ShoppingCartItems)
        //     .HasForeignKey(s => s.CartId);

        modelBuilder.Entity<PaymentType>()
            .HasMany(p => p.PaymentMethods)
            .WithOne(p => p.PaymentType)
            .HasForeignKey(p => p.PaymentTypeId);

    }
}