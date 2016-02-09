using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WDT.Interfaces
{
    [ServiceContract]
    public interface IWcfPingTest
    {
        [OperationContract]
        string Ping();
    }
}
