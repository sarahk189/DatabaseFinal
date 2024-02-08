using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Dtos;

public class CustomerDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    public string? StreetName { get; set; } 
     
    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string AddressType { get; set; } = null!;

    public static CustomerDto FromCustomerEntity(CustomersEntity entity, AddressesEntity addressesEntity, AddressTypeEntity addressType)
    {
        var customerDto = new CustomerDto
        {
            Id = entity.CustomerId,
            FirstName = entity.CustomerDetails.FirstName,
            LastName = entity.CustomerDetails.LastName,
            PhoneNumber = entity.CustomerDetails.PhoneNumber,
            Email = entity.Email,
            StreetName = addressesEntity?.StreetName,
            PostalCode = addressesEntity?.PostalCode,
            City = addressesEntity?.City,
            AddressType = addressType.AddressType
        };
        return customerDto;
    }
}
