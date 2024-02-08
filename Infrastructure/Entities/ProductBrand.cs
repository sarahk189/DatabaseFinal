using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class ProductBrand
{
    public int ProductBrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
