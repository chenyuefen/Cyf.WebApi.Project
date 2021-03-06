﻿using Ruanmou.SOA.Web.Utility;
using Ruanmou.SOA.Web.Utility.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace Ruanmou.SOA.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.DependencyResolver = new UnityDependencyResolver(ContainerFactory.BuildContainer());

            //config.Filters.Add(new CustomBasicAuthorizeAttribute());//全局注册
            
            config.Filters.Add(new CustomExceptionFilterAttribute());//全局异常特性

            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());//替换全局异常处理类

            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));//全部都允许 - 跨域请求 ，安装Cors

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
             name: "CustomApi",//默认的api路由
             routeTemplate: "api/{controller}/{action}/{id}",//正则规则，以api开头，第二个是控制器  第三个是参数
             defaults: new { id = RouteParameter.Optional }
         );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",//默认的api路由
            //    routeTemplate: "api/{controller}/{id}",//正则规则，以api开头，第二个是控制器  第三个是参数
            //    defaults: new { id = RouteParameter.Optional }
            //);


        }
    }
}
