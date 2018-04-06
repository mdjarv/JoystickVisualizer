using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Joystick_Proxy
{
    public class ControllerDevice : IEquatable<ControllerDevice>
    {
        public delegate void DeviceStateUpdateHandler(object sender, DeviceStateUpdateEventArgs e);
        public event DeviceStateUpdateHandler OnStateUpdated;

        public string Name { get { return _deviceInstance.InstanceName; } }
        public string Guid { get { return _deviceInstance.InstanceGuid.ToString();  } }
        public string UsbId { get => _usbId; }

        public Joystick Joystick { get => _joystick; set => _joystick = value; }
        public SortedDictionary<string, JoystickUpdate> CurrentState { get => _inputStateDictionary; }
        private SortedDictionary<string, JoystickUpdate> _inputStateDictionary = new SortedDictionary<string, JoystickUpdate>();

        public DeviceInstance DeviceInstance { get => _deviceInstance; }

        private DeviceInstance _deviceInstance;
        private Joystick _joystick;
        private string _usbId;

        private bool NotPollable = false;

        public ControllerDevice(DirectInput di, DeviceInstance deviceInstance)
        {
            _deviceInstance = deviceInstance;
            _usbId = Regex.Replace(_deviceInstance.ProductGuid.ToString(), @"(^....)(....).*$", "$2:$1");
            _joystick = new Joystick(di, deviceInstance.InstanceGuid);

            Joystick.Properties.BufferSize = 32;
        }

        public void Update() {
            if (NotPollable)
                return;

            try
            {
                Joystick.Poll();
            }
            catch (Exception)
            {
                NotPollable = true;
                return;
            }

            List<JoystickUpdate> updatedStates = new List<JoystickUpdate>();

            foreach (JoystickUpdate joystickUpdate in Joystick.GetBufferedData())
            {
                _inputStateDictionary[joystickUpdate.Offset.ToString()] = joystickUpdate;
                updatedStates.Add(joystickUpdate);
            }

            if(updatedStates.Count > 0)
                UpdateState(updatedStates);
        }

        private void UpdateState(List<JoystickUpdate> updatedStates)
        {
            // Make sure someone is listening to event
            if (OnStateUpdated == null) return;

            DeviceStateUpdateEventArgs args = new DeviceStateUpdateEventArgs(this, updatedStates);
            OnStateUpdated(this, args);
        }

        public override int GetHashCode()
        {
            return _deviceInstance.InstanceGuid.GetHashCode();
        }

        public bool Equals(ControllerDevice other)
        {
            return _deviceInstance.InstanceGuid == other.DeviceInstance.InstanceGuid;
        }

        internal void Unacquire()
        {
            try { Joystick.Unacquire(); } catch (Exception) { }
        }

        internal void Acquire()
        {
            Joystick.Acquire();
        }
    }

    public class DeviceStateUpdateEventArgs
    {
        public List<JoystickUpdate> UpdatedStates { get; set; }
        public ControllerDevice Device { get; set; }

        public DeviceStateUpdateEventArgs(ControllerDevice device, List<JoystickUpdate> updatedStates)
        {
            this.Device = device;
            this.UpdatedStates = updatedStates;
        }
    }
}
