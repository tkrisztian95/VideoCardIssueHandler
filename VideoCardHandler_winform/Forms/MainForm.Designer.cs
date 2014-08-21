namespace VideoCardHandler_winform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.chbAutomatic = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.gBoxManual = new System.Windows.Forms.GroupBox();
            this.gBoxStatus = new System.Windows.Forms.GroupBox();
            this.lblGpuTemp = new System.Windows.Forms.Label();
            this.lblGpuLoad = new System.Windows.Forms.Label();
            this.lblMemFreq = new System.Windows.Forms.Label();
            this.lblCoreFreq = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblBatteryMode = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBoxManual.SuspendLayout();
            this.gBoxStatus.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbAutomatic
            // 
            this.chbAutomatic.AutoSize = true;
            this.chbAutomatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbAutomatic.Location = new System.Drawing.Point(20, 34);
            this.chbAutomatic.Name = "chbAutomatic";
            this.chbAutomatic.Size = new System.Drawing.Size(215, 20);
            this.chbAutomatic.TabIndex = 0;
            this.chbAutomatic.Text = "Autómatikus frekvencia kezelés";
            this.chbAutomatic.UseVisualStyleBackColor = true;
            this.chbAutomatic.CheckedChanged += new System.EventHandler(this.chbAutomatic_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton1.Location = new System.Drawing.Point(38, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(142, 19);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Energia megtakarítás";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton2.Location = new System.Drawing.Point(38, 64);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(150, 19);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Maximális teljesítmény";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // gBoxManual
            // 
            this.gBoxManual.Controls.Add(this.radioButton2);
            this.gBoxManual.Controls.Add(this.radioButton1);
            this.gBoxManual.Location = new System.Drawing.Point(12, 62);
            this.gBoxManual.Name = "gBoxManual";
            this.gBoxManual.Size = new System.Drawing.Size(322, 108);
            this.gBoxManual.TabIndex = 3;
            this.gBoxManual.TabStop = false;
            this.gBoxManual.Text = "Manuális beállítás";
            // 
            // gBoxStatus
            // 
            this.gBoxStatus.Controls.Add(this.lblGpuTemp);
            this.gBoxStatus.Controls.Add(this.lblGpuLoad);
            this.gBoxStatus.Controls.Add(this.lblMemFreq);
            this.gBoxStatus.Controls.Add(this.lblCoreFreq);
            this.gBoxStatus.Controls.Add(this.label4);
            this.gBoxStatus.Controls.Add(this.label3);
            this.gBoxStatus.Controls.Add(this.label2);
            this.gBoxStatus.Controls.Add(this.label1);
            this.gBoxStatus.Location = new System.Drawing.Point(12, 216);
            this.gBoxStatus.Name = "gBoxStatus";
            this.gBoxStatus.Size = new System.Drawing.Size(322, 105);
            this.gBoxStatus.TabIndex = 4;
            this.gBoxStatus.TabStop = false;
            this.gBoxStatus.Text = "Videókártya állapot";
            // 
            // lblGpuTemp
            // 
            this.lblGpuTemp.AutoSize = true;
            this.lblGpuTemp.Location = new System.Drawing.Point(274, 58);
            this.lblGpuTemp.Name = "lblGpuTemp";
            this.lblGpuTemp.Size = new System.Drawing.Size(24, 13);
            this.lblGpuTemp.TabIndex = 7;
            this.lblGpuTemp.Text = "0C°";
            // 
            // lblGpuLoad
            // 
            this.lblGpuLoad.AutoSize = true;
            this.lblGpuLoad.Location = new System.Drawing.Point(274, 28);
            this.lblGpuLoad.Name = "lblGpuLoad";
            this.lblGpuLoad.Size = new System.Drawing.Size(21, 13);
            this.lblGpuLoad.TabIndex = 6;
            this.lblGpuLoad.Text = "0%";
            // 
            // lblMemFreq
            // 
            this.lblMemFreq.AutoSize = true;
            this.lblMemFreq.Location = new System.Drawing.Point(90, 58);
            this.lblMemFreq.Name = "lblMemFreq";
            this.lblMemFreq.Size = new System.Drawing.Size(33, 13);
            this.lblMemFreq.TabIndex = 5;
            this.lblMemFreq.Text = "0Mhz";
            // 
            // lblCoreFreq
            // 
            this.lblCoreFreq.AutoSize = true;
            this.lblCoreFreq.Location = new System.Drawing.Point(90, 28);
            this.lblCoreFreq.Name = "lblCoreFreq";
            this.lblCoreFreq.Size = new System.Drawing.Size(33, 13);
            this.lblCoreFreq.TabIndex = 4;
            this.lblCoreFreq.Text = "0Mhz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "GPU hőmérséklet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "GPU terheltség:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Memória órajel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mag órajel:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(346, 333);
            this.shapeContainer1.TabIndex = 5;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 18;
            this.lineShape1.X2 = 331;
            this.lineShape1.Y1 = 207;
            this.lineShape1.Y2 = 207;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hálózati áramforrás:";
            // 
            // lblBatteryMode
            // 
            this.lblBatteryMode.AutoSize = true;
            this.lblBatteryMode.Location = new System.Drawing.Point(176, 184);
            this.lblBatteryMode.Name = "lblBatteryMode";
            this.lblBatteryMode.Size = new System.Drawing.Size(106, 13);
            this.lblBatteryMode.TabIndex = 9;
            this.lblBatteryMode.Text = "Nincs csatlakoztatva";
            // 
            // icon
            // 
            this.icon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.icon.BalloonTipText = "Az ATI 5650 handler alkalmazás nem került bezárásra. A bezáráshoz használja  a Fá" +
    "jl->Kilépés menű gombot!";
            this.icon.BalloonTipTitle = "Háttérben fut";
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "ATI 5650 handler";
            this.icon.Visible = true;
            this.icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.icon_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(346, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fájlToolStripMenuItem
            // 
            this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilépésToolStripMenuItem});
            this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            this.fájlToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fájlToolStripMenuItem.Text = "Fájl";
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 333);
            this.Controls.Add(this.lblBatteryMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gBoxStatus);
            this.Controls.Add(this.gBoxManual);
            this.Controls.Add(this.chbAutomatic);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ATI 5650 handler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.gBoxManual.ResumeLayout(false);
            this.gBoxManual.PerformLayout();
            this.gBoxStatus.ResumeLayout(false);
            this.gBoxStatus.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbAutomatic;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox gBoxManual;
        private System.Windows.Forms.GroupBox gBoxStatus;
        private System.Windows.Forms.Label lblGpuTemp;
        private System.Windows.Forms.Label lblGpuLoad;
        private System.Windows.Forms.Label lblMemFreq;
        private System.Windows.Forms.Label lblCoreFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBatteryMode;
        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

