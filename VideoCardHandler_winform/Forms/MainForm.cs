using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCardHandler_winform
{
    public partial class MainForm : Form
    {


        ADLPMActivity adlp;
        ADLTemperature adlt;
        private int gpuAdapterIndex;
        public readonly string applicationFolder = Path.GetDirectoryName(Application.ExecutablePath);

        int _engineClock;
        int _memoryClock;
        byte _gpuLoad;
        int _gpuTemp;
        bool _isRunningOnBattery;
        bool automaticHandling;

        public int EngineClock
        {
            get
            {
                return _engineClock;
            }
            private set
            {

                if (_engineClock != value)
                {
                    _engineClock = value;
                    this.lblCoreFreq.Text = (value / 100).ToString() + "Mhz";
                }
            }
        }
        public int MemoryClock
        {
            get
            {
                return _memoryClock;
            }
            private set
            {

                if (_memoryClock != value)
                {
                    _memoryClock = value;
                    this.lblMemFreq.Text = (value / 100).ToString() + "Mhz";
                }
            }
        }
        public byte GpuLoad
        {
            get
            {
                return _gpuLoad;
            }
            private set
            {

                if (_gpuLoad != value)
                {
                    _gpuLoad = value;
                    this.lblGpuLoad.Text = value.ToString() + "%";
                }
            }


        }
        public int GpuTemp
        {
            get
            {
                return _gpuTemp;
            }
            private set
            {
                if (_gpuTemp != value)
                {
                    _gpuTemp = value;
                    this.lblGpuTemp.Text = (0.001f * value).ToString() + "C°";
                }
            }


        }
        public bool PowerStatus
        {

            get
            {
                return _isRunningOnBattery;
            }
            private set
            {
                if (_isRunningOnBattery != value)
                {

                    _isRunningOnBattery = value;
                    if (value) lblBatteryMode.Text = "Csatlakoztatva";
                    else lblBatteryMode.Text = "Nincs csatlakoztatva";
                }

            }
        }
        byte nullacounter = 0;
        byte counter = 0;
        byte gpuLoad1 = 0;
        byte gpuLoad2 = 0;


        public MainForm()
        {
            InitializeComponent();
            this.PowerStatus = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online);   
            this.adlt = new ADLTemperature();
            try
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
                                if (isActive == 1) this.gpuAdapterIndex = adapterInfo[i].AdapterIndex;
                            }
                    }



                }
                else
                {
                    throw new Exception("Az adapter kiolvasása nem volt sikeres!");
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("Az alkalmazás indítása nem sikerült: " + e.ToString());
                Environment.Exit(-1);
            }
            this.chbAutomatic.Checked = true;
        }



        private void refreshTimer_Tick(object sender, EventArgs e)
        {

            if (ADL.ADL_Overdrive5_CurrentActivity_Get(gpuAdapterIndex, ref adlp) == ADL.ADL_OK)
            {
                EngineClock = adlp.EngineClock;
                MemoryClock = adlp.MemoryClock;
                GpuLoad = (byte)Math.Min(adlp.ActivityPercent, 100);
            }


            if (ADL.ADL_Overdrive5_Temperature_Get(gpuAdapterIndex, 0, ref adlt)
              == ADL.ADL_OK)
            {
                GpuTemp = adlt.Temperature;
            }

            PowerStatus = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online);
            if (automaticHandling)
            {
                byte actualValue=GpuLoad;
                if (actualValue == 0) {
                    nullacounter++;
                }
                if (actualValue != 0 || nullacounter > 5)
                {
                    if (counter == 1)
                    {
                        gpuLoad1 = actualValue;

                    }
                    if (counter % 5 == 0)
                    {
                        gpuLoad2 = actualValue;
                        counter = 0;
                    }
                    counter++;
                    nullacounter = 0;
                    
                }

                if (PowerStatus)
                {
                    if (((gpuLoad1 + gpuLoad2) / 2) > 40)
                    {

                        ModifyVideoCardClock(500, 800);

                    }
                    else
                    {
                        if (counter == 1)
                        {
                            ModifyVideoCardClock(300, 350);
                        }

                    }

                }
                else
                {
                    ModifyVideoCardClock(300, 300);
                }

                

                

            }
            else
            {

                if (radioButton1.Checked)
                {

                    ModifyVideoCardClock(300, 300);
                }
                else
                {

                    ModifyVideoCardClock(500, 800);
                }

            }

        }
        private void ModifyVideoCardClock(int coreClock, int memClock)
        {
            try
            {
                if (EngineClock / 100 != coreClock || MemoryClock / 100 != memClock)
                {

                    ProcessStartInfo info = new ProcessStartInfo(applicationFolder + @"\AMDGpuClockTool\AMDGPUClockTool.exe");
                    info.CreateNoWindow = true;
                    info.Arguments = string.Format("-eng={0} -mem={1}", coreClock, memClock);
                    info.WindowStyle = ProcessWindowStyle.Hidden;

                    Process process = new Process();
                    process.StartInfo = info;
                    process.Start();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Hiba az órajel módosításakor! \n" + e.ToString());
            }


        }

        private void chbAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAutomatic.Checked == true)
            {
                automaticHandling = true;
                gBoxManual.Enabled = false;
            }
            else
            {
                automaticHandling = false;
                gBoxManual.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                icon.ShowBalloonTip(1000);
            } 

        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

    }
}
