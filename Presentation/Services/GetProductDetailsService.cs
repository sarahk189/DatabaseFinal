using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;

namespace Presentation.Services;

public class GetProductDetailsService
{
    private readonly ProductService _productService;
    private readonly UpdateProductService _updateProductService;
    private readonly DeleteProductService _deleteProductService;


    public GetProductDetailsService(ProductService productService, UpdateProductService updateProductService, DeleteProductService deleteProductService)
    {
        _productService = productService;
        _updateProductService = updateProductService;
        _deleteProductService = deleteProductService;
    }

    public async Task DisplayChoiceToShowDetailsAsync()
    {
        Console.Write("Write in product's article number, to display it's details:  ");
        try
        {
            var productArticleNumber = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(productArticleNumber))
            {
                await GetProductDetailsAsync(productArticleNumber);
            }
            else
            {
                Console.WriteLine("Please provide a product's article number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error; {ex.Message}");
        }
    }

    public async Task GetProductDetailsAsync(string productArticleNumber)
    {
        Console.Clear();
        try
        {
            var product = await _productService.GetProductByArticleNumberAsync(productArticleNumber);
            Console.Clear();
            if (product != null)
            {
                var productDto = ProductDto.FromProduct(
                    product,
                    product.Size,
                    product.ProductBrand,
                    product.ProductCategory,
                    product.PersonCategory);

                Console.WriteLine($"ID: {productDto.ProductId}, Title: {productDto.Title}, Price: {productDto.Price}, Description: {productDto.Description}, Size: {productDto.SizeofProduct}, Colour: {productDto.Color}, Brandname: {productDto.BrandName}, Product Category: {productDto.ProductCategoryName}, Person Category: {productDto.PersonCategoryName}");

                bool continueRunning = true;
                while (continueRunning)
                {
                    Console.WriteLine("To Update the Product press '1'.");
                    Console.WriteLine("To Delete the Product press '2'.");
                    Console.WriteLine("To exit back to the Main Menu, press '3'.");

                    string choice = Console.ReadLine()!;

                    switch (choice)
                    {
                        case "1":
                            await _updateProductService.UpdateProductAsync(productArticleNumber);
                            break;
                        case "2":
                            await _deleteProductService.DeleteProductAsync(productArticleNumber);
                            break;
                        case "3":
                            continueRunning = false;
                            Console.WriteLine("Exiting application...");
                            break;
                        default:
                            Console.WriteLine("Please type in a valid choice.");
                            break;
                    }
                }

            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

}
