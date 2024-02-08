using Infrastructure.Dtos;
using Infrastructure.Services;
using System.Net;

namespace Presentation.Services;

public class GetAllCustomersService
{
    private readonly CustomerService _customerService;


    public GetAllCustomersService(CustomerService customerService)
    {
        _customerService = customerService;

    }

    public async Task GetAllCustomersAsync()
    {
        Console.Clear();
        try
        {
            var customers = await _customerService.GetAllCustomersAsync();
            Console.Clear();
            foreach (var customer in customers)
            {
                if (customer == null)
                {
                    continue;
                }
                var firstName = customer.CustomerDetails.FirstName;
                var lastName = customer.CustomerDetails.LastName;
                var email = customer.Email;
                var phoneNumber = customer.CustomerDetails.PhoneNumber;
                var customerDto = CustomerNoAddressDto.FromCustomerEntity(customer);

                Console.WriteLine($"Name: {customerDto.FirstName} {customerDto.LastName}");
                Console.WriteLine($"Email: {customerDto.Email}\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
