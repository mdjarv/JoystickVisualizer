using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T16000M : MonoBehaviour {
    public const string USB_ID = "044f:b10a";
    
    //private static string USB_ID = "044f:0402"; // TM Stick (test)
    //private static string USB_ID = "044f:0404"; // TM Throttle (test)

    public GameObject Gimbal;
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


        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch (entry.Key)
            {
                case "RotationZ":
                    StickHandle.transform.localEulerAngles = new Vector3(StickHandle.transform.localEulerAngles.x, ConvertRange(entry.Value, 0, 65535, -30, 30), StickHandle.transform.localEulerAngles.z);
                    //q = Quaternion.AngleAxis(angle, Vector3.up);
                    //Gimbal.transform.eulerAngles = q.eulerAngles;
                    break;
                case "X":
                    // Rotate Z between -30 and 30
                    Gimbal.transform.eulerAngles = new Vector3(Gimbal.transform.eulerAngles.x, Gimbal.transform.eulerAngles.y, ConvertRange(entry.Value, 0, 65535, -30, 30));

                    //q = Quaternion.AngleAxis(angle, Vector3.forward);
                    //Gimbal.transform.eulerAngles = q.eulerAngles;
                    break;
                case "Y":
                    // Rotate X between -30 and 30
                    Gimbal.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, -30, 30), Gimbal.transform.eulerAngles.y, Gimbal.transform.eulerAngles.z);

                    //q = Quaternion.AngleAxis(angle, Vector3.right);
                    //Gimbal.transform.eulerAngles = q.eulerAngles;
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
