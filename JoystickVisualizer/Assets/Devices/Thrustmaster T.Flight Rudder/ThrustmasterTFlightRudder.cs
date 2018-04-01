using Assets;
using System.Collections.Generic;
using UnityEngine;

public class ThrustmasterTFlightRudder : MonoBehaviour {
    public const string USB_ID = "044f:b679";
    //public const string USB_ID = "06a3:0764";

    public GameObject Model;

    public GameObject CenterIndicator;

    public GameObject LeftPedal;
    public GameObject RightPedal;

    public GameObject LeftPedalBrake;
    public GameObject RightPedalBrake;

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
                    LeftPedal.transform.localPosition = new Vector3(LeftPedal.transform.localPosition.x, ConvertRange(entry.Value, 0, 65535, 2.0, -1.2), LeftPedal.transform.localPosition.z);
                    RightPedal.transform.localPosition = new Vector3(RightPedal.transform.localPosition.x, ConvertRange(entry.Value, 0, 65535, -1.2, 2.0), RightPedal.transform.localPosition.z);
                    CenterIndicator.transform.localEulerAngles = new Vector3(0, 0, ConvertRange(entry.Value, 0, 65535, 30, -30));
                    break;
                case "Y": // Left brake
                    LeftPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -20, 0), 0, 0);
                    break;
                case "X": // Right brake
                    RightPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -20, 0), 0, 0);
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