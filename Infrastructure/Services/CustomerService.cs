using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



namespace Infrastructure.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly ProductCatalogueContext _context;

    public CustomerService(CustomerRepository customerRepository, ProductCatalogueContext context)
    {
        _customerRepository = customerRepository;
        _context = context;
    }

    public async Task<CustomersEntity> CreateCustomerAsync(CustomersEntity newCustomer)
    {
        try
        {
            var existingCustomer = await _customerRepository.GetOneAsync(x => x.Email == newCustomer.Email);

            if (existingCustomer == null)
            {
                var (securityKey, hashedPassword) = PasswordGenerator.GenerateSecurePassword(newCustomer.Password);

                var customerToCreate = new CustomersEntity
                {
                    CustomerId = newCustomer.CustomerId,
                    Email = newCustomer.Email,
                    Password = hashedPassword,
                    SecurityKey = securityKey,
                };

                await _customerRepository.AddAsync(customerToCreate);
                await _context.SaveChangesAsync();

                return customerToCreate;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while creating the address type with the address type Id");
        }
        return null!;
    }


    public async Task<CustomersEntity?> GetCustomerByEmailAsync(string customerEmail)
    {
        try
        {
            return await _customerRepository.GetCustomerByEmailRepAsync(customerEmail);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occurred while fetching customer using their email");
            return null;
        }
    }
    public async Task<CustomersEntity> GetCustomerByIdAsync(Guid customerId)
    {
        try
        {
            var customerEntity = await _customerRepository.GetOneAsync(x => x.CustomerId == customerId);

            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching customer using their Id");
        }
        return null!;
    }

    public async Task<IEnumerable<CustomersEntity>> GetAllCustomersAsync()
    {
        Console.Clear();
        try
        {
            var customers = await _customerRepository.GetAllAsync();

            if (customers != null)
            {
                return customers;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of customers");
        }
        return null!;
    }

    public async Task<CustomersEntity> UpdateCustomerAsync(CustomersEntity customerEntity)
    {
        try
        {
            var updatedCustomerEntity = await _customerRepository.UpdateAsync(x => x.CustomerId == customerEntity.CustomerId, customerEntity);

            if (updatedCustomerEntity != null)
            {
                return updatedCustomerEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the customer");
        }
        return null!;
    }

    public async Task<bool> DeleteCustomerAsync(CustomersEntity customerEntity)
    {
        try
        {
            if (customerEntity != null)
            {
                await _customerRepository.DeleteAsync(x => x.CustomerId == customerEntity.CustomerId, customerEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the customer");
        }
        return false;
    }
}

