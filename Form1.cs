using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Rug.Osc;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;

namespace TeriziaMultitoolS
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Checkbox is checked
                checkBox1.Text = "checkBox1Checked";

                OSCV.floatingP = true;
                trackBar1.Minimum = -100;
                trackBar1.Maximum = 100;
            }
            else
            {
                // Checkbox is unchecked
                // Change the text of checkBox1
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
            //MessageHandler.VRCOSCMesage();
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            if (OSCV.floatingP)
            {

                int ininini = trackBar1.Value;
                OSCV.TestFloat = Program.ConvertIntToFloat(ininini);
                label1.Text = $"Scroll1: {OSCV.TestFloat}";
            }

            else if (!OSCV.floatingP)
            {

                OSCV.TestInt = trackBar1.Value;
                label1.Text = $"Scroll1: {OSCV.TestInt}";
            }
            //MessageHandler.VRCOSCMesage();

        }


        private void button4_Click(object sender, EventArgs e)
        {

            Process[] processes = Process.GetProcessesByName(OSCV.programmKillstring);
            foreach (Process process in processes)
            {
                try
                {
                    // Kill the process
                    process.Kill();
                    // Wait for the process to exit to ensure it is terminated
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
            // Change the string based on TextBox input
            OSCV.TestString = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Change the string based on TextBox input
            OSCV.programmKillstring = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Change the string based on TextBox input
            OSCV.CloudVarAddres = textBox3.Text;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Change the string based on TextBox input
            OSCV.CloudVarVariable = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OSCV._soundPlayer.Play();

            if (OSCV.TestBool == false)
            {
                label2.Text = "false";
                Console.WriteLine("OSCV.TestBool == false");
            }
            if (OSCV.TestBool == true)
            {
                label2.Text = "true";
                Console.WriteLine("OSCV.TestBool == true");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            OSCV.PlaceHolderInt += 1;

            if (OSCV.PlaceHolderInt > 10)
            {
                OSCV.PlaceHolderInt = 0;
            }

            label3.Text = $"{OSCV.PlaceHolderInt}";
            MessageHandler.VRCOSCMesageXimput();
            //MessageHandler.VRCOSCMesageString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                // Checkbox is checked
                timer1.Enabled = true;

            }
            else
            {
                // Checkbox is unchecked
                timer1.Enabled = false;

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                // Checkbox is checked
                

            }
            else
            {
                // Checkbox is unchecked
                

            }
        }
    }

}