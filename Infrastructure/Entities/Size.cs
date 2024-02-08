using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Size
{
    public int SizeId { get; set; }

    public string SizeofProduct { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
