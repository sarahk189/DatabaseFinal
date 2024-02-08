using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly ProductCatalogueContext _context;

    public ProductService(ProductRepository productRepository, ProductCatalogueContext context)
    {
        _productRepository = productRepository;
        _context = context;
    }

    public async Task<Product?> CreateProductAsync(Product newProduct)
    {
        try
        {
            var existingProduct = await _productRepository.GetOneAsync(x => x.ArticleNumber == newProduct.ArticleNumber);

            if (existingProduct == null)
            {
                await _productRepository.AddAsync(newProduct);
                await _context.SaveChangesAsync(); 

                return newProduct; 
            }
            else
            {

                Console.WriteLine("A product with the same article number already exists.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error occurred while creating the product: {ex.Message}");
            Console.WriteLine("Error occurred while creating the product with the article number.");
          
        }
        return null;
    }
        
    public async Task<Product?> GetProductByArticleNumberAsync(string articleNumber)
    {
        try
        {
            var productEntity = await _productRepository.GetOneAsync(p => p.ArticleNumber == articleNumber);

            return productEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error occurred while fetching product by Article Number: {articleNumber}. Details: {ex.Message}");
            Console.WriteLine("Error occurred while fetching product using their Article Number");

            return null;
        }
    }



    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        Console.Clear();
        try
        {
            var products = await _productRepository.GetAllAsync();

            if (products != null)
            {
                return products;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of products");
        }
        return null!;
    }

    public async Task<Product> UpdateProductAsync(Product productEntity)
    {
        try
        {
            var updatedProduct = await _productRepository.UpdateAsync(x => x.ProductId == productEntity.ProductId, productEntity);

            if (updatedProduct != null)
            {
                return updatedProduct;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the product");
        }
        return null!;
    }

    public async Task<bool> DeleteProductAsync(Product productEntity)
    {
        try
        {
            if (productEntity != null)
            {
                await _productRepository.DeleteAsync(x => x.ProductId == productEntity.ProductId, productEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the customer");
        }
        return false;
    }
    

}
