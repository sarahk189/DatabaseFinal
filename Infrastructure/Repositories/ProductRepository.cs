using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ProductRepository(ProductCatalogueContext context) : ProductBaseRepository<Product>(context)
{
    private readonly ProductCatalogueContext _context = context;

    public override async Task<Product?> GetOneAsync(Expression<Func<Product, bool>> expression)
    {
        try
        {
            if (expression != null)
            {
                var entity = await _context.Products
                    .Include(p => p.Size)
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductCategory)
                    .Include(p => p.PersonCategory)
                    .FirstOrDefaultAsync(expression);

                return entity;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error fetching entity");
            Debug.WriteLine(ex.Message);
        }
        return null;
    }
        
    //public async Task<Product?> GetProductByIdRepAsync(Guid productId)
    //{
    //    if (guid.IsNullOrEmpty(productId))
    //    {
    //        Console.WriteLine("Provided product article number is null or empty.");
    //        return null;
    //    }

    //    try
    //    {
    //        return await _context.Products
    //                             .Include(c => c.Size)
    //                             .Include(c => c.ProductBrand)
    //                             .Include(b => b.ProductCategory)
    //                             .Include(a => a.PersonCategory)
    //                             .FirstOrDefaultAsync(c => c.ProductId == productId);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //        Console.WriteLine("Error occurred while fetching customer using their email");
    //        return null;
    //    }
    //}

    public override async Task<IEnumerable<Product>> GetAllAsync()
    {
        try
        {
            var list = _context.Products;
            return await list
            .Include(c => c.Size)
            .Include(c => c.ProductBrand)
            .Include(b => b.ProductCategory)
            .Include(a => a.PersonCategory)
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
