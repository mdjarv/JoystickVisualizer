using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekProFlightThrottleQuadrant : MonoBehaviour {
    public const string USB_ID = "06a3:0c2d";
    //public const string USB_ID = "044f:0404";

    public GameObject Model;

    public GameObject Throttle;
    public GameObject Mixture;
    public GameObject Prop;

    public GameObject T1_T2;
    public GameObject T3_T4;
    public GameObject T5_T6;


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
                    Throttle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 65535, 0, -75, 0), 0, 0);
                    break;
                case "Z":
                    Mixture.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 65535, 0, -75, 0), 0, 0);
                    break;
                case "Y":
                    Prop.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 65535, 0, -75, 0), 0, 0);
                    break;

                case "Buttons6":
                    Throttle.transform.localEulerAngles = new Vector3(entry.Value == 0 ? -75 : -90, 0, 0);
                    break;
                case "Buttons8":
                    Mixture.transform.localEulerAngles = new Vector3(entry.Value == 0 ? -75 : -90, 0, 0);
                    break;
                case "Buttons7":
                    Prop.transform.localEulerAngles = new Vector3(entry.Value == 0 ? -75 : -90, 0, 0);
                    break;

                case "Buttons0":
                    T1_T2.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 15, 0, 0);
                    break;
                case "Buttons1":
                    T1_T2.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -15, 0, 0);
                    break;
                case "Buttons2":
                    T3_T4.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 15, 0, 0);
                    break;
                case "Buttons3":
                    T3_T4.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -15, 0, 0);
                    break;
                case "Buttons4":
                    T5_T6.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 15, 0, 0);
                    break;
                case "Buttons5":
                    T5_T6.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -15, 0, 0);
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
