namespace 文件流方式读写文件
{
    using System.Text;

   
        internal class Program
        {
            static void Main(string[] args)
            {
                // 定义文件路径
                string path = @"C:\Users\Administrator.DESKTOP-9T1AJL4\Desktop\test.txt";
                // 调用写入文件方法
                WriteFile(path);
                // 调用读取文件方法
                ReadFile(path);
            }
            // 读取文件方法
            public static void ReadFile(string path)
            {
                // 创建文件流，以只读方式打开文件
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    // 创建一个缓冲区，大小为5MB
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    // 读取文件内容到缓冲区
                    int r = fs.Read(buffer, 0, buffer.Length);
                    // 将缓冲区内容转换为字符串
                    string content = Encoding.UTF8.GetString(buffer, 0, r);
                    // 输出文件内容
                    Console.WriteLine(content);
                    // 等待用户按下任意键
                    Console.ReadKey();
                }

            }
            // 写入文件方法
            public static void WriteFile(string path)
            {
                // 创建文件流，以写入方式打开文件
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    // 定义要写入文件的内容
                    string content = "我是写入的文字";
                    // 将字符串转换为字节数组
                    byte[] buffer = Encoding.UTF8.GetBytes(content);
                    // 将字节数组写入文件
                    fs.Write(buffer, 0, buffer.Length);
                    // 输出写入成功信息
                    Console.WriteLine("写入成功");
                    // 等待用户按下任意键
                    Console.ReadKey();
                }
            }
        }
    

}
