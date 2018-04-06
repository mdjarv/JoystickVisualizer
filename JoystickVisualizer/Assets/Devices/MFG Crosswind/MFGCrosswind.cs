using Assets;
using System.Collections.Generic;
using UnityEngine;

public class MFGCrosswind : MonoBehaviour
{
    public const string USB_ID = "????:????";
    //public const string USB_ID = "06a3:0764";

    public GameObject Model;

    public GameObject BearingFront;
    public GameObject BearingBack;

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

                case "RotationZ":
                    float rotation = ConvertRange(entry.Value, 0, 65535, 30, -30);
                    BearingFront.transform.localEulerAngles = new Vector3(0, 0, rotation);
                    BearingBack.transform.localEulerAngles = new Vector3(0, 0, rotation);
                    RightPedal.transform.eulerAngles = new Vector3(RightPedal.transform.eulerAngles.x, 0, RightPedal.transform.eulerAngles.z);
                    LeftPedal.transform.eulerAngles = new Vector3(LeftPedal.transform.eulerAngles.x, 0, LeftPedal.transform.eulerAngles.z);
                    break;
                case "X": // Left brake
                    LeftPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -40, -10), 0, 0);
                    break;
                case "Y": // Right brake
                    RightPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -40, -10), 0, 0);
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
