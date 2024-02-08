using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class PersonCategory
{
    public int PersonCategoryId { get; set; }

    public string PersonCategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
