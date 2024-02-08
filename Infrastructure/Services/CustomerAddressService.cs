using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CustomerAddressesService
{

    private readonly CustomerAddressRepository _customerAddressRepository;

    public CustomerAddressesService(CustomerAddressRepository customerAddressRepository)
    {
        _customerAddressRepository = customerAddressRepository;
    }

    public async Task<CustomerAddressesEntity> CreateCustomerAddressAsync(CustomerAddressesEntity newCustomerAddress)
    {
        try
        {
            var customerAddressToCreate = new CustomerAddressesEntity
            {
                CustomerAddressId = Guid.NewGuid(), 
                CustomerId = newCustomerAddress.CustomerId, 
                AddressId = newCustomerAddress.AddressId
            };

            await _customerAddressRepository.AddAsync(customerAddressToCreate);
            return customerAddressToCreate;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occurred while creating the customer address entity");
        }
        return null!;
    }

    public async Task<CustomerAddressesEntity> GetCustomerAddressById(CustomerAddressesEntity Customer)
    {
        try
        {
            var CustomerAddressToFind = await _customerAddressRepository.GetOneAsync(x => x.CustomerAddressId == Customer.CustomerAddressId);

            if (CustomerAddressToFind != null)
            {
                return CustomerAddressToFind;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching customers' using their email");
        }
        return null!;
    }

    public async Task<CustomerAddressesEntity> GetCustomerAddressById(Guid CustomerId)
    {
        try
        {
            var CustomerAddressesEntity = await _customerAddressRepository.GetOneAsync(x => x.CustomerAddressId == CustomerId);

            if (CustomerAddressesEntity != null)
            {
                return CustomerAddressesEntity;
            }
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching customers' address using their Id");
        }
        return null!;
    }

    public async Task<IEnumerable<CustomerAddressesEntity>> GetAllCustomersAddress()
    {
        try
        {
            var CustomerAddress = await _customerAddressRepository.GetAllAsync();

            if (CustomerAddress != null)
            {
                return CustomerAddress;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of customers' address");
        }
        return null!;
    }

    public async Task<CustomerAddressesEntity> UpdateCustomerAddress(CustomerAddressesEntity CustomerAddressesEntity)
    {
        try
        {
            var updatedCustomerAddressesEntity = await _customerAddressRepository.UpdateAsync(x => x.CustomerAddressId == CustomerAddressesEntity.CustomerAddressId, CustomerAddressesEntity);

            if (updatedCustomerAddressesEntity != null)
            {
                return updatedCustomerAddressesEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the customers' address");
        }
        return null!;
    }

    public async Task<bool> DeleteCustomerAddress(CustomerAddressesEntity CustomerAddressesEntity)
    {
        try
        {
            if (CustomerAddressesEntity != null)
            {
                await _customerAddressRepository.DeleteAsync(x => x.CustomerAddressId == CustomerAddressesEntity.CustomerAddressId, CustomerAddressesEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the customers' address");
        }
        return false;
    }
}
