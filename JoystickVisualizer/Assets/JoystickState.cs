using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class JoystickState
    {
        public string UsbID;
        public string Name;

        public Dictionary<string, string> Data;

        public JoystickState(string usbID, string name)
        {
            UsbID = usbID;
            Name = name;
            Data = new Dictionary<string, string>();
        }

        internal void Update(string[] message)
        {
            for (int i = 2; i < message.Length; i++)
            {
                string[] state = message[i].Split('=');

                Data[state[0]] = state[1];
            }

            // Debug.Log(this.ToString());
        }

        public override string ToString()
        {
            string state = String.Format("State of {0} ({1}): ", Name, UsbID);

            foreach (KeyValuePair<string, string> entry in Data)
            {
                state += String.Format("\n * {0} = {1}", entry.Key, entry.Value);
            }

            return state;
        }
    }
}
