using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;
using System.Diagnostics;

namespace Presentation.Services;

public class UpdateProductService
{
    private readonly ProductService _productService;
    private readonly SizeService _sizeService;

    public UpdateProductService(ProductService productService, SizeService sizeService)
    {
        _productService = productService;
        _sizeService = sizeService;
    }

    public async Task UpdateProductAsync(string articleNumber)
    {
        Console.WriteLine("*************************Update Product*************************");

        try
        {
            var product = await _productService.GetProductByArticleNumberAsync(articleNumber);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            else
            {
                var size = product.Size;
                var productCategory = product.ProductCategory;
                var productBrand = product.ProductBrand;
                var personCategory = product.PersonCategory;
                var productDto = ProductDto.FromProduct(product, size, productBrand, productCategory, personCategory);
                Console.Clear();
                Console.WriteLine($"ID: {productDto.ProductId}, Title: {productDto.Title}, Price: {productDto.Price}, Description: {productDto.Description}, Size: {productDto.SizeofProduct}, Colour: {productDto.Color}, Brandname: {productDto.BrandName}, Product Category: {productDto.ProductCategoryName}, Person Category: {productDto.PersonCategoryName}");
            }


            Console.Write("Enter new title: ");
            var newTitle = Console.ReadLine()!;
            product.Title = newTitle;

            Console.Write("Enter a new price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                product.Price = newPrice;
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal number.");
            }

            Console.Write("Enter new aritle number: ");
            var newArticleNumber = Console.ReadLine()!;
            product.ArticleNumber = newArticleNumber;

            Console.Write("Enter new description: ");
            var newDescription = Console.ReadLine()!;
            product.Description = newDescription;

            var availableSizes = (await _sizeService.GetAllSizesAsync()).ToList();
            Console.Clear();
            Console.WriteLine("Select Product Size:");
            for (int i = 0; i < availableSizes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableSizes[i].SizeofProduct}");
            }

            int selectedSizeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            if (selectedSizeIndex < 0 || selectedSizeIndex >= availableSizes.Count)
            {
                Console.WriteLine("Invalid selection. Please select a valid size.");
                return;
            }

            var selectedSize = availableSizes[selectedSizeIndex];
            product.Size.SizeofProduct = selectedSize.SizeofProduct;

            Console.Write("Enter new colour: ");
            var newColour = Console.ReadLine()!;
            product.Color = newColour;

            Console.Write("Enter new brandname: ");
            var newBrandName = Console.ReadLine()!;
            product.ProductBrand.BrandName = newBrandName;

            Console.Write("Enter new product category: ");
            var newProductCategory = Console.ReadLine()!;
            product.ProductCategory.ProductCategoryName = newProductCategory;

            Console.Write("Enter new person category (male, female, children, unisex): ");
            var newPersonCategory = Console.ReadLine()!;
            if (newPersonCategory == "male" && newPersonCategory == "female" && newPersonCategory == "children" && newPersonCategory == "unisex")
            {
                product.PersonCategory.PersonCategoryName = newPersonCategory;
            }
            else
            {
                Console.WriteLine("Choose a person-type for the product");
            }

            await _productService.UpdateProductAsync(product);

            Console.WriteLine("Product updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while updating product: {ex.Message}");
        }
    }
}
