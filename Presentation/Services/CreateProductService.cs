using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;
using System.Reflection.Metadata;

namespace Services.CreateProductService;

public class CreateProductService
{
    private readonly ProductService _productService;
    private readonly SizeService _sizeService;
    private readonly ProductCategoryService _productCategoryService;
    private readonly PersonCategoryService _personCategoryService;
    private readonly ProductBrandService _productBrandService;
    private readonly ProductCatalogueContext _context;

    public CreateProductService(ProductService customerService, SizeService sizeService, ProductCategoryService productCategoryService, PersonCategoryService personCategoryService, ProductBrandService productBrandService, ProductCatalogueContext context)
    {
        _productService = customerService;
        _sizeService = sizeService;
        _productCategoryService = productCategoryService;
        _personCategoryService = personCategoryService;
        _productBrandService = productBrandService;
        _context = context;
    }

    public async Task CreateNewProductMenuAsync()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("-----------------------Add a Product-----------------------");

            Console.Write("Product Article Number: ");
            var articleNumber = Console.ReadLine()!;

            Console.Write("Product price: ");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                return;
            }

            Console.Write("Product Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Product Description: ");
            string description = Console.ReadLine()!;

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
            
            Console.Write("Product colour: ");
            string color = Console.ReadLine()!;

            Console.Write("Product Brandname: ");
            string brandName = Console.ReadLine()!;

            Console.Write("Enter new person category (male, female, children, unisex): ");
            string personCategoryName = Console.ReadLine()!;


            Console.Write("Product Category: ");
            string productCategoryName = Console.ReadLine()!;
            var personCategory = await _personCategoryService.EnsurePersonCategoryExistsAsync(personCategoryName);
            var productCategory = await _productCategoryService.EnsureProductCategoryExistsAsync(productCategoryName);
            var productBrand = await _productBrandService.EnsureProductBrandExistsAsync(brandName);
            var sizeEntity = await _sizeService.EnsureSizeExistsAsync(selectedSize.SizeofProduct);

            var productEntity = new Product()
            {
                ArticleNumber = articleNumber,
                Price = price,
                Title = title,
                Description = description,
                SizeId = sizeEntity.SizeId,
                Color = color,
                ProductCategoryId = productCategory.ProductCategoryId,
                ProductBrandId = productBrand.ProductBrandId,
                PersonCategoryId = personCategory.PersonCategoryId
            };
            var createdProductEntity = await _productService.CreateProductAsync(productEntity);

            if (createdProductEntity != null)
            {
                Console.Clear();
                Console.WriteLine("Product was added to the list.");
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Product could not be added. {ex.Message}");
        }

        Console.ReadKey();
    }

}




