using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Infrastructure.Services;
using Infrastructure.Entities;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using DatabaseFinalApp.Mvvm.Views;
using DatabaseFinalApp.Interfaces;

namespace DatabaseFinalApp.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly CustomerService _customerService;
    private readonly AddressService _addressService;
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ObservableCollection<CustomerDto> customers;

    [ObservableProperty]
    private ObservableCollection<CustomerDto> _customerList = [];

    [ObservableProperty]
    private CustomerEntity? _customerEntity;

    public MainViewModel(CustomerService customerService, AddressService addressService)
    {
        _customerService = customerService;
        _addressService = addressService;
        _navigationService = navigationService;

        UpdateCustomerCommand = new AsyncRelayCommand<CustomerDto>(UpdateCustomerAsync);
        DeleteCustomerCommand = new AsyncRelayCommand<CustomerDto>(DeleteCustomerAsync);
        NavigateToAddCustomerCommand = new RelayCommand(NavigateToAddCustomer);
        NavigateToDetailsCommand = new RelayCommand<CustomerDto>(NavigateToDetails);
    }

    public ICommand NavigateToAddCustomerCommand { get; }
    public ICommand NavigateToDetailsCommand { get; }


    [RelayCommand]
    private async Task LoadCustomersAsync()
    {
        try
        {
            var customerEntities = await _customerService.GetAllCustomersAsync();
            CustomerList.Clear();

            foreach (var entity in customerEntities)
            {
                var firstAddress = entity.CustomerAddresses.FirstOrDefault()?.AddressEntity;

                CustomerList.Add(new CustomerDto
                {
                    FirstName = entity.CustomerDetails.FirstName,
                    LastName = entity.CustomerDetails.LastName,
                    Email = entity.Email,
                    PhoneNumber = entity.CustomerDetails.PhoneNumber,
                    StreetName = firstAddress?.StreetName,
                    PostalCode = firstAddress?.PostalCode,
                    City = firstAddress?.City,
                });
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred while loading customers: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task UpdateCustomerAsync(CustomerDto customer)
    {
        // Convert DTO to entity and call _customerService.UpdateCustomerAsync
    }

    [RelayCommand]
    private async Task DeleteCustomerAsync(CustomerDto customer)
    {
        // Convert DTO to entity and call _customerService.DeleteCustomerAsync
    }


    [RelayCommand]
    private void NavigateToAddCustomer()
    {
        _navigationService.NavigateToAddCustomer();
    }

    private void NavigateToDetails(CustomerDto customer)
    {
        if (customer != null)
        {
            _navigationService.NavigateToCustomerDetails(customer.Email);
        }
    }

}

