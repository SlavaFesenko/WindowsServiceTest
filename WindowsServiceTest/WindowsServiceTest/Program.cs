using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            var service1 = new Service1();
            if (Environment.UserInteractive)
            {
                service1.TestStartupAndStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    service1
                };
                ServiceBase.Run(ServicesToRun);
            }
           
        }
    }
}
