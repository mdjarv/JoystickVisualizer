using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Joystick_Proxy
{
    class ControllerDevice
    {
        public string Name { get { return _controllerDevice.InstanceName; } }
        public string UsbId { get { return Regex.Replace(_controllerDevice.ProductGuid.ToString(), @"(^....)(....).*$", "$2:$1"); } }
        public Joystick Joystick { get => _joystick; set => _joystick = value; }
        public SortedDictionary<string, JoystickUpdate> CurrentState { get => inputStateDict; }

        private SortedDictionary<string, JoystickUpdate> inputStateDict = new SortedDictionary<string, JoystickUpdate>();

        private DeviceInstance _controllerDevice;
        private Joystick _joystick;

        public ControllerDevice(DirectInput di, DeviceInstance dev)
        {
            _controllerDevice = dev;
            Joystick = new Joystick(di, dev.InstanceGuid);
            Joystick.Properties.BufferSize = 32;
            Joystick.Acquire();
        }

        public SortedDictionary<string, JoystickUpdate> Update() {
            Joystick.Poll();

            foreach (JoystickUpdate joystickUpdate in Joystick.GetBufferedData())
            {
                inputStateDict[joystickUpdate.Offset.ToString()] = joystickUpdate;
            }

            return inputStateDict;
        }
    }
}
