using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    // 定义一个路由为api/[controller]的TestController类
    [Route("api/[controller]")]
    // 定义该类为ApiController
    [ApiController]
    public class TestController : ControllerBase
    {
        // 定义一个HttpGet方法，用于获取Person对象
        [HttpGet]
        public Person GetPerson()
        {
            // 返回一个Person对象，姓名为钟凯，年龄为18
            return new Person("钟凯",18);
        }
        // 定义一个HttpPost方法，用于保存Note
        [HttpPost]
        public string SaveNote( SaveNoteRequest req)
        {
            // 将请求中的Title和Content写入文件
            System.IO.File.WriteAllText(req.Title+".txt", req.Content);
            // 返回ok
            return "ok";  
        }
    }
}
