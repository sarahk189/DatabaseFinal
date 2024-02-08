using Infrastructure.Dtos;
using Infrastructure.Services;

namespace Presentation.Services;

public class GetCustomerDetailsService
{

    private readonly CustomerService _customerService;
    private readonly UpdateCustomerService _updateCustomerService;
    private readonly DeleteCustomerService _deleteCustomerService;


    public GetCustomerDetailsService(CustomerService customerService, UpdateCustomerService updateCustomerService, DeleteCustomerService deleteCustomerService)
    {
        _customerService = customerService;
        _updateCustomerService = updateCustomerService;
        _deleteCustomerService = deleteCustomerService;
    }

    public async Task DisplayChoiceToShowDetailsAsync()
    {
        Console.Write("Write in customer's email, to display it's details:  ");
        try
        {
            var customerEmail = Console.ReadLine()!;
            if (customerEmail != null)
            {
                var customersDetails = GetCustomerDetailsAsync(customerEmail);
                await customersDetails;
            }
            else
            {
                Console.WriteLine("Please provide a customer's email.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error; {ex.Message}");
        }
    }

    public async Task GetCustomerDetailsAsync(string customerEmail)
    {
        Console.Clear();
        try
        {
            var customer = await _customerService.GetCustomerByEmailAsync(customerEmail);
            if (customer != null)
            {
                if (customer.CustomerAddresses.Any())
                {
                    var firstAddress = customer.CustomerAddresses.FirstOrDefault()?.AddressEntity;
                    var addressType = firstAddress?.AddressType;

                    var customerDto = CustomerDto.FromCustomerEntity(customer, firstAddress, addressType);
                    Console.Clear();
                    Console.WriteLine($"ID: {customerDto.Id}, Name: {customerDto.FirstName} {customerDto.LastName}, Email: {customerDto.Email}, Phone: {customerDto.PhoneNumber}, Street Name: {customerDto.StreetName}, Postal Code: {customerDto.PostalCode}, City: {customerDto.City}, AddressType: {customerDto.AddressType}");
                    bool continueRunning = true;
                    while (continueRunning)
                    {
                        Console.WriteLine("To Update the Customer press '1'.");
                        Console.WriteLine("To Delete the Customer press '2'.");
                        Console.WriteLine("To exit back to the Main Menu, press '3'.");

                        string choice = Console.ReadLine()!;

                        switch (choice)
                        {
                            case "1":
                                await _updateCustomerService.UpdateCustomerAsync(customerEmail);
                                break;
                            case "2":
                                await _deleteCustomerService.DeleteCustomerByEmailAsync(customerEmail);
                                break;
                            case "3":
                                continueRunning = false;
                                Console.WriteLine("Exiting application...");
                                break;
                            default:
                                Console.WriteLine("Please type in a valid choice.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Customer found but no addresses associated. ID: {customer.CustomerId}, Name: {customer.CustomerDetails.FirstName} {customer.CustomerDetails.LastName}, Email: {customer.Email}");
                    bool continueRunning = true;
                    while (continueRunning)
                    {
                        Console.WriteLine("To Update the Customer press '1'.");
                        Console.WriteLine("To Delete the Customer press '2'.");
                        Console.WriteLine("To exit back to the Main Menu, press '3'.");

                        string choice = Console.ReadLine()!;

                        switch (choice)
                        {
                            case "1":
                                await _updateCustomerService.UpdateCustomerAsync(customerEmail);
                                break;
                            case "2":
                                await _deleteCustomerService.DeleteCustomerByEmailAsync(customerEmail);
                                break;
                            case "3":
                                continueRunning = false;
                                Console.WriteLine("Exiting application...");
                                break;
                            default:
                                Console.WriteLine("Please type in a valid choice.");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }



}
