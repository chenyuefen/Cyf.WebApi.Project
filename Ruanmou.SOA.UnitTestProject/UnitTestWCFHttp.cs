using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ruanmou.SOA.UnitTestProject
{
    [TestClass]
    public class UnitTestWCFHttp
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyConsoleWCFHttpTest.MathServiceClient client = null;
            try
            {
                client = new MyConsoleWCFHttpTest.MathServiceClient();
                var user = client.GetUser(1, 2);
                client.PlusInt(123, 234);
            }
            catch (Exception ex)
            {
                if (client != null)
                    client.Abort();//是为了应对网络断掉异常
                Console.WriteLine(ex.Message);
            }
        }
    }
}
