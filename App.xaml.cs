using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBook2.Data;
using MyBook2.ViewModels;

namespace MyBook2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider _serviceProvider;
    
    public App()
    {
        var services=new ServiceCollection();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=Books.db");
        });
        services.AddScoped<IBookRepository,BookRepository>();
        services.AddSingleton<MainViewModel>();
        _serviceProvider=services.BuildServiceProvider();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel=_serviceProvider.GetService<MainViewModel>();
        var mainWindow=new MainWindow
        {
            DataContext=mainViewModel
        };
        mainWindow.Show();
        base.OnStartup(e);
    }
}