using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ComputerShutDownTimer
{
    public partial class ShutdownForm : Form
    {
        private bool shutdown = true;

        public ShutdownForm()//bool shutdown)
        {
            //this.shutdown = shutdown;
            InitializeComponent();
        }

        private void main()
        {
            runCommandLine(shutdown);
        }

        private void runCommandLine(bool shutdown)
        {
            MessageBox.Show("num1: " + this.numericUpDown1.Value.ToString() + "; num2: " + this.numericUpDown2.Value.ToString()
                            + " total value in seconds: " + getShutdownTimeInSeconds().ToString() + "; intmaxvalue: " + Int32.MaxValue);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            if(shutdown == true)
            {
                startInfo.Arguments = "/C shutdown -s -t " + getShutdownTimeInSeconds();
            }
            else
            {
                startInfo.Arguments = "/C shutdown -a";
            }
            process.StartInfo = startInfo;
            process.Start();
        }

        private int getShutdownTimeInSeconds()
        {
            int timeToShutdown = ((int)this.numericUpDown1.Value * 60 * 60) + ((int)this.numericUpDown2.Value * 60);
            
            return timeToShutdown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shutdown = true;
            Thread onCommandLineScript = new Thread(main);
            onCommandLineScript.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shutdown = false;
            Thread onCommandLineScript = new Thread(main);
            onCommandLineScript.Start();
        }
    }
}
