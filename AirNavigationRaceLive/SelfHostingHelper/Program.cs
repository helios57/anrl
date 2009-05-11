using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DataService;

namespace SelfHostingHelper
{
    /// <summary>
    /// Console application for hosting the DataService
    /// </summary>
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Starting service...");
            ServiceHost host = Start();
            Console.WriteLine("Ok");
            Console.WriteLine(host.BaseAddresses.First());
            Console.WriteLine("Press any button and the service will shut down");
            Console.ReadKey();
        }

        private static ServiceHost Start()
        {
            ServiceHost host = new ServiceHost(typeof(ANRLDataService), new Uri("http://localhost:5555"));
            host.Open();
            return host;
        }
    }
}
