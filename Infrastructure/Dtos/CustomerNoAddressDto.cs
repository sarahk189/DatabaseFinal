using Infrastructure.Entities;

namespace Infrastructure.Dtos;

public class CustomerNoAddressDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    public static CustomerNoAddressDto FromCustomerEntity(CustomersEntity entity)
    {
        var customerNoAddressDto = new CustomerNoAddressDto
        {
            Id = entity.CustomerId,
            FirstName = entity.CustomerDetails.FirstName,
            LastName = entity.CustomerDetails.LastName,
            PhoneNumber = entity.CustomerDetails.PhoneNumber,
            Email = entity.Email
        };
        return customerNoAddressDto;
    }
}
