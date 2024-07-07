using Assets;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ThrustmasterTFlightHOTAS4Throttle : MonoBehaviour {
    public const string USB_ID = "044f:b67c";
    //public const string USB_ID = "044f:0404";

    public GameObject Model;
    public GameObject LeftThrottle;
    public GameObject RightThrottle;

    private int ZVal = 32767;
    private int Slider0Val = 32767;

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

                case "Z":
                    ZVal = entry.Value;
                    break;

                case "Sliders0":
                    Slider0Val = entry.Value;
                    break;
            }

            int LeftValue = Math.Max(0, Math.Min(65535, ZVal + (Slider0Val - 32767) / 2));
            int RightValue = Math.Max(0, Math.Min(65535, ZVal - (Slider0Val - 32767) / 2));

            RightThrottle.transform.localEulerAngles = new Vector3(ConvertRange(RightValue, 0, 65535, 30, -30), RightThrottle.transform.localEulerAngles.y, RightThrottle.transform.localEulerAngles.z);
            LeftThrottle.transform.localEulerAngles = new Vector3(ConvertRange(LeftValue, 0, 65535, 30, -30), LeftThrottle.transform.localEulerAngles.y, LeftThrottle.transform.localEulerAngles.z);
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
