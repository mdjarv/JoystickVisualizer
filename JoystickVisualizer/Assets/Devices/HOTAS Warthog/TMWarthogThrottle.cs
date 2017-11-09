using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMWarthogThrottle : MonoBehaviour {
    public const string USB_ID = "044f:0404";

    public GameObject Model;
    public GameObject GimbalLeft;
    public GameObject GimbalRight;
    public GameObject GimbalFriction;

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
                case "RotationZ": // Left Throttle
                    // Rotate Z between -30 and 30
                    GimbalLeft.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    break;
                case "Z": // Right Throttle
                    // Rotate X between -30 and 30
                    GimbalRight.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
                    break;
                case "Buttons29": // Left Throttle Idle/Off
                    if (entry.Value == 0)
                        GimbalLeft.transform.eulerAngles = new Vector3(-25, GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    else
                        GimbalLeft.transform.eulerAngles = new Vector3(-35, GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    break;
                case "Buttons28": // Left Throttle Idle/Off
                    if (entry.Value == 0)
                        GimbalRight.transform.eulerAngles = new Vector3(-25, GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
                    else
                        GimbalRight.transform.eulerAngles = new Vector3(-35, GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
                    break;
                case "Sliders0": // Friction
                    GimbalFriction.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -40), GimbalFriction.transform.eulerAngles.y, GimbalFriction.transform.eulerAngles.z);
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
