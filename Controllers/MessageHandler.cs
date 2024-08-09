using System;
using System.Net;
using System.Threading;

namespace TeriziaMultitoolS
{
    public static class MessageHandler
    {
        private static OscReceiver receiver;
        private static Thread receiverThread;
        private static OscSender sender;
        private static bool threadRunning = true;

        // Start OSC Receiver and Sender
        public static void StartOSC()
        {
            // Initialize and start the OSC receiver
            receiver = new OscReceiver(9001);
            receiver.OnOscMessageReceived += HandleOscMessage;
            receiverThread = new Thread(new ThreadStart(receiver.StartListening));
            receiverThread.Start();

            // Initialize the OSC sender
            sender = new OscSender("127.0.0.1", 9000);
            sender.Connect();
        }

        // Shut Down OSC Receiver and Sender
        public static void ShutDownOSC()
        {
            threadRunning = false;
            receiver.Close();
            sender.Close();
        }

        // Handle Incoming OSC Messages
        private static void HandleOscMessage(string address, string data)
        {
            switch (address)
            {
                case "/avatar/parameters/AngularY":
                    Console.WriteLine("Variable: angular Y received with data: " + data);
                    break;

                case "/avatar/parameters/AngularX":
                    Console.WriteLine("Variable: angular X received with data: " + data);
                    break;

                case "/avatar/change":
                    Console.WriteLine("Avatar change command received.");
                    break;

                case "/avatar/parameters/Funn":
                    bool state = bool.Parse(data);
                    OSCV.TestBool = state;
                    Console.WriteLine($"Received {address} with value {state}");
                    break;

                // Handle WorkBench variables
                case "/avatar/parameters/WorkBench[0]":
                    UpdateWorkBenchVariable(0, data);
                    break;
                case "/avatar/parameters/WorkBench[1]":
                    UpdateWorkBenchVariable(1, data);
                    break;
                case "/avatar/parameters/WorkBench[2]":
                    UpdateWorkBenchVariable(2, data);
                    break;
                case "/avatar/parameters/WorkBench[3]":
                    UpdateWorkBenchVariable(3, data);
                    break;
                case "/avatar/parameters/WorkBench[4]":
                    UpdateWorkBenchVariable(4, data);
                    break;
                case "/avatar/parameters/WorkBench[5]":
                    UpdateWorkBenchVariable(5, data);
                    break;
                case "/avatar/parameters/WorkBench[6]":
                    UpdateWorkBenchVariable(6, data);
                    break;
                case "/avatar/parameters/WorkBench[7]":
                    UpdateWorkBenchVariable(7, data);
                    break;
                case "/avatar/parameters/WorkBench[8]":
                    UpdateWorkBenchVariable(8, data);
                    break;
                case "/avatar/parameters/WorkBench[9]":
                    UpdateWorkBenchVariable(9, data);
                    break;

                default:
                    Console.WriteLine($"Unknown OSC address received: {address} with data: {data}");
                    break;
            }
        }

        // Update WorkBench Variables
        private static void UpdateWorkBenchVariable(int index, string data)
        {
            if (int.TryParse(data, out int intValue))
            {
                OSCV.WorkBench[index] = intValue;
                Console.WriteLine($"WorkBench[{index}] updated with value: {intValue}");
            }
            else
            {
                Console.WriteLine($"Invalid data for WorkBench[{index}]: {data}");
            }
        }

        // Send OSC Messages for XInput Controller States
        public static void VRCOSCMesageXimput()
        {
            // Example of sending a float value
            sender.Send("/avatar/parameters/leftThumbXn", OSCV.leftThumbXn);
            sender.Send("/avatar/parameters/leftThumbYn", OSCV.leftThumbYn);
            sender.Send("/avatar/parameters/rightThumbXn", OSCV.rightThumbXn);
            sender.Send("/avatar/parameters/rightThumbYn", OSCV.rightThumbYn);

            sender.Send("/avatar/parameters/leftTrigger", OSCV.leftTrigger);
            sender.Send("/avatar/parameters/rightTrigger", OSCV.rightTrigger);

            // Example of sending an integer value packed from booleans
            sender.Send("/avatar/parameters/FunnyFunkySendingVar", OSCV.FunnyFunkySendingVar);
        }

        // Send OSC Messages with String data
        public static void VRCOSCMesageString()
        {
            sender.Send(OSCV.CloudVarAddres, OSCV.CloudVarVariable);
            Console.WriteLine($"Sent string OSC message to {OSCV.CloudVarAddres} with value {OSCV.CloudVarVariable}");
        }
    }
}
