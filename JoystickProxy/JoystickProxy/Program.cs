using System;
using SharpDX.DirectInput;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.IO;

namespace JoystickProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        private byte[] pingMessage = System.Text.Encoding.ASCII.GetBytes("ping\n");
        private DateTime lastMessage = new DateTime();

        private WarthogJoystick warthogJoystick = new WarthogJoystick();
        private WarthogThrottle warthogThrottle = new WarthogThrottle();

        private Joystick joystick;
        private Joystick throttle;

        private TcpClient tcpClient;
        private NetworkStream stream;
        private TcpListener listener;

        public Program()
        {
            Console.WriteLine("Reading devices...");

            DirectInput di = new DirectInput();


            foreach (DeviceInstance device in di.GetDevices())
            {
                //Console.WriteLine(device.InstanceName);
                switch(device.InstanceName)
                {
                    case "Joystick - HOTAS Warthog":
                        joystick = new Joystick(di, device.ProductGuid);
                        break;
                    case "Throttle - HOTAS Warthog":
                        throttle = new Joystick(di, device.ProductGuid);
                        break;
                }
            }

            if (joystick!= null)
            {
                Console.WriteLine("Found Warthog Joystick");
                joystick.Properties.BufferSize = 32;
                joystick.Acquire();
            }
            if (throttle != null)
            {
                Console.WriteLine("Found Warthog Throttle");
                throttle.Properties.BufferSize = 32;
                throttle.Acquire();
            }

            try
            {
                while(true)
                {
                    listener = new TcpListener(IPAddress.Loopback, 9998);
                    Console.WriteLine("Waiting for connection...");
                    listener.Start();
                    tcpClient = listener.AcceptTcpClient();
                    stream = tcpClient.GetStream();

                    Console.WriteLine("Connected!");

                    PollController();
                    Disconnect();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                Console.ReadLine();
            }

        }

        private void Disconnect()
        {
            try
            {
                stream.Close();
                stream = null;
            }
            catch (Exception) { }
            try {
                tcpClient.Close();
                tcpClient = null;
            } catch(Exception) { }
            try {
                listener.Stop();
                listener = null;
            } catch (Exception) { }
            Console.WriteLine("Disconnected");
        }

        private void PollController()
        {
            JoystickUpdate[] updates;
            bool sendJoystick = false;
            bool sendThrottle = false;

            while (true)
            {
                if (joystick != null)
                {
                    joystick.Poll();

                    updates = joystick.GetBufferedData();
                    if (updates.Length > 0)
                    {
                        sendJoystick = true;
                        foreach (var state in updates)
                        {
                            warthogJoystick.UpdateState(state.Offset, state.Value);
                        }
                    }
                }

                if (throttle != null)
                {
                    throttle.Poll();
                    updates = throttle.GetBufferedData();
                    if (updates.Length > 0)
                    {
                        sendThrottle = true;
                        foreach (var state in updates)
                        {
                            warthogThrottle.UpdateState(state.Offset, state.Value);
                        }
                    }
                }


                try
                {
                    if (sendJoystick)
                    {
                        byte[] joystickData = warthogJoystick.GetBytes();
                        stream.Write(joystickData, 0, joystickData.Length);
                        lastMessage = DateTime.Now;
                        sendJoystick = false;
                    }

                    if(sendThrottle)
                    {
                        byte[] throttleData = warthogThrottle.GetBytes();
                        stream.Write(throttleData, 0, throttleData.Length);
                        lastMessage = DateTime.Now;
                        sendThrottle = false;
                    }

                    TimeSpan ts = DateTime.Now - lastMessage;
                    if (ts.TotalSeconds > 1)
                    {
                        stream.Write(pingMessage, 0, pingMessage.Length);
                        lastMessage = DateTime.Now;
                    }
                }
                catch (Exception)
                {
                    return;
                }

                Thread.Sleep(20);
            }

        }
    }
}
