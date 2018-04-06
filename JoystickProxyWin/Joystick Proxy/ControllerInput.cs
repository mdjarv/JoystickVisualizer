using SharpDX.DirectInput;
using System.Text.RegularExpressions;

namespace Joystick_Proxy
{
    class ControllerInput
    {
        public string Name { get => _name; set => _name = value; }
        public int Value { get => _value; set => _value = value; }

        private string _name;
        private int _value;

        public ControllerInput(bool connected)
        {
            Name = "Connected";
            Value = connected ? 1 : 0;
        }

        public ControllerInput(JoystickUpdate joystickUpdate)
        {
            Name = joystickUpdate.Offset.ToString();
            Value = joystickUpdate.Value;
        }

        public override string ToString()
        {
            return Name + "=" + Value;
        }
    }
}