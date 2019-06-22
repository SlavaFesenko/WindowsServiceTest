using System.ServiceProcess;
using System;
using System.IO;
using System.Threading;

namespace WindowsServiceTest
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;
        public Service1()
        {
            InitializeComponent();

            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            logger = new Logger();
            Thread loggerThread = new Thread(new ThreadStart(logger.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
            Thread.Sleep(1000);
        }
    }
}
