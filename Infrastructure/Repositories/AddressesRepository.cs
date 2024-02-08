using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class AddressesRepository(CustomerCatalogueContext context) : BaseRepository<AddressesEntity>(context)
{
    private readonly CustomerCatalogueContext _context = context;

    public override async Task<AddressesEntity?> GetOneAsync(Expression<Func<AddressesEntity, bool>> expression)
    {
        try
        {
            {
                var entity = await _context.Addresses
                .Include(x => x.AddressType).ThenInclude(a => a.AddressTypeId)
                .Include(t => t.CustomerAddresses).ThenInclude(b => b.AddressId)
                .FirstOrDefaultAsync(expression);

                if (entity != null)
                {
                    return entity;
                }
            }

            throw new InvalidOperationException("Entity not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding entity");
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public override async Task<IEnumerable<AddressesEntity>> GetAllAsync()
    {
        try
        {
            var list = _context.Addresses;
            return await list
            .Include(x => x.AddressType).ThenInclude(a => a.AddressTypeId)
            .Include(t => t.CustomerAddresses).ThenInclude(b => b.AddressId)
            .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving the list");
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
