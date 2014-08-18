using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO;

namespace VideoCardHandler
{
    public partial class ClockToolService : ServiceBase
    {
        private System.Timers.Timer GpuUsageWatcher;
        private bool isRunningOnBattery;
        ADLPMActivity adlp;
        private int adapterIndex;
        public readonly string applicationFolder = Path.GetDirectoryName(Application.ExecutablePath);
        private int actualCore, actualMem;
        private void ServiceStart()
        {
            int status = ADL.ADL_Main_Control_Create(1);
            if (status == ADL.ADL_OK)
            {
                this.adlp = new ADLPMActivity();
                int numberOfAdapters = 0;
                ADL.ADL_Adapter_NumberOfAdapters_Get(ref numberOfAdapters);
                if (numberOfAdapters > 0)
                {
                    ADLAdapterInfo[] adapterInfo = new ADLAdapterInfo[numberOfAdapters];
                    if (ADL.ADL_Adapter_AdapterInfo_Get(adapterInfo) == ADL.ADL_OK)
                        for (int i = 0; i < numberOfAdapters; i++)
                        {
                            int isActive;
                            ADL.ADL_Adapter_Active_Get(adapterInfo[i].AdapterIndex,
                              out isActive);
                            if (isActive == 1) adapterIndex = adapterInfo[i].AdapterIndex;
                        }
                }
            }
            this.GpuUsageWatcher = new System.Timers.Timer(15000);
            this.GpuUsageWatcher.Elapsed += GpuUsageWatcher_Elapsed;
            this.isRunningOnBattery = false;
            this.GpuUsageWatcher.Enabled = true;
            this.GpuUsageWatcher_Elapsed(null, null);
        }
        private void ModifyVideoCardClock(int coreClock, int memClock)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = applicationFolder + @"\AMDGpuClockTool\AMDGPUClockTool.exe";
                p.StartInfo.Arguments = string.Format("-eng={0} -mem={1}", coreClock, memClock);
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.Start();
                actualCore = coreClock;
                actualMem = memClock;
            }
            catch (Exception e)
            {
                actualCore = 0;
                actualMem = 0;
                Common.createFile(applicationFolder, "error.txt", true, new string[] { e.ToString() });
            }


        }
        int nullaCounter = 0;


        public ClockToolService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            Thread OnStartThread = new Thread(new ThreadStart(this.ServiceStart));
            OnStartThread.Start();
            base.OnStart(args);
        }
        protected override void OnStop()
        {
        }

        private void GpuUsageWatcher_Elapsed(object sender, ElapsedEventArgs e)
        {
            isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus ==
        PowerLineStatus.Offline);
            int gpuValue = 0;
            if (ADL.ADL_Overdrive5_CurrentActivity_Get(adapterIndex, ref adlp) == ADL.ADL_OK)
            {
                gpuValue = Math.Min(adlp.ActivityPercent, 100);
            }
            if (gpuValue != 0 || nullaCounter > 5)
            {
                nullaCounter = 0;
                if (!isRunningOnBattery)
                {
                    if (gpuValue > 40)
                    {
                        if (actualCore != 500 && actualMem != 750)
                        {
                            ModifyVideoCardClock(500, 750);
                        }
                    }
                    else
                    {
                        if (actualCore != 300 && actualMem != 350)
                        {
                            ModifyVideoCardClock(300, 350);
                        }
                    }

                }
                else
                {
                    if (actualCore != 300 && actualMem != 300)
                    {
                        ModifyVideoCardClock(300, 300);
                    }
                }
            }
            else {
                nullaCounter++;
            }

        }


    }
}
