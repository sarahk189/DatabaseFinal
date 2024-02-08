using Infrastructure.Dtos;
using Infrastructure.Services;

namespace Presentation.Services;

public class GetAllProductsService
{
    private readonly ProductService _productService;


    public GetAllProductsService(ProductService productService)
    {
        _productService = productService;
    }

    public async Task GetAllProductsAsync()
    {
        Console.Clear();
        try
        {
            var products = await _productService.GetAllProductsAsync();
            Console.Clear();
            foreach (var product in products)
            {
                var size = product.Size;
                var productCategory = product.ProductCategory;
                var productBrand = product.ProductBrand;
                var personCategory = product.PersonCategory;
                var productDto = ProductDto.FromProduct(product, size, productBrand, productCategory, personCategory);

                Console.WriteLine($"Title: {productDto.Title}, Price: {productDto.Price}");
                Console.WriteLine($"Article Number: {productDto.ArticleNumber}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
