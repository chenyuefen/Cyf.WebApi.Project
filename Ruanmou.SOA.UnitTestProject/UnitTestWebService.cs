using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ruanmou.SOA.UnitTestProject
{
    /// <summary>
    /// svcUtil.exe
    /// </summary>
    [TestClass]
    public class UnitTestWebService
    {
        static UnitTestWebService()
        {
            Console.WriteLine("完成静态构造函数");
        }

        [TestInitialize]//初始化
        public void Initssa132132434()
        {
            Console.WriteLine("完成初始化过程");
        }

        [TestMethod]
        public void TestMethod()
        {
            using (MyWebServiceTest.MyWebServiceSoapClient client = new MyWebServiceTest.MyWebServiceSoapClient())
            {
                MyWebServiceTest.CustomSoapHeader header = new MyWebServiceTest.CustomSoapHeader();
                header.UserName = "Eleven";
                header.PassWord = "123456";

                int iResult = client.Plus(12, 33);//45
                MyWebServiceTest.UserInfo userInfo = client.GetUser(header, 1);
                //List<MyWebServiceTest.UserInfo> userList = client.GetUserList(header);
                var userList = client.GetUserList(header);
            }
        }

        [TestMethod]
        public void TestMethodAssert()
        {
            using (MyWebServiceTest.MyWebServiceSoapClient client = new MyWebServiceTest.MyWebServiceSoapClient())
            {
                Assert.AreEqual(client.Plus(12, 33), 45);
                Assert.AreEqual(client.Plus(12, 44), 56);
                Assert.AreEqual(client.Plus(12, 55), 67);
                Assert.AreEqual(client.Plus(12, 66), 45);
            }
        }
    }
}
