using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class CustomersEntity
{
    [Key]
    [ForeignKey(nameof(CustomerAddressesEntity))]
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public virtual CustomerDetailsEntity CustomerDetails { get; set; } = null!;
    
    public virtual ICollection<CustomerAddressesEntity> CustomerAddresses { get; set; } = new HashSet<CustomerAddressesEntity>();


    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Password { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string SecurityKey { get; set; } = null!;  
}
