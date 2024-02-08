using DatabaseFinalApp.Mvvm.ViewModels;
using DatabaseFinalApp.Mvvm.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DatabaseFinalApp;


public partial class App : Application
{
    private static IHost? builder;

    public App()
    {
        builder = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<AddCustomerView>();
                services.AddSingleton<AddCustomerViewModel>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        builder!.Start();

        var mainWindow = builder!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();


    }

}
