using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCommunity
{
    partial class MyCommunityToolKit : ObservableObject
    {
        //private string _Sn1;
        //public string Sn1
        //{
        //    get=> _Sn1;
        //    set => SetProperty(ref _Sn1, value);
        //}
        //private string _Sn;
        //public string Sn
        //{
        //    get => _Sn;
        //    set => SetProperty(ref _Sn, value);
        //}
        //public RelayCommand GetSnCommand { get; }
        //public MyCommunityToolKit()
        //{
        //     GetSnCommand = new RelayCommand(GetSn);
        //}
        //private void GetSn()
        //{
        //    Sn = Regex.Match(Sn1, @"sn=(\d+)").Groups[1].Value;
        //}
        //定义一个私有字符串变量_Sn1
        private string _Sn1;
        //定义一个公共字符串属性Sn1，用于获取和设置_Sn1的值
        public string Sn1
        {
            get=> _Sn1;
            set => SetProperty(ref _Sn1, value);
        }
        //定义一个私有字符串变量_Sn
        private string _Sn;
        //定义一个公共字符串属性Sn，用于获取和设置_Sn的值
        public string Sn
        {
            get => _Sn;
            set => SetProperty(ref _Sn, value);
        }
        //定义一个公共的RelayCommand属性GetSnCommand
        public RelayCommand GetSnCommand { get; }
        //在构造函数中初始化GetSnCommand属性，并传入GetSn方法
        public MyCommunityToolKit()
        {
             GetSnCommand = new RelayCommand(GetSn);
        }
        //定义一个私有方法GetSn，用于获取Sn1中的sn值，并将其赋值给Sn
        private void GetSn()
        {
            Sn = Regex.Match(Sn1, @"sn=(\d+)").Groups[1].Value;
        }
        
    }   
}
       
