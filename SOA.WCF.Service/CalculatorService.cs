using SOA.WCF.Model;
using SOA.WCF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceModel;

namespace SOA.WCF.Service
{
    public class CalculatorService : ICalculatorService
    {
        /// <summary>
        /// 完成计算，然后去回调
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Plus(int x, int y)
        {
            int result = x + y;
            Thread.Sleep(2000);
            ICallBack callBack = OperationContext.Current.GetCallbackChannel<ICallBack>();
            callBack.Show(x, y, result);
        }
    }
}
