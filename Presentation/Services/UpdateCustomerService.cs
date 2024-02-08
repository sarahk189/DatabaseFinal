using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;

namespace Presentation.Services;

public class UpdateCustomerService
{
    private readonly CustomerService _customerService;
    private readonly AddressTypeService _addressTypeService;
    private readonly AddressesService _addressService;

    public UpdateCustomerService(CustomerService customerService, AddressTypeService addressTypeService, AddressesService addressService)
    {
        _customerService = customerService;
        _addressTypeService = addressTypeService;
        _addressService = addressService;
    }

    public async Task UpdateCustomerAsync(string customerEmail)
    {
        Console.WriteLine("*************************Update Customer*************************");

        try
        {
            var customer = await _customerService.GetCustomerByEmailAsync(customerEmail);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            var address = customer.CustomerAddresses.FirstOrDefault()?.AddressEntity;
            var addressType = address?.AddressType;
            if (address != null && addressType != null)
            {
                var customerDto = CustomerDto.FromCustomerEntity(customer, address, addressType);
                Console.Clear();
                Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}, Street Name: {customerDto.StreetName}, Postal Code: {customerDto.PostalCode}, City: {customerDto.City}, AddressType: {customerDto.AddressType}");
            }
            else
            {
                var customerDto = CustomerNoAddressDto.FromCustomerEntity(customer);
                Console.Clear();
                Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}");
            }


            Console.Write("Enter new first name: ");
            var newFirstName = Console.ReadLine()!;
            customer.CustomerDetails.FirstName = newFirstName;

            Console.Write("Enter new last name: ");
            var newLastName = Console.ReadLine()!;
            customer.CustomerDetails.LastName = newLastName;

            Console.Write("Enter new email address: ");
            var newEmail = Console.ReadLine()!;
            customer.Email = newEmail;

            Console.Write("Enter new phone number: ");
            var newPhone = Console.ReadLine()!;
            customer.CustomerDetails.PhoneNumber = newPhone;

            await _customerService.UpdateCustomerAsync(customer);
            Console.Clear();

            address = customer.CustomerAddresses.FirstOrDefault()?.AddressEntity;
            addressType = address?.AddressType;
            if (address != null && addressType != null)
            {
                var customerDto = CustomerDto.FromCustomerEntity(customer, address, addressType);
                Console.Clear();
                Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}, Street Name: {customerDto.StreetName}, Postal Code: {customerDto.PostalCode}, City: {customerDto.City}, AddressType: {customerDto.AddressType}");
            }
            else
            {
                var customerDto = CustomerNoAddressDto.FromCustomerEntity(customer);
                Console.Clear();
                Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}");
            }

            var addressEntity = customer.CustomerAddresses.FirstOrDefault()?.AddressEntity;
            if (addressEntity == null)
            {
                Console.Write("Street Name: ");
                string StreetAddress = Console.ReadLine()!;

                Console.Write("Postal Code: ");
                string PostalCode = Console.ReadLine()!;

                Console.Write("City: ");
                string City = Console.ReadLine()!;

                Console.Write("Address Type: ");
                Console.Write("Enter '1' for Delivery or '2' for Billing: ");
                string AddressTypeId = Console.ReadLine()!;

                if (AddressTypeId != "1" && AddressTypeId != "2")
                {
                    Console.WriteLine("Invalid input. You must provide an address type.");
                    return;
                }

                string addressTypeName = AddressTypeId == "1" ? "Delivery" : "Billing";
                var addressTypeEntity = await _addressTypeService.GetAddressTypesByNameAsync(addressTypeName);

                if (addressTypeEntity == null)
                {
                    Console.WriteLine($"Address type '{addressTypeName}' not found.");
                    return;
                }

                addressEntity = new AddressesEntity()
                {
                    StreetName = StreetAddress,
                    PostalCode = PostalCode,
                    City = City,
                    AddressTypeId = addressTypeEntity.AddressTypeId
                };
                var createdAddressEntity = await _addressService.CreateAddressAsync(addressEntity);

            }
            else
            {
                Console.Write("Enter new street name: ");
                var newStreetName = Console.ReadLine()!;
                address.StreetName = newStreetName;

                Console.Write("Enter new postal code: ");
                var newPostalCode = Console.ReadLine()!;
                address.PostalCode = newPostalCode;

                Console.Write("Enter new city: ");
                var newCity = Console.ReadLine()!;
                address.City = newCity;

                Console.Write("Enter new address type... ");
                Console.Write("Enter '1' for Delivery or '2' for Billing: ");
                var addressTypeChoice = Console.ReadLine()!;
                var newAddressTypeId = addressTypeChoice == "1" ? 1 : 2;

                address.AddressTypeId = newAddressTypeId;

                await _addressService.UpdateAddressAsync(address);
            }
            Console.Clear();
            Console.WriteLine("Customer updated successfully.");
            address = customer.CustomerAddresses.FirstOrDefault()?.AddressEntity;
            addressType = address?.AddressType;
            if (address != null && addressType != null)
            {
                var customerDto = CustomerDto.FromCustomerEntity(customer, address, addressType);
                Console.Clear();
                Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}, Street Name: {customerDto.StreetName}, Postal Code: {customerDto.PostalCode}, City: {customerDto.City}, AddressType: {customerDto.AddressType}");
            }
            else
            {
                var customerDto = CustomerNoAddressDto.FromCustomerEntity(customer);
                Console.Clear();
                Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}");
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Error occurred while updating customer: {ex.Message}");
        }
        Console.ReadKey();
    }
}
