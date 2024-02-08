using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Services;
using Services.CreateCustomerService;
using Services.CreateProductService;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<CustomerCatalogueContext>(x => x.UseSqlServer(@"Data Source=SarahsLaptop;Initial Catalog=customercatalogue_;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
    services.AddDbContext<ProductCatalogueContext>(x => x.UseSqlServer(@"Data Source=SarahsLaptop;Initial Catalog=productcatalogue_;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
    services.AddScoped<AddressesRepository>();
    services.AddScoped<AddressTypeRepository>();
    services.AddScoped<CustomerAddressRepository>();
    services.AddScoped<CustomerDetailsRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ProductCategoryRepository>();
    services.AddScoped<SizeRepository>();
    services.AddScoped<PersonCategoryRepository>();
    services.AddScoped<ProductBrandRepository>();

    services.AddScoped<AddressesService>();
    services.AddScoped<AddressTypeService>();
    services.AddScoped<CustomerAddressesService>();
    services.AddScoped<CustomerDetailsService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ProductService>();
    services.AddScoped<SizeService>();
    services.AddScoped<PersonCategoryService>();
    services.AddScoped<ProductCategoryService>();
    services.AddScoped<ProductBrandService>();

    services.AddScoped<PasswordGenerator>();
    services.AddTransient<CreateCustomerService>();
    services.AddTransient<MainMenuService>();
    services.AddTransient<GetCustomerDetailsService>();
    services.AddTransient<GetAllCustomersService>();
    services.AddTransient<UpdateCustomerService>();
    services.AddTransient<DeleteCustomerService>();
    services.AddTransient<CreateProductService>();
    services.AddTransient<GetProductDetailsService>();
    services.AddTransient<GetAllProductsService>();
    services.AddTransient<UpdateProductService>();
    services.AddTransient<DeleteProductService>();

}).Build();

var mainMenuService = builder.Services.GetRequiredService<MainMenuService>();
await mainMenuService.MainMenuAsync();

