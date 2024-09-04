using Microsoft.EntityFrameworkCore;
using ProductApi.Core.Entity;

namespace ProductApi.Infrastructure.Data;

public class ProductDbcontext : DbContext
{
    public ProductDbcontext(DbContextOptions<ProductDbcontext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<CategoryVariation> CategoryVariations { get; set; }
    public DbSet<VariationValue> VariationValues { get; set; }
    public DbSet<ProductVariationValue> ProductVariationValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<ProductCategory>()
        //     .HasMany(pc => pc.Products)
        //     .WithOne(p => p.ProductCategory)
        //     .HasForeignKey(p => p.CategoryId);
        //
        // modelBuilder.Entity<ProductCategory>()
        //     .HasMany(pc => pc.CategoryVariations)
        //     .WithOne(pc => pc.ProductCategory)
        //     .HasForeignKey(pc => pc.CategoryId);
        // modelBuilder.Entity<ProductCategory>()
        //     .HasMany(pc => pc.Children)
        //     .WithOne(pc => pc.ParentCategory)
        //     .HasForeignKey(pc => pc.ParentCategoryId)
        //     .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CategoryVariation>()
            .HasMany(cv => cv.VariationValues)
            .WithOne(cv => cv.CategoryVariation)
            .HasForeignKey(cvv => cvv.VariationId);
        
        modelBuilder.Entity<ProductVariationValue>()
            .HasKey(pvv => new { pvv.ProductId, pvv.VariationValueId });
        
        // modelBuilder.Entity<Product>()
        //     .HasMany(p => p.ProductVariationValues)
        //     .WithOne(pvv => pvv.Product)
        //     .HasForeignKey(pvv => pvv.ProductId);
        //
        // modelBuilder.Entity<VariationValue>()
        //     .HasMany(vv => vv.ProductVariationValues)
        //     .WithOne(vv => vv.VariationValue)
        //     .HasForeignKey(vv => vv.VariationValueId);

        modelBuilder.Entity<ProductVariationValue>()
            .HasOne(vv => vv.Product)
            .WithMany(vv => vv.ProductVariationValues)
            .HasForeignKey(vv => vv.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProductVariationValue>()
            .HasOne(vv => vv.VariationValue)
            .WithMany(vv => vv.ProductVariationValues)
            .HasForeignKey(vv => vv.VariationValueId)
            .OnDelete(DeleteBehavior.NoAction);



    }
}