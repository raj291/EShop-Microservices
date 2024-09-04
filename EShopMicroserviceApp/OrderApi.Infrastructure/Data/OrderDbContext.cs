using Microsoft.EntityFrameworkCore;
using OrderApi.Core.Entity;

namespace OrderApi.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetailsList)
            .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderId);
    }
}