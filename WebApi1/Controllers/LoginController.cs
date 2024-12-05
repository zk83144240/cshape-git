using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public LoginResponse Login(LoginRequest req)
        {
            //验证用户名和密码
            if (req.Username == "admin" && req.Password == "123456")
            {
                //返回进程信息
                var items = Process.GetProcesses().Select(p => new ProcessInfo(p.Id, p.ProcessName, p.WorkingSet64)).ToArray();
                return new LoginResponse(true, items.ToArray());
            }
            else
            {
                return new LoginResponse(false, null);
            }
        }
    }
    //创建用户登录类
    public record LoginRequest(string Username, string Password);
    //创建进程信息类
    public record ProcessInfo(long Id, string Name, long MemoryUsage);
    //创建用户登录响应类
    public record LoginResponse(bool ok,ProcessInfo[] ProcessInfos);
}
