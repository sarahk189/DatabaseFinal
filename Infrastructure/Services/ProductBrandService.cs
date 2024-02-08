using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProductBrandService
{
    private readonly ProductBrandRepository _productBrandRepository;
    private readonly ProductCatalogueContext _context;

    public ProductBrandService(ProductBrandRepository productBrandRepository, ProductCatalogueContext context)
    {
        _productBrandRepository = productBrandRepository;
        _context = context;
    }

    public async Task<ProductBrand> CreateProductBrandAsync(string brandName)
    {
        var existingProductBrand = await _productBrandRepository.GetOneAsync(x => x.BrandName == brandName);

        if (existingProductBrand == null)
        {
            var newProductBrand = new ProductBrand { BrandName = brandName };
            await _productBrandRepository.AddAsync(newProductBrand);
            await _context.SaveChangesAsync();
            return newProductBrand;
        }

        return existingProductBrand;
    }

    public async Task<ProductBrand> GetProductBrandByIdAsync(int productBrandId)
    {
        try
        {
            var productBrandEntity = await _productBrandRepository.GetOneAsync(x => x.ProductBrandId == productBrandId);

            if (productBrandEntity != null)
            {
                return productBrandEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching product Brand using their Id");
        }
        return null!;
    }

    public async Task<IEnumerable<ProductBrand>> GetAllProductBrandsAsync()
    {
        Console.Clear();
        try
        {
            var productBrands = await _productBrandRepository.GetAllAsync();

            if (productBrands != null)
            {
                return productBrands;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of product Brands");
        }
        return null!;
    }

    public async Task<ProductBrand> UpdateProductBrandAsync(ProductBrand productBrandEntity)
    {
        try
        {
            var updatedProductBrand = await _productBrandRepository.UpdateAsync(x => x.ProductBrandId == productBrandEntity.ProductBrandId, productBrandEntity);

            if (updatedProductBrand != null)
            {
                return updatedProductBrand;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the product Brand");
        }
        return null!;
    }

    public async Task<bool> DeleteProductBrandAsync(ProductBrand productBrandEntity)
    {
        try
        {
            if (productBrandEntity != null)
            {
                await _productBrandRepository.DeleteAsync(x => x.ProductBrandId == productBrandEntity.ProductBrandId, productBrandEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the product Brand");
        }
        return false;
    }

    public async Task<ProductBrand> EnsureProductBrandExistsAsync(string brandName)
    {
        var brand = await _context.ProductBrands
            .FirstOrDefaultAsync(b => b.BrandName == brandName);

        if (brand == null)
        {
            brand = new ProductBrand { BrandName = brandName };
            _context.ProductBrands.Add(brand);
            await _context.SaveChangesAsync();
        }

        return brand;
    }
}
