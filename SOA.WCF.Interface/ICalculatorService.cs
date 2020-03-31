using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCF.Interface
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface ICalculatorService
    {
        [OperationContract(IsOneWay = true)]
        void Plus(int x, int y);


    }
}
