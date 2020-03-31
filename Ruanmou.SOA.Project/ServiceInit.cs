using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SOA.WCF.Service;
using SOA.WCF.Interface;
using System.ServiceModel.Description;

namespace Ruanmou.SOA.Project
{
    public class ServiceInit
    {
        public static void Process()
        {
            //ServiceHost对象
            List<ServiceHost> hosts = new List<ServiceHost>()
            {
                new ServiceHost(typeof(MathService)),
                new ServiceHost(typeof(CalculatorService))
            };
            foreach (var host in hosts)
            {
                host.Opening += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备打开");
                host.Opened += (s, e) => Console.WriteLine($"{host.GetType().Name} 已经正常打开");
                host.Closing += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备关闭");
                host.Closed += (s, e) => Console.WriteLine($"{host.GetType().Name} 准备关闭");

                host.Open();
            }
            Console.WriteLine("输入任何字符，就停止");
            Console.Read();
            foreach (var host in hosts)
            {
                host.Close();
            }
            Console.Read();


            #region MyRegion
            //using (ServiceHost host = new ServiceHost(typeof(MathService)))
            //{
            //    #region 程序配置
            //    host.AddServiceEndpoint(typeof(IMathService), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");
            //    if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            //    {
            //        ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //        behavior.HttpGetEnabled = true;
            //        behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
            //        host.Description.Behaviors.Add(behavior);
            //    }
            //    #endregion 程序配置
            //    host.Opened += (s, e) =>
            //    {
            //        Console.WriteLine("MathService已经启动，按任意键终止服务！");
            //    };

            //    host.Open();
            //    Console.Read();
            //}

            #endregion
        }

        private static void Host_Closing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
