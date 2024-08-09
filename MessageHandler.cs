using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rug.Osc;
using SharpDX.XInput;

namespace TeriziaMultitoolS
{
    public static class MessageHandler
    {
        static OscReceiver receiver;
        static Thread thread;

        static Controller controller;
        static Gamepad gamepad;
        static public bool connected = false;
        static public int deadband = 2500;

        static public int recivevariableInt;
        static public float recivevariableFloat;
        static public string recivevariableString;

        // OSC Reciver

        public static void StartOSC()
        {
            // Create the receiver
            receiver = new OscReceiver(9001);

            // Create a thread to do the listening
            thread = new Thread(new ThreadStart(ListenLoop));

            // Connect the receiver
            receiver.Connect();

            // Start the listen thread
            thread.Start();

            Console.WriteLine("Starting OSC");


            // funky controller shit XD

            controller = new Controller(UserIndex.One);
            connected = controller.IsConnected;
        }

        public static void ShutDownOSC()
        {
            Console.WriteLine("Shutting Down OSC");
            threadrun = false;
        }

        public static bool threadrun = true;

        static void ListenLoop()
        {
            try
            {
                while (receiver.State != OscSocketState.Closed && threadrun)
                {
                    // if we are in a state to recieve
                    if (receiver.State == OscSocketState.Connected)
                    {
                        // get the next message 
                        // this will block until one arrives or the socket is closed
                        // If for resonite [osc://127:0.0.1:12345/] ingame and the 12345 is the port it sends to
                        OscPacket packet = receiver.Receive();

                        // Write the packet to the console 
                        Console.WriteLine(packet.ToString());

                        ////////




                        ////////

                        if (!(packet is OscMessage oscMessage)) continue;
                        switch (oscMessage.Address)
                        {
                            case "/avatar/parameters/AngularY":
                                Console.WriteLine("Variable: angular Y");
                                Console.WriteLine(oscMessage);
                                break;

                            case "/avatar/parameters/AngularX":
                                Console.WriteLine("Variable: angular X");
                                Console.WriteLine(oscMessage);
                                break;

                            case "/avatar/change":
                                Console.WriteLine("Funn");
                                Console.WriteLine(oscMessage);
                                break;

                            case "/avatar/parameters/Funn":
                                string messageString = oscMessage.ToString();
                                int commaIndex = messageString.IndexOf(',');

                                if (commaIndex >= 0 && commaIndex < messageString.Length - 1)
                                {
                                    // Extract the substring after the comma and parse it as a boolean
                                    string boolString = messageString.Substring(commaIndex + 1).Trim();
                                    if (bool.TryParse(boolString, out bool state))
                                    {
                                        OSCV.TestBool = state;
                                        // Optionally log if needed
                                        Console.WriteLine($"address {oscMessage.Address} value {state}");
                                    }
                                }

                                break;

                            // For resonite
                            case "/avatar/parameters/WorkBench[0]":

                                // Extract the arguments (variables) from the message
                                foreach (var arg in oscMessage)
                                {
                                    // Display the type and value of each argument
                                    //Console.WriteLine($"Argument type: {arg.GetType()}, value: {arg}");

                                    // You can cast the argument to the appropriate type if needed
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        // Custome Sheit
                                        OSCV.WorkBench[0] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("NotInt");
                                    }

                                    // Handle other types as needed

                                    /*
                                    else if (arg is float floatValue)
                                    {
                                        Console.WriteLine($"Received float: {floatValue}");
                                    }
                                    else if (arg is string stringValue)
                                    {
                                        Console.WriteLine($"Received string: {stringValue}");
                                    }
                                    */
                                }

                                break;
                            // This is more an example

                            case "/avatar/parameters/WorkBench[1]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[1] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[2]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[2] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[3]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[3] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[4]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[4] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[5]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[5] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[6]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[6] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[7]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[7] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[8]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[8] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;
                            case "/avatar/parameters/WorkBench[9]":
                                foreach (var arg in oscMessage)
                                {
                                    if (arg is int intValue)
                                    {
                                        recivevariableInt = intValue;
                                        Console.WriteLine($"Received integer: {intValue}");
                                        OSCV.WorkBench[9] = recivevariableInt;
                                    }
                                    else
                                    {
                                        Console.WriteLine("WellSheit, Message handler WorkBench[1] is broken");
                                    }
                                }
                                break;




                            //
                            // Add more cases as needed
                            default:
                                Console.WriteLine("Unknown OSC address received");
                                Console.WriteLine(oscMessage);
                                break;
                        }

                        ////////

                        // DO SOMETHING HERE!


                    }
                    Console.WriteLine("Lopped");
                }
                receiver.Close();
            }
            catch (Exception ex)
            {
                // if the socket was connected when this happens
                // then tell the user
                if (receiver.State == OscSocketState.Connected)
                {
                    Console.WriteLine("Exception in listen loop");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // OSC sender

        public static void VRCOSCMesageXimput()
        {
            if (connected)
            {
                gamepad = controller.GetState().Gamepad;

                OSCV.leftThumbXn = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100;
                OSCV.leftThumbYn = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;
                OSCV.rightThumbXn = (Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;
                OSCV.rightThumbYn = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100;

                OSCV.leftTrigger = gamepad.LeftTrigger;
                OSCV.rightTrigger = gamepad.RightTrigger;

                // Check each button using bitwise operations
                if ((gamepad.Buttons & GamepadButtonFlags.A) != 0)
                    OSCV.XButton0A = true;
                else { OSCV.XButton0A = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.B) != 0)
                    OSCV.XButton0B = true;
                else { OSCV.XButton0B = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.X) != 0)
                    OSCV.XButton0X = true;
                else { OSCV.XButton0X = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.Y) != 0)
                    OSCV.XButton0Y = true;
                else { OSCV.XButton0Y = false; }


                if ((gamepad.Buttons & GamepadButtonFlags.Start) != 0)
                    OSCV.XButton0LeftShoulder = true;
                else { OSCV.XButton0LeftShoulder = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.Back) != 0)
                    OSCV.XButton0RightShoulder = true;
                else { OSCV.XButton0RightShoulder = false; }


                if ((gamepad.Buttons & GamepadButtonFlags.LeftShoulder) != 0)
                    OSCV.XButton0DPadUp = true;
                else { OSCV.XButton0DPadUp = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.RightShoulder) != 0)
                    OSCV.XButton0DPadDown = true;
                else { OSCV.XButton0DPadDown = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.LeftThumb) != 0)
                    OSCV.XButton0DPadLeft = true;
                else { OSCV.XButton0DPadLeft = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.RightThumb) != 0)
                    OSCV.XButton0DPadRight = true;
                else { OSCV.XButton0DPadRight = false; }


                if ((gamepad.Buttons & GamepadButtonFlags.DPadUp) != 0)
                    OSCV.XButton0LeftThumb = true;
                else { OSCV.XButton0LeftThumb = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.DPadDown) != 0)
                    OSCV.XButton0RightThumb = true;
                else { OSCV.XButton0RightThumb = false; }


                if ((gamepad.Buttons & GamepadButtonFlags.DPadLeft) != 0)
                    OSCV.XButton0Start = true;
                else { OSCV.XButton0Start = false; }

                if ((gamepad.Buttons & GamepadButtonFlags.DPadRight) != 0)
                    OSCV.XButton0Back = true;
                else { OSCV.XButton0Back = false; }

                ////////

                // Example boolean values
                bool[] bools = new bool[15] { OSCV.XButton0LeftShoulder, OSCV.XButton0RightShoulder, OSCV.XButton0A, OSCV.XButton0B, OSCV.XButton0X, OSCV.XButton0Y, OSCV.XButton0DPadUp, OSCV.XButton0DPadDown, OSCV.XButton0DPadLeft, OSCV.XButton0DPadRight, OSCV.XButton0LeftThumb, OSCV.XButton0RightThumb, OSCV.XButton0Start, OSCV.XButton0Back, false };

                // Pack booleans into an int
                int packedBools = Program.PackBools(bools);

                // Output the packed value
                //Console.WriteLine($"Packed Value: {packedBools}");

                OSCV.FunnyFunkySendingVar = packedBools;
            }

            // LocalIP because VRC LOL
            IPAddress address = IPAddress.Parse("127.0.0.1");

            // VRC Port in
            int Port = 9000;

            // Message start
            using (OscSender sender = new OscSender(address, Port, Port))
            {
                // Connect the sender socket  
                sender.Connect();

                // floats
                sender.Send(new OscMessage("/avatar/parameters/leftThumbXn", OSCV.leftThumbXn));
                sender.Send(new OscMessage("/avatar/parameters/leftThumbYn", OSCV.leftThumbYn));
                sender.Send(new OscMessage("/avatar/parameters/rightThumbXn", OSCV.rightThumbXn));
                sender.Send(new OscMessage("/avatar/parameters/rightThumbYn", OSCV.rightThumbYn));

                sender.Send(new OscMessage("/avatar/parameters/leftTrigger", OSCV.leftTrigger));
                sender.Send(new OscMessage("/avatar/parameters/rightTrigger", OSCV.rightTrigger));

                // Int
                sender.Send(new OscMessage("/avatar/parameters/FunnyFunkySendingVar", OSCV.FunnyFunkySendingVar));

                sender.Send(new OscMessage("/avatar/parameters/TestFloat", OSCV.TestFloat));

                // Close the sender
                sender.Close();

            }
            // Message End

        }


        public static void VRCOSCMesageString()
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

                sender.Send(new OscMessage(OSCV.CloudVarAddres, OSCV.CloudVarVariable));
                Console.WriteLine($"{OSCV.CloudVarAddres}" + $"{OSCV.CloudVarVariable}");

                // Close the sender
                sender.Close();

            }
            // Message End

        }


        /*
                public static void VRCOSCMesageXImput()
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

                        // floats
                        sender.Send(new OscMessage("/avatar/parameters/leftThumbXn", OSCV.leftThumbXn));
                        sender.Send(new OscMessage("/avatar/parameters/leftThumbYn", OSCV.leftThumbYn));
                        sender.Send(new OscMessage("/avatar/parameters/rightThumbXn", OSCV.rightThumbXn));
                        sender.Send(new OscMessage("/avatar/parameters/rightThumbYn", OSCV.rightThumbYn));

                        sender.Send(new OscMessage("/avatar/parameters/leftTrigger", OSCV.leftTrigger));
                        sender.Send(new OscMessage("/avatar/parameters/rightTrigger", OSCV.rightTrigger));

                        // bools - Int
                        sender.Send(new OscMessage("/avatar/parameters/XButton0LeftShoulder", OSCV.XButton0LeftShoulder));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0RightShoulder", OSCV.XButton0RightShoulder));

                        sender.Send(new OscMessage("/avatar/parameters/XButton0A", OSCV.XButton0A));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0B", OSCV.XButton0B));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0X", OSCV.XButton0X));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0Y", OSCV.XButton0Y));

                        sender.Send(new OscMessage("/avatar/parameters/XButton0DPadUp", OSCV.XButton0DPadUp));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0DPadDown", OSCV.XButton0DPadDown));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0DPadLeft", OSCV.XButton0DPadLeft));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0DPadRight", OSCV.XButton0DPadRight));

                        sender.Send(new OscMessage("/avatar/parameters/XButton0LeftThumb", OSCV.XButton0LeftThumb));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0RightThumb", OSCV.XButton0RightThumb));

                        sender.Send(new OscMessage("/avatar/parameters/XButton0Back", OSCV.XButton0Back));
                        sender.Send(new OscMessage("/avatar/parameters/XButton0Start", OSCV.XButton0Start));


                        // Close the sender
                        sender.Close();

                    }
                    // Message End

                }

                public static void VRCOSCMesageTest()
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

    }
}
