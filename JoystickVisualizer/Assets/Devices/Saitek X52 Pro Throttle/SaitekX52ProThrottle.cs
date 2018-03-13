using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekX52ProThrottle : MonoBehaviour {
    public const string USB_ID = "06a3:0762";
    private const float FLIP_SWITCH_ROTATION = 20.0f;
    public GameObject Model;

    public GameObject GimbalLeft;
    public GameObject GimbalRight;

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

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "Z": // Throttle
                    Model.SetActive(true);
                    
                    // Rotate X between -30 and 30
                    GimbalLeft.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    GimbalRight.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
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
