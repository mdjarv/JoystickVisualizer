using SharpDX.DirectInput;
using System.Text.RegularExpressions;

namespace Joystick_Proxy
{
    class ControllerDevice
    {
        public string Name { get { return _controllerDevice.InstanceName; } }
        public string UsbId { get { return Regex.Replace(_controllerDevice.ProductGuid.ToString(), @"(^....)(....).*$", "$2:$1"); } }

        private DeviceInstance _controllerDevice;

        public ControllerDevice(DeviceInstance dev)
        {
            _controllerDevice = dev;
        }
    }
}
