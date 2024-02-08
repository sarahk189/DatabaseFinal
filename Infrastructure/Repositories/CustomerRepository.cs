using Infrastructure.Contexts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Infrastructure.Repositories;

public class CustomerRepository(CustomerCatalogueContext context) : BaseRepository<CustomersEntity>(context)
{

    private readonly CustomerCatalogueContext _context = context;

    public override async Task<CustomersEntity?> GetOneAsync(Expression<Func<CustomersEntity, bool>> expression)
    {
        try
        {
            if (expression != null)
            {
                var entity = await _context.Customers
                .Include(x => x.CustomerDetails)
                .Include(a => a.CustomerAddresses)
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

    public async Task<CustomersEntity?> GetCustomerByEmailRepAsync(string customerEmail)
    {
        if (string.IsNullOrEmpty(customerEmail))
        {
            Console.WriteLine("Provided customer email is null or empty.");
            return null;
        }

        try
        {
            return await _context.Customers
                                 .Include(c => c.CustomerDetails)
                                 .Include(c => c.CustomerAddresses)
                                     .ThenInclude(ca => ca.AddressEntity)
                                         .ThenInclude(a => a.AddressType)
                                 .FirstOrDefaultAsync(c => c.Email == customerEmail);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occurred while fetching customer using their email");
            return null;
        }
    }

    public override async Task<IEnumerable<CustomersEntity>> GetAllAsync()
    {
        try
        {
          
            return await _context.Customers
                .Include(x => x.CustomerDetails)
                .Include(a => a.CustomerAddresses)
                    .ThenInclude(ca => ca.AddressEntity) 
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving the list");
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<CustomersEntity>();
        }
    }

}
