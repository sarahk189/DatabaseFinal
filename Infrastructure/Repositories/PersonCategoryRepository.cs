using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Contexts;

public class PersonCategoryRepository(ProductCatalogueContext context) : ProductBaseRepository<PersonCategory>(context)
{
}
