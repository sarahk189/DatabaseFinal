using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AddressTypeService
{
    private readonly AddressTypeRepository _addressTypeRepository;
    private readonly CustomerCatalogueContext _context;

    public AddressTypeService(AddressTypeRepository addressTypeRepository, CustomerCatalogueContext customerCatalogueContext)
    {
        _addressTypeRepository = addressTypeRepository;
        _context = customerCatalogueContext;
    }

    public async Task<AddressTypeEntity> CreateAddressTypeAsync(AddressTypeEntity newAddressType)
    {
        try
        {
            var existingAddressType = await _addressTypeRepository.GetOneAsync(x => x.AddressType == newAddressType.AddressType);

            if (existingAddressType == null)
            {
                var addressTypesToCreate = new AddressTypeEntity
                {
                    AddressTypeId = newAddressType.AddressTypeId,
                    AddressType = newAddressType.AddressType
                };

                await _addressTypeRepository.AddAsync(addressTypesToCreate);
                await _context.SaveChangesAsync();

                return addressTypesToCreate;
            }
            return existingAddressType;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while creating the address type with the address type Id");
        }
        return null!;
    }

    public async Task<AddressTypeEntity> GetAddressTypesByNameAsync(string addressType)
    {
        try
        {
            var addressTypeToFind = await _addressTypeRepository.GetOneAsync(x => x.AddressType == addressType);

            if (addressTypeToFind != null)
            {
                return addressTypeToFind;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occurred while fetching address type by using the address type name");
        }
        return null!;
    }

    public async Task<AddressTypeEntity> GetAddressTypesByIdAsync(int addressTypeId)
    {
        try
        {
            var addressTypeToFind = await _addressTypeRepository.GetOneAsync(x => x.AddressTypeId == addressTypeId);

            if (addressTypeToFind != null)
            {
                return addressTypeToFind;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occurred while fetching address type by using the address type Id");
        }
        return null!;
    }

    public async Task<IEnumerable<AddressTypeEntity>> GetAddressTypesAsync()
    {
        try
        {
            var addressType = await _addressTypeRepository.GetAllAsync();

            if (addressType != null)
            {
                return addressType;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of address types");
        }
        return null!;
    }

    public async Task<AddressTypeEntity> UpdateAddressTypesAsync(AddressTypeEntity addressTypeEntity)
    {
        try
        {
            var updatedAddressTypeEntity = await _addressTypeRepository.UpdateAsync(x => x.AddressTypeId == addressTypeEntity.AddressTypeId, addressTypeEntity);

            if (updatedAddressTypeEntity != null)
            {
                return updatedAddressTypeEntity;
            }
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the address type");
        }
        return null!;
    }

    public async Task<bool> DeleteAddressTypesAsync(AddressTypeEntity addressTypeEntity)
    {
        try
        {
            if (addressTypeEntity != null)
            {
                await _addressTypeRepository.DeleteAsync(x => x.AddressTypeId == addressTypeEntity.AddressTypeId, addressTypeEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the address type");
        }
        return false;
    }

}
