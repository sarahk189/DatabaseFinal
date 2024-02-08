using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class AddressesEntity
{
    [Key]
    [ForeignKey(nameof(CustomerAddressesEntity))]
    public int AddressId { get; set; }
    public virtual ICollection<CustomerAddressesEntity> CustomerAddresses { get; set; } = new HashSet<CustomerAddressesEntity>();


    [Column(TypeName = "nvarchar(50)")]
    public string? StreetName { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string? PostalCode { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string? City { get; set; }

    
    [Required]
    [ForeignKey(nameof(AddressTypeEntity))]
    public int AddressTypeId { get; set; }
    public virtual AddressTypeEntity AddressType { get; set; } = null!;
}
