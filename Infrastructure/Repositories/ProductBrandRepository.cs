using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ProductBrandRepository(ProductCatalogueContext context) : ProductBaseRepository<ProductBrand>(context)
{
}
