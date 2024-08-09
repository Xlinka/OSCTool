using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace TeriziaMultitoolS
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Any initialization code can go here
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "checkBox1Checked";
                OSCV.floatingP = true;
                trackBar1.Minimum = -100;
                trackBar1.Maximum = 100;
            }
            else
            {
                checkBox1.Text = "checkBox1Unchecked";
                OSCV.floatingP = false;
                trackBar1.Minimum = 0;
                trackBar1.Maximum = 100;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OSCV.OSC_Bool_1 = true;
            MCItem.GiveItem();
            // Uncomment the next line if you implement the VRCOSCMesage method
            // MessageHandler.VRCOSCMesage();
        }

        private void trackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (OSCV.floatingP)
            {
                int ininini = trackBar1.Value;
                OSCV.TestFloat = Program.ConvertIntToFloat(ininini);
                label1.Text = $"Scroll1: {OSCV.TestFloat}";
            }
            else
            {
                OSCV.TestInt = trackBar1.Value;
                label1.Text = $"Scroll1: {OSCV.TestInt}";
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            KillProcess(OSCV.programmKillstring);
        }

        private void KillProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                    Console.WriteLine($"Successfully killed process {process.ProcessName} with ID {process.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error killing process {process.ProcessName} with ID {process.Id}: {ex.Message}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OSCV.TestString = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OSCV.programmKillstring = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            OSCV.CloudVarAddres = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            OSCV.CloudVarVariable = textBox4.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OSCV._soundPlayer.Play();
            label2.Text = OSCV.TestBool ? "true" : "false";
            Console.WriteLine($"OSCV.TestBool == {OSCV.TestBool}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OSCV.PlaceHolderInt = (OSCV.PlaceHolderInt + 1) % 11;
            label3.Text = $"{OSCV.PlaceHolderInt}";

            // Send the OSC message
            MessageHandler.VRCOSCMesageXimput();
            // Uncomment the next line if you want to send string messages as well
            // MessageHandler.VRCOSCMesageString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox2.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Handle the numeric up/down value change if needed
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // Placeholder for OSCReceiver toggle functionality
            // Implement the receiver logic here if needed
        }
    }
}
