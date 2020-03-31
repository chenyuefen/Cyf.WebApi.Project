using Ruanmou.SOA.Interface;
using Ruanmou.SOA.Service;
using Ruanmou.SOA.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace Ruanmou.SOA.Web.Controllers
{
    public class IOCController : ApiController
    {
        private IUserService _UserService = null;
        public IOCController(IUserService userService)
        {
            this._UserService = userService;
        }

        public string Get(int id)
        {
            //IUserService service = new UserService();
            //IUserService service = ContainerFactory.BuildContainer().Resolve<IUserService>();
            return Newtonsoft.Json.JsonConvert.SerializeObject(this._UserService.Query(id));
        }
    }
}
