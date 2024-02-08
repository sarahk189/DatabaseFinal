using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class AddressTypeRepository(CustomerCatalogueContext context) : BaseRepository<AddressTypeEntity>(context)
{


}
