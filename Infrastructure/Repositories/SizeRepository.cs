using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class SizeRepository(ProductCatalogueContext context) : ProductBaseRepository<Size>(context)
{
}
