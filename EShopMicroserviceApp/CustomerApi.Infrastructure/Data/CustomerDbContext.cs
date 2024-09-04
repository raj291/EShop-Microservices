using CustomerApi.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Infrastructure.Data;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
        
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.CustomerAddressesList)
            .WithOne(ca => ca.Customer)
            .HasForeignKey(ca => ca.CustomerId);

        modelBuilder.Entity<Address>()
            .HasMany(a => a.CustomerAddressesList)
            .WithOne(ca => ca.Address)
            .HasForeignKey(ca => ca.AddressId); 


    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlServer("Server=localhost;Database=CustomerDb;User=sa;Password=AntraSEP98!;TrustServerCertificate=True;");
    //     }
    // }
    //
}