using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Color { get; set; }

    public decimal Price { get; set; }

    public string ArticleNumber { get; set; } = null!;

    public int SizeId { get; set; }

    public int PersonCategoryId { get; set; }

    public int ProductCategoryId { get; set; }

    public int ProductBrandId { get; set; }

    public virtual PersonCategory PersonCategory { get; set; } = null!;

    public virtual ProductBrand ProductBrand { get; set; } = null!;

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
