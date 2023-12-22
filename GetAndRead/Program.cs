using GetAndRead.Shared.Services;
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

