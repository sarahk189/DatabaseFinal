using Infrastructure.Contexts;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

public class CustomerDetailsRepository(CustomerCatalogueContext context) : BaseRepository<CustomerDetailsEntity>(context)
{
}
