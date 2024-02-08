using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class CustomerDetailsEntity
    {
        [Key]
        [ForeignKey(nameof(CustomersEntity))]
        public Guid CustomerId { get; set; }
        public virtual CustomersEntity Customers { get; set; } = null!;


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;


        [Column(TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }
    }

}