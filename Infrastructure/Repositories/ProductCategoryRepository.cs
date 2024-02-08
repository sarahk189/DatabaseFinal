using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ProductCategoryRepository(ProductCatalogueContext context) : ProductBaseRepository<ProductCategory>(context)
{
}
