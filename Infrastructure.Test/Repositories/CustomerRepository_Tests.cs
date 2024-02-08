using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Test.Repositories;


//public class CustomerRepository_Tests
//{
//    private readonly CustomerCatalogueContext _context =
//        new(new DbContextOptionsBuilder<CustomerCatalogueContext>()
//        .UseInMemoryDatabase($"{Guid.NewGuid}")
//        .Options);

//    [Fact]
//    public async Add Should_Add_One_Customer_ToDatabase_And_Return_Updated_CustomerEntity()
//    {
//        //Arrange
//        var customerRepository = new CustomerRepository(_context);
//        var customerEntity = new CustomerEntity();


//        //Act
//        var result = customerRepository.CreateAsync(customerEntity);

//        //Assert
//        Assert.Null(result);
//    }
//}
