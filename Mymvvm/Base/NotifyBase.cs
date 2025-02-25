using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mymvvm.Base
{
   // 定义一个继承自INotifyPropertyChanged的类
   public class NotifyBase : INotifyPropertyChanged
    {
        // 定义一个PropertyChanged事件
        public event PropertyChangedEventHandler? PropertyChanged;
        // 定义一个泛型方法，用于设置属性值
        public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            // 如果属性值发生变化或者属性值为null，则更新属性值并触发PropertyChanged事件
            if (!Equals(field, value)|| field == null)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
