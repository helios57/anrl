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
#if DEBUG
           AnrlService service = new AnrlService();
           service.start();
           System.Threading.Thread.Sleep(int.MaxValue);
#endif
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new AnrlService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
