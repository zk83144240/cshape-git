using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog日志
{
    internal class Test1
    { 
        private readonly ILogger<Test1> logger;
        public Test1(ILogger<Test1> logger)
        {
            this.logger = logger;
        }
        public void Test()
        {
            logger.LogWarning("测试日志");
            logger.LogTrace("测试日志");
            logger.LogError("测试日志");
            logger.LogInformation("测试日志");
        }
    }
    
}
