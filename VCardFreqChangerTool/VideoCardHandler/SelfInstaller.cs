using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Install;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;


namespace Usage_Logger_Professional_service
{
   public class SelfInstaller
    {

        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;
           
        public static bool Install()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(
                    new string[] { _exePath } );
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool Uninstall()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(
                    new string[] { "/u", _exePath } );
            }
            catch
            {
                return false;
            }
            return true;
        }
      
    }
}
