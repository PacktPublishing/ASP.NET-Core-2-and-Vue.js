using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
  public class EcommerceContext : IdentityDbContext<AppUser, AppRole, int>
  {
    public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
    { }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Colour> Colours { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<OS> OS { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<Storage> Storage { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>()
        .HasIndex(b => b.Slug)
        .IsUnique();

      modelBuilder.Entity<ProductFeature>()
        .HasKey(x => new { x.ProductId, x.FeatureId });

      modelBuilder.Entity<ProductVariant>()
        .HasKey(x => new { x.ProductId, x.ColourId, x.StorageId });

      modelBuilder.Entity<Order>()
        .OwnsOne(x => x.DeliveryAddress);
    }
  }
}