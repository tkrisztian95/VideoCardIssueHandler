using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCardHandler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

#if DEBUG

            ClockToolService Service = new ClockToolService();
            Service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

#else
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new ClockToolService() 
            //};
            //ServiceBase.Run(ServicesToRun);

            // if (args != null && args.Length > 0)
            //{
            //    switch (args[0].ToLower())
            //    {
            //        default:
            //            break;
            //        case "-install":
            //            SelfInstaller.Install();
            //            Environment.Exit(-1);
            //            break;

            //        case "-uninstall":
            //            SelfInstaller.Uninstall();
            //            Environment.Exit(-1);
            //            break;

            //    }

            //}


            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
            { 
                new ClockToolService() 
            };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                Common.createFile(Path.GetDirectoryName(Application.ExecutablePath), "errorLog.txt", true, new string[] { ex.ToString() });
            }
#endif
        }
    }
}
