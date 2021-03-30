using Assets;
using System.Collections.Generic;
using UnityEngine;

public class SaitekX45Throttle : MonoBehaviour {
    public const string USB_ID = "06a3:2541";
    public const string USB_ID_2 = "06a3:053c";
    //public const string USB_ID = "044f:0404";

    public GameObject Model;

    public GameObject Throttle;

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
        if (state.UsbID != USB_ID && state.UsbID != USB_ID_2)
        {
            return;
        }
        Model.SetActive(true);

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "Sliders0": // Throttle
                    Throttle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -25, 28), Throttle.transform.localEulerAngles.y, Throttle.transform.localEulerAngles.z);
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

