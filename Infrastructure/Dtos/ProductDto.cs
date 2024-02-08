using Infrastructure.Entities;

namespace Infrastructure.Dtos;

public class ProductDto
{
    public int ProductId { get; set; }

    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;

    public string SizeofProduct { get; set; } = null!;
    public string Color { get; set; } = null!;

    public string BrandName { get; set; } = null!;
    public string ProductCategoryName { get; set; } = null!;
    public string PersonCategoryName { get; set; } = null!;

    public static ProductDto FromProduct(Product entity, Size size, ProductBrand productBrand, ProductCategory productCategory, PersonCategory personCategory)
    {
        var dto = new ProductDto
        {
            ProductId = entity.ProductId,
            ArticleNumber = entity.ArticleNumber,
            Title = entity.Title,
            Description = entity.Description!,
            Price = entity.Price,
            SizeofProduct = size.SizeofProduct,
            Color = entity.Color!,
            BrandName = productBrand.BrandName,
            ProductCategoryName = productCategory.ProductCategoryName,
            PersonCategoryName = personCategory.PersonCategoryName
        };

        return dto;
    }
}
