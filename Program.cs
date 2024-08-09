using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Rug.Osc;
using Timer = System.Timers.Timer;

namespace TeriziaMultitoolS
{
    public class OSCV
    {

        //data
        public static int OSC_Int_1;
        public static float OSC_Float_1;
        public static bool OSC_Bool_1;
        public static bool OSC_Bool_2;
        public static bool OSC_Bool_3;
        public static bool OSC_Bool_4;
        public static bool OSC_Bool_5;
        public static bool OSC_Bool_6;
        public static bool OSC_Bool_7;
        public static bool OSC_Bool_8;
        public static bool OSC_Bool_9;
        public static bool OSC_Bool_10;
        public static bool OSC_Bool_11;
        public static bool OSC_Bool_12;
        public static bool OSC_Bool_13;
        public static bool OSC_Bool_14;
        public static bool OSC_Bool_15;
        public static bool OSC_Bool_16;

        public static int TestInt;
        public static float TestFloat;
        public static bool TestBool;
        public static string TestString = "/avatar/parameters/TestFloat";
        public static string CloudVarAddres = "/avatar/parameters/string/CloudVar";
        public static string CloudVarVariable = "IDK, The ID";

        public static bool floatingP;

        public static string programmKillstring = "TeriziaMultitoolS";

        public static int PlaceHolderInt;



        public static int[] WorkBench = new int[12];

        // Controller

        static public float leftThumbXn, rightThumbXn, leftThumbYn, rightThumbYn;
        static public float leftTrigger, rightTrigger;
        static public int FunnyFunkySendingVar;
        static public bool XButton0LeftShoulder, XButton0RightShoulder; // Shoulder button
        static public bool XButton0A, XButton0B, XButton0X, XButton0Y; // Main Buttons
        static public bool XButton0DPadUp, XButton0DPadDown, XButton0DPadLeft, XButton0DPadRight; // DPad
        static public bool XButton0LeftThumb, XButton0RightThumb; // Thumbstick Click
        static public bool XButton0Start, XButton0Back; // MenuButtons

        ////////

        static public SoundPlayer _soundPlayer;
    }

    internal static class Program
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += OnApplicationExit;
            AllocConsole();
            MessageHandler.StartOSC();

            OSCV._soundPlayer = new SoundPlayer("Hatsume miku 1 frame scream.wav");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }


        ////////

        //When exeting the program, abort things
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            MessageHandler.ShutDownOSC();
        }



        ////////

        //this are if for convertion        
        public static float ConvertIntToFloat(int input)
        {
            return input / 100.0f;
        }

        ////////

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


        

        ////////


        //OSC Mesages
        /*
       public static void VRCOSCMesage()
       {


           // LocalIP because VRC LOL
           IPAddress address = IPAddress.Parse("127.0.0.1");

           // VRC Port in
           int Port = 9000;

           // Message start
           using (OscSender sender = new OscSender(address, 0, Port))
           {
               // Connect the sender socket  
               sender.Connect();

               if (OSCV.floatingP)
               {
                   // Send a new message
                   sender.Send(new OscMessage(OSCV.TestString, OSCV.TestFloat));
                   Console.WriteLine($"{OSCV.TestString}" + $"{OSCV.TestFloat}");
               }
               if (!OSCV.floatingP)
               {
                   // Send a new message
                   sender.Send(new OscMessage(OSCV.TestString, OSCV.TestInt));
                   Console.WriteLine($"{OSCV.TestString}" + $"{OSCV.TestInt}");
               }

               // Close the sender
               sender.Close();

           }
           // Message End

       }
        */
        ////////

    }


}