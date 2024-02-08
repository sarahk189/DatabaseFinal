using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CustomerAddressesEntity
{
    [Key]
    public Guid CustomerAddressId { get; set; } = Guid.NewGuid();

    
    [ForeignKey(nameof(CustomersEntity))]
    public Guid CustomerId { get; set; }
    public virtual CustomersEntity CustomersEntity { get; set; } = null!;

    
    [ForeignKey(nameof(AddressEntity))]
    public int AddressId { get; set; }
    public virtual AddressesEntity AddressEntity { get; set; } = null!;
}