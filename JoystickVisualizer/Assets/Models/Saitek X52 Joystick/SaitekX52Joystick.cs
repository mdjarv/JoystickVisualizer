using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekX52Joystick : MonoBehaviour {
    public const string USB_ID = "06a3:075c";
    public GameObject Model;

    public GameObject Joystick;

    // Use this for initialization
    void Start () {
        UDPListener.StickEventListener += StickEvent;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StickEvent(JoystickState state)
    {
        if (state.UsbID != USB_ID)
        {
            return;
        }

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "X":
                    Model.SetActive(true);
                    Joystick.transform.eulerAngles = new Vector3(Joystick.transform.eulerAngles.x, Joystick.transform.eulerAngles.y, ConvertRange(entry.Value, 0, 65535, 20, -20));
                    break;
                case "Y":
                    Model.SetActive(true);
                    Joystick.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 20, -20), Joystick.transform.eulerAngles.y, Joystick.transform.eulerAngles.z);
                    break;
            }
        }
    }

    public static float ConvertRange(
        double value, // value to convert
        double originalStart, double originalEnd, // original range
        double newStart, double newEnd) // desired range
    {
        double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
        return (float)(newStart + ((value - originalStart) * scale));
    }
}
