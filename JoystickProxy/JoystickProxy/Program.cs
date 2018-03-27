using System;
using SharpDX.DirectInput;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using IniParser;
using IniParser.Model;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace JoystickProxy
{
    class Program
    {
        private static int FPS = 30;
        private static int FrameTime;
        private bool Debug = true;
        private static Dictionary<string, string> SupportedDevices = new Dictionary<string, string>();
        private static Dictionary<Guid, string> InstanceGuidToUsbIdLookup = new Dictionary<Guid, string>();
        private static IPAddress host;
        private static int port;

        static void Main(string[] args)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            host = IPAddress.Parse(data["Config"]["Host"]);
            port = Int32.Parse(data["Config"]["Port"]);
            FrameTime = 1000 / Int32.Parse(data["Config"]["FPS"]);

            Console.WriteLine("JoystickProxy");
            Console.WriteLine("=============");
            Console.WriteLine("Outgoing destination: " + host + ":" + port);
            Console.WriteLine("Supported Devices:");

            foreach(KeyData supportedDevice in data["Devices"])
            {
                if(supportedDevice.KeyName.StartsWith("#"))
                {
                    continue;
                }

                SupportedDevices.Add(supportedDevice.KeyName, supportedDevice.Value);
                Console.WriteLine(" * " + supportedDevice.Value);
            }

            // TODO Validate config and handle errors nicely
            Console.WriteLine("");
            new Program();
        }

        private ConcurrentDictionary<Guid, Joystick> connectedJoysticks = new ConcurrentDictionary<Guid, Joystick>();

        private string GuidToUsbID(Guid guid)
        {
            return Regex.Replace(guid.ToString(), @"(^....)(....).*$", "$2:$1");
        }

        private string GetUsbId(Joystick joystick)
        {
            return GuidToUsbID(joystick.Information.ProductGuid);
        }

        private DirectInput di = new DirectInput();
        private Socket sock;
        private IPEndPoint endPoint;

        public Program()
        {


            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                endPoint = new IPEndPoint(host, port);

                System.Timers.Timer deviceFinderTimer = new System.Timers.Timer(2000);
                deviceFinderTimer.Elapsed += DeviceFinderTimer_Elapsed;
                deviceFinderTimer.Enabled = true;
                ScanJoysticks();

                while (true)
                {
                    Stopwatch sw = new Stopwatch();
                    foreach (Joystick joystick in connectedJoysticks.Values)
                    {
                        sw.Start();
                        try
                        {
                            joystick.Poll();
                            JoystickUpdate[] updates = joystick.GetBufferedData();

                            if (updates.Length > 0)
                            {
                                string usbID = GetUsbId(joystick);
                                List<string> events = new List<string>();
                                
                                foreach (var state in updates)
                                {
                                    events.Add(state.Offset + "=" + state.Value);
                                }

                                SendEvent(sock, endPoint, usbID, events);
                            }
                        }
                        catch (SharpDX.SharpDXException)
                        {}

                    }
                    sw.Stop();
                    int sleepTime = FrameTime - (int)sw.ElapsedMilliseconds;
                    if (sleepTime > 0)
                    {
                        Thread.Sleep(sleepTime);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                Console.ReadLine();
            }
            

            foreach (Joystick joystick in connectedJoysticks.Values)
            {
                Console.WriteLine("Closing connection to " + joystick.Information.InstanceName);
                joystick.Unacquire();
            }

            Console.WriteLine("\nPress any key to close");
            Console.ReadLine();

        }

        private void SendEvent(Socket sock, IPEndPoint endPoint, Guid instanceGuid, List<string> events)
        {
            SendEvent(sock, endPoint, InstanceGuidToUsbIdLookup[instanceGuid], events);
        }

        private void SendEvent(Socket sock, IPEndPoint endPoint, string usbID, List<string> events)
        {
            if (sock == null || endPoint == null)
                return;

            string outgoingString = String.Format("{0},{1},{2}", usbID, SupportedDevices[usbID], String.Join(",", events));
            byte[] send_buffer = Encoding.ASCII.GetBytes(outgoingString);
            sock.SendTo(send_buffer, endPoint);
            if (Debug)
            {
                Console.WriteLine(outgoingString);
            }
        }

        private void DeviceFinderTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ScanJoysticks();
        }

        private void ScanJoysticks()
        {
            bool changesMade = false;
            Dictionary<Guid, Joystick> foundJoysticks = new Dictionary<Guid, Joystick>();

            foreach (DeviceInstance device in di.GetDevices())
            {
                string usbId = GuidToUsbID(device.ProductGuid);

                //Console.WriteLine("Found DirectInput device " + usbId + ": " + device.InstanceName);

                if (SupportedDevices.ContainsKey(usbId))
                {
                    try
                    {
                        InstanceGuidToUsbIdLookup[device.InstanceGuid] = usbId;
                        //Console.WriteLine("Registering device " + device.InstanceName+ " " + usbId + " | " + device.InstanceGuid);
                        foundJoysticks.Add(device.InstanceGuid, new Joystick(di, device.InstanceGuid));
                    } catch(ArgumentException e)
                    {
                        Console.WriteLine("Failed to register device " + device.InstanceName + " " + usbId + " | " + device.InstanceGuid, e);
                    }
                }
            }

            // Find removed devices
            foreach(Guid removed in connectedJoysticks.Keys.Except(foundJoysticks.Keys))
            {
                changesMade = true;
                connectedJoysticks[removed].Unacquire();

                connectedJoysticks.TryRemove(removed, out Joystick ignored);
                Console.WriteLine(SupportedDevices[InstanceGuidToUsbIdLookup[removed]] + " disconnected");
                List<string> events = new List<string>
                {
                    "Connected=0"
                };
                SendEvent(sock, endPoint, removed, events);
            }

            // Find added devices

            foreach (Guid added in foundJoysticks.Keys.Except(connectedJoysticks.Keys))
            {
                changesMade = true;
                foundJoysticks[added].Properties.BufferSize = 32;
                foundJoysticks[added].Acquire();

                if (connectedJoysticks.TryAdd(added, foundJoysticks[added]))
                {
                    Console.WriteLine(SupportedDevices[InstanceGuidToUsbIdLookup[added]] + " connected");
                    List<string> events = new List<string>
                    {
                        "Connected=1"
                    };
                    SendEvent(sock, endPoint, added, events);
                }
            }

            if(changesMade)
            {
                Console.WriteLine("Connected devices:");
                foreach(Joystick joystick in connectedJoysticks.Values)
                {
                    Console.WriteLine(" * " + joystick.Information.InstanceName + " (" + joystick.Information.InstanceGuid + ")");
                }
            }
        }
    }
}
