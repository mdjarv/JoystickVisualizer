using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T16000M : MonoBehaviour {
    private static string USB_ID = "044f:b10a";
    //private static string USB_ID = "044f:0402";
    public GameObject Gimbal;

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

        Debug.Log("T-16000M got new state");

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "X":
                    // Rotate Z between -30 and 30
                    Gimbal.transform.eulerAngles = new Vector3(Gimbal.transform.eulerAngles.x, Gimbal.transform.eulerAngles.y, ConvertRange(entry.Value, 0, 65535, -30, 30));
                    break;
                case "Y":
                    // Rotate X between -30 and 30
                    Gimbal.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -30, 30), Gimbal.transform.eulerAngles.y, Gimbal.transform.eulerAngles.z);
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
