using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace NLog日志
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //安装引入DI包:Microsoft.Extensions.DependencyInjection
               //安装引入NLog包:NLog.Extensions.Logging
             
            ServiceCollection services = new ServiceCollection();
            //注册日志服务
            services.AddLogging(builder =>
            {
                builder.AddNLog();
                builder.AddConsole();
            });
            //注册Test1服务
            // 将Test1注册为Scoped服务
            services.AddScoped<Test1>();

            // 构建服务提供者
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // 从服务提供者中获取Test1服务
                Test1 test1 = serviceProvider.GetRequiredService<Test1>();
                // 调用Test1的Test方法
                test1.Test();
            }
             
        }
    }
}
