using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T16000MDuoRight : MonoBehaviour {
    public const string USB_ID = "044f:b10a right";

    //private static string USB_ID = "044f:0402"; // TM Stick (test)
    //private static string USB_ID = "044f:0404"; // TM Throttle (test)

    public GameObject Model;
    public GameObject StickHandle;

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

                case "X":
                    StickHandle.transform.localEulerAngles = new Vector3(StickHandle.transform.localEulerAngles.x, ConvertRange(entry.Value, 0, 65535, -20, 20), StickHandle.transform.localEulerAngles.z);
                    break;
                case "Y":
                    StickHandle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 20, -20), StickHandle.transform.localEulerAngles.y, StickHandle.transform.localEulerAngles.z);
                    break;

                case "RotationZ":
                    StickHandle.transform.localEulerAngles = new Vector3(StickHandle.transform.localEulerAngles.x, StickHandle.transform.localEulerAngles.y, ConvertRange(entry.Value, 0, 65535, -20, 20));
                    break;

                /*case "Sliders0":
                    Throttle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 30, -85), Throttle.transform.localEulerAngles.y, Throttle.transform.localEulerAngles.z);
                    break;*/
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
