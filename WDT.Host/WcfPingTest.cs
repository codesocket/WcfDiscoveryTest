using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDT.Interfaces;

namespace WDT.Host
{
    public class WcfPingTest : IWcfPingTest
    {
        public readonly string magicString = Environment.MachineName;
        public string Ping() { return magicString; }
    }
}
