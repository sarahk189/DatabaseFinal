
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProductCategoryService
{
    private readonly ProductCategoryRepository _productCategoryRepository;
    private readonly ProductCatalogueContext _context;

    public ProductCategoryService(ProductCategoryRepository productCategoryRepository, ProductCatalogueContext context)
    {
        _productCategoryRepository = productCategoryRepository;
        _context = context;
    }

    public async Task<ProductCategory> CreateProductCategoryAsync(string productCategoryName)
    {
        var existingProductCategory = await _productCategoryRepository.GetOneAsync(x => x.ProductCategoryName == productCategoryName);

        if (existingProductCategory == null)
        {
            var newProductCategory = new ProductCategory { ProductCategoryName = productCategoryName };
            await _productCategoryRepository.AddAsync(newProductCategory);
            await _context.SaveChangesAsync();
            return newProductCategory;
        }

        return existingProductCategory;
    }


    public async Task<ProductCategory> GetProductCategoryByIdAsync(int productCategoryId)
    {
        try
        {
            var productCategoryEntity = await _productCategoryRepository.GetOneAsync(x => x.ProductCategoryId == productCategoryId);

            if (productCategoryEntity != null)
            {
                return productCategoryEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching productCategory using their Id");
        }
        return null!;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllProductCategorysAsync()
    {
        Console.Clear();
        try
        {
            var productCategorys = await _productCategoryRepository.GetAllAsync();

            if (productCategorys != null)
            {
                return productCategorys;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of productCategorys");
        }
        return null!;
    }

    public async Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory productCategoryEntity)
    {
        try
        {
            var updatedProductCategory = await _productCategoryRepository.UpdateAsync(x => x.ProductCategoryId == productCategoryEntity.ProductCategoryId, productCategoryEntity);

            if (updatedProductCategory != null)
            {
                return updatedProductCategory;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the productCategory");
        }
        return null!;
    }

    public async Task<bool> DeleteProductCategoryAsync(ProductCategory productCategoryEntity)
    {
        try
        {
            if (productCategoryEntity != null)
            {
                await _productCategoryRepository.DeleteAsync(x => x.ProductCategoryId == productCategoryEntity.ProductCategoryId, productCategoryEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the productCategory");
        }
        return false;
    }

    public async Task<ProductCategory> EnsureProductCategoryExistsAsync(string productCategoryName)
    {
        var category = await _context.ProductCategories
            .FirstOrDefaultAsync(c => c.ProductCategoryName == productCategoryName);

        if (category == null)
        {
            category = new ProductCategory { ProductCategoryName = productCategoryName };
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        return category; 
    }

}
