using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ruanmou.SOA.Web.Remote
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CustomService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CustomService.svc 或 CustomService.svc.cs，然后开始调试。
    public class CustomService : ICustomService
    {
        public void DoWork()
        {
            Console.WriteLine("1234");
        }

        public int Get()
        {
            return DateTime.Now.Year;
        }

        public int GetNoAttribuet()
        {
            return DateTime.Now.Year;
        }

        public UserInfo GetUser()
        {
            return new UserInfo()
            {
                Id = 123,
                Name = "董小姐",
                Age = 19
            };
        }
    }
}
