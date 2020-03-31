using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Ruanmou.SOA.Web.Remote
{
    /// <summary>
    /// MyWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]

    public class MyWebService : System.Web.Services.WebService
    {
        public CustomSoapHeader SoapHeaderProp { get; set; }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HelloWorldWithAuth(string name_password)
        {
            if (true) { }
            return "Hello World";
        }
        [WebMethod]
        public string GetName(int i)
        {
            return $"{i}加菲猫";
        }
        [WebMethod]//webservice的方法就没有重载
        public int Plus(int x, int y)
        {
            return x + y;
        }
        [WebMethod]
        [SoapHeader("SoapHeaderProp")]
        public string GetInfo(int id, string name)
        {
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Id = id,
                Name = name,
                Remark = $"This is {id} {name}"
            });
        }

        [WebMethod]
        [SoapHeader("SoapHeaderProp")]
        public UserInfo GetUser(int id)
        {
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return new UserInfo()
            {
                Id = id,
                Name = "楠nan",
                Age = 27
            };
        }
        [WebMethod]
        [SoapHeader("SoapHeaderProp")]
        public List<UserInfo> GetUserList()
        {
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return new List<UserInfo>()
            {
                new UserInfo()
                {
                    Id = 3,
                    Name = "一路有你",
                    Age = 27
                },
                    new UserInfo()
                {
                    Id = 2,
                    Name = "感谢有梦",
                    Age = 25
                }
            };
        }

    }
}
