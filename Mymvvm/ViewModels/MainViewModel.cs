using Mymvvm.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mymvvm.ViewModels
{
    public class MainViewModel : NotifyBase
    {
        private int _value;



        public int Value
        {
            // 获取值
            get { return _value; }
            // 设置值
            set
            {
                // 设置属性值
                SetProperty<int>(ref _value, value);


            }

        }



        // 构造函数
        public MainViewModel()
        {
            // 设置初始值
            Value = 123;
            // 运行异步任务
            Task.Run(async () =>
            {
                // 无限循环
                while (true)
                {
                    // 延迟1秒
                    await Task.Delay(1000);
                    // 值加1
                    Value++;
                }
            });

        }
    }
}
