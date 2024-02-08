using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class AddressTypeEntity
{
    [Key]
    public int AddressTypeId { get; set; }
    public virtual ICollection<AddressesEntity> Addresses { get; set; } = new HashSet<AddressesEntity>();


    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string AddressType { get; set; } = null!;
    
}
