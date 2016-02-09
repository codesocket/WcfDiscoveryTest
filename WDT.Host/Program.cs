using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;
using WDT.Interfaces;

namespace WDT.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            WcfTestHost_Open();
        }

        public static void WcfTestHost_Open()
        {
            string hostname = Environment.MachineName;
            var baseAddress = new UriBuilder("http", "10.0.26.148", 7400, "WcfPing");
            var h = new ServiceHost(typeof(WcfPingTest), baseAddress.Uri);

            // enable processing of discovery messages.  use UdpDiscoveryEndpoint to enable listening. use EndpointDiscoveryBehavior for fine control.
            h.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            h.AddServiceEndpoint(new UdpDiscoveryEndpoint());

            // enable wsdl, so you can use the service from WcfStorm, or other tools.
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            h.Description.Behaviors.Add(smb);

            // create endpoint
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            h.AddServiceEndpoint(typeof(IWcfPingTest), binding, "");
            h.Open();
            Console.WriteLine("host open");
            Console.Read();         
        }
    }
}
