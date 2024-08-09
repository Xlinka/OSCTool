using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TeriziaMultitoolS
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += OnApplicationExit;
            AllocConsole();
            MessageHandler.StartOSC();

            OSCV._soundPlayer = new System.Media.SoundPlayer("Hatsume miku 1 frame scream.wav");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            MessageHandler.ShutDownOSC();
        }

        public static float ConvertIntToFloat(int input)
        {
            return input / 100.0f;
        }

        public static int PackBools(bool[] bools)
        {
            if (bools.Length != 15)
            {
                throw new ArgumentException("The bool array must contain exactly 15 elements.");
            }

            int packed = 0;
            for (int i = 0; i < bools.Length; i++)
            {
                if (bools[i])
                {
                    packed |= (1 << i);
                }
            }
            return packed;
        }

        public static bool[] UnpackBools(int packed)
        {
            bool[] bools = new bool[15];
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = (packed & (1 << i)) != 0;
            }
            return bools;
        }
    }
}
