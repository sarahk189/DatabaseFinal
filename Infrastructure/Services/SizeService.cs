using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;
using Size = Infrastructure.Entities.Size;

namespace Infrastructure.Services;

public class SizeService
{
    private readonly SizeRepository _sizeRepository;
    private readonly ProductCatalogueContext _context;

    public SizeService(SizeRepository sizeRepository, ProductCatalogueContext context)
    {
        _sizeRepository = sizeRepository;
        _context = context;
    }

    public async Task<Size> CreateSizeAsync(string size)
    {
        try
        {
            var existingSize = await _sizeRepository.GetOneAsync(x => x.SizeofProduct == size);

            if (existingSize == null)
            {
                var sizeToCreate = new Size
                {
                    SizeofProduct = size
                };

                await _sizeRepository.AddAsync(sizeToCreate);
                await _context.SaveChangesAsync();

                return sizeToCreate;
            }
            else
            {
                return existingSize;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occurred while creating size entity with the size of product.");
        }
        return null!;
    }

    public async Task<Size> EnsureSizeExistsAsync(string size)
    {
        var category = await _context.Size
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.SizeofProduct == size);

        if (category == null)
        {
            category = new Size { SizeofProduct = size };
            _context.Size.Add(category);
            await _context.SaveChangesAsync();
        }
        return category;
    }




    public async Task<Size> GetSizeByIdAsync(int sizeId)
    {
        try
        {
            var customerEntity = await _sizeRepository.GetOneAsync(x => x.SizeId == sizeId);

            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the size using its Id");
        }
        return null!;
    }

    public async Task<IEnumerable<Size>> GetAllSizesAsync()
    {
        Console.Clear();
        try
        {
            var sizes = await _sizeRepository.GetAllAsync();

            if (sizes != null)
            {
                return sizes;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of sizes");
        }
        return null!;
    }

    public async Task<Size> UpdateSizeAsync(Size product)
    {
        try
        {
            var updatedSize = await _sizeRepository.UpdateAsync(x => x.SizeId == product.SizeId, product);

            if (updatedSize != null)
            {
                return updatedSize;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the size");
        }
        return null!;
    }

    public async Task<bool> DeleteSizeAsync(Size product)
    {
        try
        {
            if (product != null)
            {
                await _sizeRepository.DeleteAsync(x => x.SizeId == product.SizeId, product);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the product");
        }
        return false;
    }

    
}
