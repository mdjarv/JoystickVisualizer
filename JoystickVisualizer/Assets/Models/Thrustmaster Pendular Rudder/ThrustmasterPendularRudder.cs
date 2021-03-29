using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustmasterPendularRudder : MonoBehaviour {
    public const string USB_ID = "044f:b68f";
    // public const string USB_ID = "054c:09cc";

    public GameObject Model;

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

        Debug.Log("TPR Event");

        Model.SetActive(true);

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "Connected":
                    if (Model.activeInHierarchy)
                        Model.SetActive(entry.Value == 1);
                    break;

                case "Z": // Rudder
                    LeftPedal.transform.localPosition = new Vector3(LeftPedal.transform.localPosition.x, LeftPedal.transform.localPosition.y, ConvertRange(entry.Value, 0, 65535, -75.0f, 50.0));
                    RightPedal.transform.localPosition = new Vector3(RightPedal.transform.localPosition.x, RightPedal.transform.localPosition.y, ConvertRange(entry.Value, 0, 65535, 50.0f, -75.0f));
                    break;
                case "Y": // Left brake
                    LeftPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 0, -30), 0, 0);
                    break;
                case "X": // Right brake
                    RightPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 0, -30), 0, 0);
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
