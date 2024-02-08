using Services.CreateCustomerService;
using Services.CreateProductService;
namespace Presentation.Services;

public class MainMenuService
{

    private readonly GetAllCustomersService _getAllCustomerService;
    private readonly GetCustomerDetailsService _getCustomerDetailsService;
    private readonly CreateCustomerService _createCustomerService;
    private readonly GetAllProductsService _getAllProductsService;
    private readonly CreateProductService _createProductService;
    private readonly GetProductDetailsService _getProductDetailsService;


    public MainMenuService(GetAllCustomersService getAllCustomerService, GetCustomerDetailsService getCustomerDetailsService, CreateCustomerService createCustomerService, GetAllProductsService getAllProductsService, CreateProductService createProductService, GetProductDetailsService getProductDetailsService)
    {
        _getAllCustomerService = getAllCustomerService;
        _createCustomerService = createCustomerService;
        _getCustomerDetailsService = getCustomerDetailsService;
        _getAllProductsService = getAllProductsService;
        _createProductService = createProductService;
        _getProductDetailsService = getProductDetailsService;
    }

    public async Task MainMenuAsync()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.Clear();
            Console.WriteLine("***********************Customers and Products Application***********************");
            Console.WriteLine("To display Products press '1'.");
            Console.WriteLine("To display Customers press '2'.");
            Console.WriteLine("To exit, press '3'.");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    await MainMenuProductsAsync();
                    break;
                case "2":
                    await MainMenuCustomersAsync();
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

    public async Task MainMenuProductsAsync()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.Clear();
            await _getAllProductsService.GetAllProductsAsync();
            Console.WriteLine("***********************Products Application***********************");
            Console.WriteLine("To Add a Product to the list press '1'.");
            Console.WriteLine("To display a products's details press '2'.");
            Console.WriteLine("To exit, press '3'.");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    await _createProductService.CreateNewProductMenuAsync();
                    break;
                case "2":
                    await _getProductDetailsService.DisplayChoiceToShowDetailsAsync();
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

    public async Task MainMenuCustomersAsync()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.Clear();
            await _getAllCustomerService.GetAllCustomersAsync();
            Console.WriteLine("***********************Customers Application***********************");
            Console.WriteLine("To Add a Customer to the list press '1'.");
            Console.WriteLine("To display a customer's details press '2'.");
            Console.WriteLine("To exit, press '3'.");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    await _createCustomerService.CreateNewCustomerMenuAsync();
                    break;
                case "2":
                    await _getCustomerDetailsService.DisplayChoiceToShowDetailsAsync();
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
