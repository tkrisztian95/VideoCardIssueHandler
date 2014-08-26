using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCardHandler_installer
{
    class Program
    {
        public static bool isAmdGpuClockToolInstalled() {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {                      
                        var a =subkey.GetValue("DisplayName");
                        if ( ((a!=null)? a.ToString():"")== "AMD GPU Clock Tool")
                        { return true; }
                    }
                }
            }
            return false;
        
        }
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void Main(string[] args)
        {

            if (IsAdministrator())
            {
                bool vcFreqToolInstalled = false;
                try
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("A telepítés megkezdése elött másolja a VideoCardHandler alkalmazást és minden összetevőjét a helyi számítógépre!");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\VideoCardIssueHandler.exe"))
                    {
                        Console.WriteLine("Az alkalmazás most ellenőrzi hogy telepítette-e az AMD GPU CLOCK TOOL segéd alkalmazást!");
                        bool installAmdTool = false;
                        if (isAmdGpuClockToolInstalled())
                        {
                            Console.WriteLine("Az AMD GPU Clock Tool már telepítve van a számítógépre!");
                            Console.WriteLine("Az AMD GPU Clock Tool újratelepítéséhez használja az amdTool_installer.exe alkalmazást!");
                            vcFreqToolInstalled = true;
                        }
                        else
                        {

                            Console.WriteLine("Az AMD GPU Clock Tool még nincs telepítve  a számítógépre!");
                            vcFreqToolInstalled = false;
                        }
                        Console.WriteLine("A telepítés folytatásához nyomjon Entert....");
                        Console.ReadLine();
                        if (vcFreqToolInstalled == false)
                        {


                            if (File.Exists(Directory.GetCurrentDirectory().ToString() + @"\amdTool_installer.exe"))
                            {
                                Console.WriteLine("Az alkalmazás most elindítja az AMD Gpu Clock Tool telepítőjét...");
                                ProcessStartInfo info = new ProcessStartInfo(Directory.GetCurrentDirectory() + @"\amdTool_installer.exe");
                                Process p = new Process();
                                p.StartInfo = info;
                                p.Start();
                            }
                            else
                            {
                                Console.WriteLine("A videó kártya frekvencia módosító segéd program telepítése nem lehetséges mert nem található az 'amdTool_installer.exe' állomány! ");
                                Console.WriteLine("Előfordulhat hogy az alkalmazás nem fog megfelelően működni ha nem telepítette az AMD GPU CLOCK TOOL alkalmazást.");
                                string userInput = "";
                                do
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("A folytatáshoz nyomjon 'Y' vagy kilépéshez 'N'");
                                } while ((userInput = Console.ReadLine().ToUpper()) != "N" || userInput != "I");

                                if (userInput == "Y")
                                {
                                    vcFreqToolInstalled = true;

                                }
                                else
                                {
                                    Environment.Exit(-1);

                                }

                            }


                        }

                    }
                    else
                    {
                        Console.WriteLine("A telepítő alkalmazásnak és a VideoCardIssueHandler alkalmazásnak egy mappában kell lennie a helyi gépen!");
                        Console.WriteLine("Amennyiben átnevezte az alkalmazást nevezze vissza vagy helyezze a telepítőt az alkalmazás mellé majd futassa újra  a telepítését!");
                        Console.WriteLine("A telepítő kilép...");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Az alkalmazás most létrehoz egy regisztrácós bejegyzést..");

                    RegistryKey add = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("Video Card Handler (ATI5650m)", "\"" + Directory.GetCurrentDirectory() + @"\VideoCardIssueHandler.exe" + "\"");
                    Console.WriteLine("A bejegyzés létrehozva! Az alkalmazás a következő indítástól kezdve autómatikusan indul!");
                    Console.WriteLine();
                    Console.WriteLine("A telepítés KÉSZ!");
                    Console.ReadLine();

                }
                catch (Exception e)
                {


                }

            }
            else
            {
                Console.WriteLine("Az alkalmazás telepítéséhez rendszergazdai jogosultság szükséges!");
                Console.WriteLine("A telepítő kilép...");
                Console.ReadLine();
            }
        
        }
        
    }
}
