using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Services;

public class PersonCategoryService
{
    private readonly PersonCategoryRepository _personCategoryRepository;
    private readonly ProductCatalogueContext _context;

    public PersonCategoryService(PersonCategoryRepository personCategoryRepository, ProductCatalogueContext context)
    {
        _personCategoryRepository = personCategoryRepository;
        _context = context;
    }

    public async Task<PersonCategory> CreatePersonCategoryAsync(string personCategoryName)
    {

        var existingPersonCategory = await _context.PersonCategories
            .FirstOrDefaultAsync(c => c.PersonCategoryName == personCategoryName);

        if (existingPersonCategory != null)
        {
  
            return existingPersonCategory;
        }
        else
        {
    
            var newPersonCategory = new PersonCategory { PersonCategoryName = personCategoryName };
            _context.PersonCategories.Add(newPersonCategory);
            await _context.SaveChangesAsync();
            return newPersonCategory;
        }
    }


    public async Task<PersonCategory> GetProductByIdAsync(int personCategoryId)
    {
        try
        {
            var customerEntity = await _personCategoryRepository.GetOneAsync(x => x.PersonCategoryId == personCategoryId);

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

    public async Task<IEnumerable<PersonCategory>> GetAllProductsAsync()
    {
        Console.Clear();
        try
        {
            var personCategories = await _personCategoryRepository.GetAllAsync();

            if (personCategories != null)
            {
                return personCategories;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while fetching the list of customers");
        }
        return null!;
    }

    public async Task<PersonCategory> UpdateProductAsync(PersonCategory personCategory)
    {
        try
        {
            var updatedPersonCategory = await _personCategoryRepository.UpdateAsync(x => x.PersonCategoryId == personCategory.PersonCategoryId, personCategory);

            if (updatedPersonCategory != null)
            {
                return updatedPersonCategory;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Console.WriteLine("Error occured while updating the customer");
        }
        return null!;
    }

    public async Task<bool> DeletePersonCategoryAsync(PersonCategory personCategory)
    {
        try
        {
            if (personCategory != null)
            {
                await _personCategoryRepository.DeleteAsync(x => x.PersonCategoryId == personCategory.PersonCategoryId, personCategory);
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

    public async Task<PersonCategory> EnsurePersonCategoryExistsAsync(string personCategoryName)
    {
        var category = await _context.PersonCategories
            .FirstOrDefaultAsync(c => c.PersonCategoryName == personCategoryName);

        if (category == null)
        {
            category = new PersonCategory { PersonCategoryName = personCategoryName };
            _context.PersonCategories.Add(category);
            await _context.SaveChangesAsync();
        }
        return category;
    }
}
