using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_计算器
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //存储第一个数字
        private double _firstNumber=0;
        //储存当前选择的操作符
        private string _operator = "";
        //标记是否开始了一个新的操作
        private bool _isNewOperation = true;
        public MainWindow()
        {
            //初始化窗口
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        //数字按钮点击事件
        private void OnClick(object sender, RoutedEventArgs e)
        {
            //获取被点击的按钮对象
            var button = sender as Button;
            //如果当前是新的操作，则清空显示并标记为非新操作
            if(_isNewOperation)
            {
                txtResult.Text = "";
                _isNewOperation = false;
            }
            //将按钮的文本追加到显示框中
            txtResult.Text += button.Content.ToString();

        }
        //操作符按钮点击事件
        private void OnOperatorClick(object sender, RoutedEventArgs e)
        {
            //获取被点击的按钮对象
            var button = sender as Button;
            //设置当前操作符
            _operator = button.Content.ToString();
            //将第一个数字设置为当前显示框中的值
            _firstNumber = double.Parse(txtResult.Text);
            //标记为新的操作
            _isNewOperation = true;

        }
        //等号按钮点击事件
        private void OnEqualClick(object sender, RoutedEventArgs e)
        {
            //如果有选择操作符
            if(_operator != "")
            {
                //获取第二个数字
                var secondNumber = double.Parse(txtResult.Text);
                //根据操作符进行计算
                switch (_operator)
                {
                    //加法
                    case "+":
                        txtResult.Text = (_firstNumber + secondNumber).ToString();
                        break;
                    //减法
                    case "-":
                        txtResult.Text = (_firstNumber - secondNumber).ToString();
                        break;
                    //乘法
                    case "*":
                        txtResult.Text = (_firstNumber * secondNumber).ToString();
                        break;  
                    //除法
                    case "/":
                        //防止除数为0
                        if(secondNumber != 0)
                        {
                            txtResult.Text = (_firstNumber / secondNumber).ToString();

                        }
                        else
                        {
                            txtResult.Text = "除数不能为0";
                        }
                        break;
                }
                //清空操作符
                _operator = "";
                //标记为新的操作
                _isNewOperation = true;
            }
        }
        //清除按钮点击事件
        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            //清空显示框
            txtResult.Text = "";
            //清空操作符
            _operator = "";
            //第一个数字重置为0
            _firstNumber = 0;
            //标记为新的操作
            _isNewOperation = true;
        }
        //小数点按钮点击事件
        private void OnDecimalClick(object sender, RoutedEventArgs e)
        {
            //如果当前显示框没有小数点且不是新操作
            if (!txtResult.Text.Contains(".")&& !_isNewOperation)
            {
                //在显示框中添加小数点
                txtResult.Text += ".";
            }
        }
    }
}