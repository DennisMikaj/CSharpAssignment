using GetAndRead.Models;
using GetAndRead.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<CustomerServices>();
    services.AddSingleton<FileService>();
    services.AddTransient<MenuService>();

}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();

menuService.DisplayMenu();

/* var customerService = new CustomerServices();

var list = customerService.GetCustomersFromList();
foreach (var l1 in list)
{
    Console.WriteLine($"{l1.FirstName} {l1.LastName} <{l1.Email}>");
}

Console.ReadKey();
Console.WriteLine();

customerService.AddCustomerToList(new GetAndRead.Models.Customer { FirstName = "Wilma" }); */


