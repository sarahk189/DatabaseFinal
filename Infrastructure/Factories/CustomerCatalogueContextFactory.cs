using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Contexts;

namespace Infrastructure.Factories;

public class CustomerCatalogueContextFactory : IDesignTimeDbContextFactory<ProductCatalogueContext>
{
    public ProductCatalogueContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductCatalogueContext>();
        optionsBuilder.UseSqlServer(@"Data Source=SarahsLaptop;Initial Catalog=customercatalogue_;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        return new ProductCatalogueContext(optionsBuilder.Options);
    }
}
