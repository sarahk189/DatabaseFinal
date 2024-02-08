using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class AddressesService
{
    private readonly AddressesRepository _addressRepository;

    public AddressesService(AddressesRepository addressRepository)
    {
        _addressRepository = addressRepository;

    }
    public async Task<AddressesEntity> CreateAddressAsync(AddressesEntity newAddress)
    {
        try
        {
            var existingAddress = await _addressRepository.GetOneAsync(x => x.AddressId == newAddress.AddressId);

            if (existingAddress == null)
            {
                var addressToCreate = new AddressesEntity
                {
                    StreetName = newAddress.StreetName,
                    PostalCode = newAddress.PostalCode,
                    City = newAddress.City,
                    AddressTypeId = newAddress.AddressTypeId

                };

                await _addressRepository.AddAsync(addressToCreate);

                return addressToCreate;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while creating address with the address Id");
        }
        return null!;
    }

    public async Task<AddressesEntity> GetAddressByIdAsync(int addressId)
    {
        try
        {
            var addressToFind = await _addressRepository.GetOneAsync(x => x.AddressId == addressId);

            if (addressToFind != null)
            {
                return addressToFind;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching customer using their email");
        }
        return null!;
    }

    public async Task<IEnumerable<AddressesEntity>> GetAddressesAsync()
    {
        try
        {
            var addresses = await _addressRepository.GetAllAsync();

            if (addresses != null)
            {
                return addresses;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of addresses");
        }
        return null!;
    }

    public async Task<AddressesEntity> UpdateAddressAsync(AddressesEntity addressEntity)
    {
        try
        {
            var updatedAddressEntity = await _addressRepository.UpdateAsync(x => x.AddressId == addressEntity.AddressId, addressEntity);

            if (updatedAddressEntity != null)
            {
                return updatedAddressEntity;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the address");
        }
        return null!;
    }

    public async Task<bool> DeleteAddressAsync(AddressesEntity addressEntity)
    {
        try
        {
            if (addressEntity != null)
            {
                await _addressRepository.DeleteAsync(x => x.AddressId == addressEntity.AddressId, addressEntity);
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while deleting the address");
        }
        return false;
    }
}
