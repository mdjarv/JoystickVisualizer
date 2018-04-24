using Assets;
using System.Collections.Generic;
using UnityEngine;

public class T16000MThrottle : MonoBehaviour {
    public const string USB_ID = "044f:b687";
    //public const string USB_ID = "044f:0404";

    public GameObject Model;

    public GameObject LeftThrottle;
    public GameObject RightThrottle;

    // Use this for initialization
    void Start()
    {
        UDPListener.StickEventListener += StickEvent;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StickEvent(JoystickState state)
    {
        if (state.UsbID != USB_ID)
        {
            return;
        }
        Model.SetActive(true);

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "Z": // Throttle
                    LeftThrottle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 28, -25), LeftThrottle.transform.localEulerAngles.y, LeftThrottle.transform.localEulerAngles.z);
                    RightThrottle.transform.localEulerAngles = LeftThrottle.transform.localEulerAngles;
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

