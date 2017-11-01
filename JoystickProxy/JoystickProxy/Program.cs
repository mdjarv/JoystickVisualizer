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

namespace JoystickProxy
{
    class Program
    {
        private static Dictionary<string, string> SupportedDevices = new Dictionary<string, string>();
        private static IPAddress host;
        private static int port;

        static void Main(string[] args)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            host = IPAddress.Parse(data["Config"]["Host"]);
            port = Int32.Parse(data["Config"]["Port"]);

            Console.WriteLine("JoystickProxy");
            Console.WriteLine("=============");
            Console.WriteLine("Outgoing destination: " + host + ":" + port);
            Console.WriteLine("Supported Devices:");

            foreach(KeyData supportedDevice in data["Devices"])
            {
                SupportedDevices.Add(supportedDevice.KeyName, supportedDevice.Value);
                Console.WriteLine(" * " + supportedDevice.Value);
            }

            // TODO Validate config and handle errors nicely
            Console.WriteLine("");
            new Program();
        }

        private ConcurrentDictionary<string, Joystick> connectedJoysticks = new ConcurrentDictionary<string, Joystick>();

        private string GuidToUsbID(Guid guid)
        {
            return Regex.Replace(guid.ToString(), @"(^....)(....).*$", "$2:$1");
        }

        private DirectInput di = new DirectInput();

        public Program()
        {

            System.Timers.Timer deviceFinderTimer = new System.Timers.Timer();
            deviceFinderTimer.Interval = 2000;
            deviceFinderTimer.Elapsed += DeviceFinderTimer_Elapsed;
            deviceFinderTimer.Enabled = true;
            ScanJoysticks();

            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint endPoint = new IPEndPoint(host, port);

                while (true)
                {
                    List<string> outgoingEvents = new List<string>();

                    foreach(Joystick joystick in connectedJoysticks.Values)
                    {
                        try
                        {
                            joystick.Poll();

                            JoystickUpdate[] updates = joystick.GetBufferedData();

                            if (updates.Length > 0)
                            {
                                string usbID = GuidToUsbID(joystick.Information.ProductGuid);
                                string events = usbID + "," + SupportedDevices[usbID];

                                foreach (var state in updates)
                                {
                                    events += "," + state.Offset + "=" + state.Value;
                                }
                                outgoingEvents.Add(events);
                            }
                        }
                        catch (SharpDX.SharpDXException e)
                        {}

                    }

                    if (outgoingEvents.Count > 0)
                    {
                        string outgoingString = String.Join("\n", outgoingEvents);
                        byte[] send_buffer = Encoding.ASCII.GetBytes(outgoingString);
                        sock.SendTo(send_buffer, endPoint);

                        Console.WriteLine(outgoingString);
                    }

                    Thread.Sleep(20);
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

        private void DeviceFinderTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ScanJoysticks();
        }

        private void ScanJoysticks()
        {
            Dictionary<string, Joystick> foundJoysticks = new Dictionary<string, Joystick>();
            Joystick ignored;

            foreach (DeviceInstance device in di.GetDevices())
            {
                string usbId = GuidToUsbID(device.ProductGuid);

                if (SupportedDevices.ContainsKey(usbId))
                {
                    foundJoysticks.Add(usbId, new Joystick(di, device.ProductGuid));
                }
            }

            // Find removed devices
            foreach(string removed in connectedJoysticks.Keys.Except(foundJoysticks.Keys))
            {
                connectedJoysticks[removed].Unacquire();

                connectedJoysticks.TryRemove(removed, out ignored);
                Console.WriteLine(SupportedDevices[removed] + " disconnected");
            }

            // Find added devices

            foreach (string added in foundJoysticks.Keys.Except(connectedJoysticks.Keys))
            {
                foundJoysticks[added].Properties.BufferSize = 32;
                foundJoysticks[added].Acquire();

                if (connectedJoysticks.TryAdd(added, foundJoysticks[added]))
                {
                    Console.WriteLine(SupportedDevices[added] + " connected");
                }
            }
        }
    }
}
