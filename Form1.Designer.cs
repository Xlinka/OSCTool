using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace TeriziaMultitoolS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private MetroCheckBox checkBox1;
        private MetroButton button1;
        private MetroTextBox textBox1;
        private MetroTrackBar trackBar1;
        private MetroTextBox textBox2;
        private MetroButton button4;
        private MetroButton button2;
        private System.Windows.Forms.Timer timer1;
        private MetroCheckBox checkBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MetroTextBox textBox3;
        private MetroTextBox textBox4;
        private MetroLabel label1;
        private MetroLabel label2;
        private MetroLabel label3;
        private MetroLabel label4;
        private MetroCheckBox checkBox3;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.trackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.textBox2 = new MetroFramework.Controls.MetroTextBox();
            this.button4 = new MetroFramework.Controls.MetroButton();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new MetroFramework.Controls.MetroTextBox();
            this.textBox4 = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.checkBox3 = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 192);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 15);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "SetTestOSC,Box1";
            this.checkBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 215);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "/avatar/parameters/TestFloat";
            this.textBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Transparent;
            this.trackBar1.Location = new System.Drawing.Point(9, 241);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(288, 45);
            this.trackBar1.Style = MetroFramework.MetroColorStyle.Purple;
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.trackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackBar1_Scroll);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(567, 236);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(137, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(567, 207);
            this.button4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 23);
            this.button4.Style = MetroFramework.MetroColorStyle.Purple;
            this.button4.TabIndex = 1;
            this.button4.Text = "Kill Process";
            this.button4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 29);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "testButton";
            this.button2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(140, 30);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(150, 15);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "OSCSender,Timer1,Box2";
            this.checkBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(509, 27);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(127, 20);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(509, 67);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "/avatar/parameters/string/CloudVar";
            this.textBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(509, 93);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 20);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "IDK, The ID";
            this.textBox4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            this.label2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "label3";
            this.label3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "label4";
            this.label4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(140, 67);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(219, 15);
            this.checkBox3.TabIndex = 21;
            this.checkBox3.Text = "OSCReceiver,Box3 [Work in progress]";
            this.checkBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(757, 321);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
