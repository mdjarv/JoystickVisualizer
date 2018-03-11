using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekX55Throttle : MonoBehaviour {
    //public const string USB_ID = "0738:a215";
    public const string USB_ID = "044f:0404";

    public GameObject Model;

    public GameObject LeftThrottle;
    public GameObject RightThrottle;

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

                case "X": // Left brake
                    // Rotate Z between 0 and 20
                    LeftThrottle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, 0), 0, 0);
                    break;
                case "Y": // Right brake
                    RightThrottle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, 0), 0, 0);
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
