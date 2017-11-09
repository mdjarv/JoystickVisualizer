using System;
using System.Collections.Generic;

namespace Assets
{
    public class JoystickState
    {
        public string UsbID;
        public string Name;

        public Dictionary<string, int> Data = new Dictionary<string, int>();

        public JoystickState(string[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                switch(i)
                {
                    case 0:
                        UsbID = state[i];
                        break;
                    case 1:
                        Name = state[i];
                        break;
                    default:
                        string[] keyVal = state[i].Split('=');
                        if (keyVal.Length == 2)
                        {
                            Data[keyVal[0]] = Int32.Parse(keyVal[1]);
                        }
                        break;

                }
            }
        }

        public override string ToString()
        {
            string state = String.Format("State of {0} ({1}): ", Name, UsbID);

            foreach (KeyValuePair<string, int> entry in Data)
            {
                state += String.Format("\n * {0} = {1}", entry.Key, entry.Value);
            }

            return state;
        }
    }
}
