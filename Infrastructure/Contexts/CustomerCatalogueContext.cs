using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class CustomerCatalogueContext : DbContext
{
    public CustomerCatalogueContext(DbContextOptions<CustomerCatalogueContext> options) : base(options)
    {
    }

    public DbSet<CustomersEntity> Customers { get; set; }
    public DbSet<CustomerDetailsEntity> CustomerDetails { get; set; }
    public DbSet<CustomerAddressesEntity> CustomerAddresses { get; set; }
    public DbSet<AddressTypeEntity> AddressType { get; set; }
    public DbSet<AddressesEntity> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CustomersEntity>()
            .HasOne(c => c.CustomerDetails)
            .WithOne(cd => cd.Customers)
            .HasForeignKey<CustomerDetailsEntity>(cd => cd.CustomerId);

        modelBuilder.Entity<CustomersEntity>()
            .HasMany(c => c.CustomerAddresses)
            .WithOne(ca => ca.CustomersEntity)
            .HasForeignKey(ca => ca.CustomerId);

  
        modelBuilder.Entity<AddressesEntity>()
            .HasMany(a => a.CustomerAddresses)
            .WithOne(ca => ca.AddressEntity)
            .HasForeignKey(ca => ca.AddressId);

        modelBuilder.Entity<AddressTypeEntity>()
            .HasMany(at => at.Addresses)
            .WithOne(a => a.AddressType)
            .HasForeignKey(a => a.AddressTypeId);
    }
}
