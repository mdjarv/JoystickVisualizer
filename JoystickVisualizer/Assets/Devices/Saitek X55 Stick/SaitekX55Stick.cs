using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekX55Stick : MonoBehaviour {
    //public const string USB_ID = "0738:2215";
    public const string USB_ID = "044f:0402";

    public GameObject Model;

    public GameObject StickGimbal;

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
                    StickGimbal.transform.localEulerAngles = new Vector3(StickGimbal.transform.localEulerAngles.x, ConvertRange(entry.Value, 0, 65535, 25, -25), StickGimbal.transform.localEulerAngles.z);
                    break;
                case "Y":
                    StickGimbal.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -25, 25), StickGimbal.transform.localEulerAngles.y, StickGimbal.transform.localEulerAngles.z);
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
