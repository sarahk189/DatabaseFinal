using Infrastructure.Services;

namespace Presentation.Services;

public class DeleteCustomerService
{
    private readonly CustomerService _customerService;
    private readonly CustomerDetailsService _customerDetailsService;
    private readonly CustomerAddressesService _customerAddressService;
    private readonly AddressTypeService _addressTypeService;
    private readonly AddressesService _addressService;

    public DeleteCustomerService(CustomerService customerService, CustomerDetailsService customerDetailsService, CustomerAddressesService customerAddressService, AddressTypeService addressTypeService, AddressesService addressService)
    {
        _customerService = customerService;
        _customerDetailsService = customerDetailsService;
        _customerAddressService = customerAddressService;
        _addressTypeService = addressTypeService;
        _addressService = addressService;
    }

    public async Task DeleteCustomerByEmailAsync(string customerEmail)
    {
        var customer = await _customerService.GetCustomerByEmailAsync(customerEmail);
        if (customer != null)
        {
            var isDeleted = await _customerService.DeleteCustomerAsync(customer);
            if (isDeleted)
            {
                Console.WriteLine("Customer successfully deleted.");
            }
            else
            {
                Console.WriteLine("An error occurred while trying to delete the customer.");
            }
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

}
