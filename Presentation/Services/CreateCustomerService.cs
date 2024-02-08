using Infrastructure.Entities;
using Infrastructure.Services;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Presentation.Services;
using System.Diagnostics.Metrics;

namespace Services.CreateCustomerService;

public class CreateCustomerService(CustomerService customerService, CustomerDetailsService customerDetailsService, CustomerAddressesService customerAddressService, AddressTypeService addressTypeService, AddressesService addressService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly CustomerDetailsService _customerDetailsService = customerDetailsService;
    private readonly CustomerAddressesService _customerAddressService = customerAddressService;
    private readonly AddressTypeService _addressTypeService = addressTypeService;
    private readonly AddressesService _addressService = addressService;

    public async Task CreateNewCustomerMenuAsync()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("-----------------------Add a Customer-----------------------");

            var customersEntity = new CustomersEntity();

            Console.Write("Customer Email: ");
            customersEntity.Email = Console.ReadLine()!;

            Console.Write("Customer Password: ");
            var password = Console.ReadLine()!;
            var (securityKey, hashedPassword) = PasswordGenerator.GenerateSecurePassword(password);
            customersEntity.Password = hashedPassword;
            customersEntity.SecurityKey = securityKey;

            var createdCustomerEntity = await _customerService.CreateCustomerAsync(customersEntity);

            Console.Clear();

            if (createdCustomerEntity != null)
            {
                Console.WriteLine("-----------------------Add Customer Details-----------------------");


                Console.Write("First Name: ");
                string FirstName = Console.ReadLine()!;

                Console.Write("Last Name: ");
                string LastName = Console.ReadLine()!;

                Console.Write("Phone Number: ");
                string PhoneNumber = Console.ReadLine()!;


                Console.WriteLine("-----------------------Add Customer Address Details-----------------------");

                Console.Write("Street Name: ");
                string StreetAddress = Console.ReadLine()!;

                Console.Write("Postal Code: ");
                string PostalCode = Console.ReadLine()!;

                Console.Write("City: ");
                string City = Console.ReadLine()!;

                Console.Write("Enter address type (1 for Delivery, 2 for Billing): ");
                string input = Console.ReadLine()!; 
                string addressTypeName; 

                if (input == "1")
                {
                    addressTypeName = "Delivery";
                }
                else if (input == "2")
                {
                    addressTypeName = "Billing";
                }
                else
                {
                    Console.WriteLine("Invalid input. You must provide an address type.");
                    return;

                }
                var newAddressType = new AddressTypeEntity
                {
                    AddressType = addressTypeName  
                };

                var createdAddressTypeEntity = await _addressTypeService.CreateAddressTypeAsync(newAddressType);

                var addressesEntity = new AddressesEntity()
                {
                    StreetName = StreetAddress,
                    PostalCode = PostalCode,
                    City = City,
                    AddressTypeId = createdAddressTypeEntity.AddressTypeId
                };
                var createdAddressEntity = await _addressService.CreateAddressAsync(addressesEntity);

                var customerDetails = new CustomerDetailsEntity()
                {
                    CustomerId = createdCustomerEntity.CustomerId,
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber
                };
                await _customerDetailsService.CreateCustomerDetailsAsync(customerDetails);


                var customerAddress = new CustomerAddressesEntity()
                {
                    CustomerAddressId = Guid.NewGuid(),
                    CustomerId = createdCustomerEntity.CustomerId,
                    AddressId = createdAddressEntity.AddressId
                };
                await _customerAddressService.CreateCustomerAddressAsync(customerAddress);

                Console.Clear();
                Console.WriteLine("Customer was added to the list.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Customer could not be added.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
}





