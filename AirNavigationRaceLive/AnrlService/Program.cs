using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AnrlService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            AnrlService service = new AnrlService();
            System.Threading.Thread.Sleep(int.MaxValue);
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new AnrlService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
