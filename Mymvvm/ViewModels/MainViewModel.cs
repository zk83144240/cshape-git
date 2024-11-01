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
            get { return _value; }
            set
            {
                SetProperty<int>(ref _value, value);


            }

        }



        public MainViewModel()
        {
            Value = 123;
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    Value++;
                }
            });

        }
    }
}
