using Infrastructure.Entities;
using Infrastructure.Services;

namespace Presentation.Services;

public class DeleteProductService
{
    private readonly ProductService _productService;
    private readonly SizeService _sizeService;
    private readonly ProductBrandService _productBrandService;
    private readonly PersonCategoryService _personCategoryService;
    private readonly ProductCategoryService _productCategoryService;

    public DeleteProductService(ProductService productService, SizeService sizeService, ProductBrandService productBrandService, PersonCategoryService personCategoryService, ProductCategoryService productCategoryService)
    {
        _productService = productService;
        _sizeService = sizeService;
        _productBrandService = productBrandService;
        _personCategoryService = personCategoryService;
        _productCategoryService = productCategoryService;
    }

    public async Task DeleteProductAsync(string productArticleNumber)
    {
        var product = await _productService.GetProductByArticleNumberAsync(productArticleNumber);
        if (product != null)
        {
            var isDeleted = await _productService.DeleteProductAsync(product);
            if (isDeleted)
            {
                Console.WriteLine("Product successfully deleted.");
            }
            else
            {
                Console.WriteLine("An error occurred while trying to delete the product.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

}
