using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CustomerDetailsService
{
    private readonly CustomerDetailsRepository _customerDetailsRepository;
    public CustomerDetailsService(CustomerDetailsRepository customerDetailsRepository)
    {
        _customerDetailsRepository = customerDetailsRepository;
    }


    public async Task<CustomerDetailsEntity> CreateCustomerDetailsAsync(CustomerDetailsEntity newCustomerDetails)
    {
        try
        {
            var existingCustomerDetails = await _customerDetailsRepository.GetOneAsync(x => x.CustomerId == newCustomerDetails.CustomerId);

            if (existingCustomerDetails == null)
            {
                var CustomerDetailsToCreate = new CustomerDetailsEntity
                {
                    CustomerId = newCustomerDetails.CustomerId,
                    FirstName = newCustomerDetails.FirstName,
                    LastName = newCustomerDetails.LastName,
                    PhoneNumber = newCustomerDetails.PhoneNumber

                };

                await _customerDetailsRepository.AddAsync(CustomerDetailsToCreate);

                return CustomerDetailsToCreate;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while creating the customers' details enitity with the customer details Id");
        }
        return null!;
    }

    public async Task<CustomerDetailsEntity> GetCustomerDetailsById(CustomerDetailsEntity Customer)
    {
        try
        {
            var CustomerDetailsToFind = await _customerDetailsRepository.GetOneAsync(x => x.CustomerId == Customer.CustomerId);

            if (CustomerDetailsToFind != null)
            {
                return CustomerDetailsToFind;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching customers' using their email");
        }
        return null!;
    }

    public async Task<CustomerDetailsEntity> GetCustomerDetailsById(Guid CustomerId)
    {
        try
        {
            var CustomerDetailsEntity = await _customerDetailsRepository.GetOneAsync(x => x.CustomerId == CustomerId);

            if (CustomerDetailsEntity != null)
            {
                return CustomerDetailsEntity;
            }
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching customers' details using their Id");
        }
        return null!;
    }

    public async Task<IEnumerable<CustomerDetailsEntity>> GetAllCustomersDetails()
    {
        try
        {
            var CustomerDetails = await _customerDetailsRepository.GetAllAsync();

            if (CustomerDetails != null)
            {
                return CustomerDetails;
            }
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of customers' details");
        }
        return null!;
    }

    public async Task<CustomerDetailsEntity> UpdateCustomerDetails(CustomerDetailsEntity CustomerDetailsEntity)
    {
        try
        {
            var updatedCustomerDetailsEntity = await _customerDetailsRepository.UpdateAsync(x => x.CustomerId == CustomerDetailsEntity.CustomerId, CustomerDetailsEntity);

            if (updatedCustomerDetailsEntity != null)
            {
                return updatedCustomerDetailsEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the customers' details");
        }
        return null!;
    }

    public async Task<bool> DeleteCustomerDetails(CustomerDetailsEntity CustomerDetailsEntity)
    {
        try
        {
            if (CustomerDetailsEntity != null)
            {
                await _customerDetailsRepository.DeleteAsync(x => x.CustomerId == CustomerDetailsEntity.CustomerId, CustomerDetailsEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the customer.");
        }
        return false;
    }

}
