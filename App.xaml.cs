using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MyBooksManager.DataAccess;
using MyBooksManager.ViewModels;
using MyBooksManager.Views;


namespace MyBooksManager;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    //声明服务提供者
    private ServiceProvider _serviceProvider;

    public App()
    {
        //配置依赖注入容器
        var services = new ServiceCollection();
        ConfigureService(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureService(IServiceCollection services)
    {
        //注册数据库上下文
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=Books.db"));
        //注册仓储
        services.AddScoped<IBookRepository, BookRepository>();
        //注册ViewModel
        services.AddSingleton<MainViewModel>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        
        base.OnStartup(e);
        //手动创建主窗口并设置DataContext
        var mainWindow = new MainWindow();
        mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
        mainWindow.Show();
    }
}