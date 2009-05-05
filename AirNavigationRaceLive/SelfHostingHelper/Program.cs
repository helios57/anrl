using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DataService;

namespace SelfHostingHelper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Starting service...");
            ServiceHost host = Start();
            Console.WriteLine("Ok");
            Console.WriteLine("Press any button and the service will shut down");
            Console.ReadKey();
        }

        static ServiceHost Start()
        {
            ServiceHost host = new ServiceHost(typeof(ANRLDataService), new Uri("http://localhost:5555"));
            host.Open();
            return host;
        }
    }
}
