using Assets;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleThrustmasterWarthog : MonoBehaviour {
    public const string USB_ID = "044f:0404";

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
                case "Connected":
                    if (Model.activeInHierarchy)
                        Model.SetActive(entry.Value == 1);
                    break;

                case "RotationZ": // Left Throttle
                    // Rotate Z between -30 and 30
                    LeftThrottle.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), LeftThrottle.transform.eulerAngles.y, LeftThrottle.transform.eulerAngles.z);
                    break;

                case "Z": // Right Throttle
                    // Rotate X between -30 and 30
                    RightThrottle.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), RightThrottle.transform.eulerAngles.y, RightThrottle.transform.eulerAngles.z);
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
