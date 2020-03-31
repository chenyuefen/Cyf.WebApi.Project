using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ruanmou.SOA.UnitTestProject
{
    [TestClass]
    public class UnitTestWCF
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i = 3 + 4;

            MyWCFTest.CustomServiceClient client = null;
            try
            {
                client = new MyWCFTest.CustomServiceClient();
                int iResult = client.Get();
                //int iResult2 = client.GetNoAttribuet();
                var user = client.GetUser();
                client.Close();
            }
            catch (Exception ex)
            {
                if (client != null)
                    client.Abort();//是为了应对网络断掉异常
                Console.WriteLine(ex.Message);
            }

            //using (MyWCFTest.CustomServiceClient client = new MyWCFTest.CustomServiceClient())
            //{
            //    client.DoWork();
            //    int iResult = client.Get();
            //    //int iResult2 = client.GetNoAttribuet();
            //    var user = client.GetUser();
            //}
        }
    }
}
