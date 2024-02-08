using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(services =>
{

    services.AddDbContext<CustomerCatalogueContext>(x => x.UseSqlServer(@"Data Source=SarahsLaptop;Initial Catalog=customercatalogue_;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

});

builder.Build();

