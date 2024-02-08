using Infrastructure.Contexts;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

public class CustomerAddressRepository(CustomerCatalogueContext context) : BaseRepository<CustomerAddressesEntity>(context)
{
}
