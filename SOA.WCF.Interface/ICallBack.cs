using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SOA.WCF.Interface
{
    /// <summary>
    /// 不需要协议  是个约束，由客户端实现
    /// </summary>
    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void Show(int m, int n, int result);
    }
}
