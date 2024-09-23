using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameSorterService.Classes;
using NameSorterService.Interfaces;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddScoped<IApplication, Application>();
    services.AddScoped<INameSorter, NameSorter>();
    services.AddScoped<ITextFileHelper, TextFileHelper>();

}).Build();



var app = host.Services.GetRequiredService<IApplication>();

app.StartSortNamesProcess();