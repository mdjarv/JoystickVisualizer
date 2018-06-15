using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekCyborgEvoStick : MonoBehaviour
{
    public const string USB_ID = "06a3:0464";

    public GameObject Model;

    public GameObject StickGimbal;
    public GameObject Trigger;
    public GameObject BtnA;
    public GameObject BtnB;
    public GameObject Hat1;

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
                case "RotationZ":
                    StickGimbal.transform.localEulerAngles = new Vector3(StickGimbal.transform.localEulerAngles.x, StickGimbal.transform.localEulerAngles.y, ConvertRange(entry.Value, 0, 65535, -25, 25));
                    break;
                case "Buttons0":
                    Trigger.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -10, Trigger.transform.localEulerAngles.y, Trigger.transform.localEulerAngles.z);
                    break;
                case "Buttons1":
                    BtnB.transform.localPosition = new Vector3(entry.Value == 0 ? -1.474485f : -1.3f, BtnB.transform.localPosition.y, BtnB.transform.localPosition.z);
                    break;
                case "Buttons2":
                    BtnA.transform.localPosition = new Vector3(BtnA.transform.localPosition.x, entry.Value == 0 ? -0.22f : 0, BtnA.transform.localPosition.z);
                    break;
                case "PointOfViewControllers0":
                    float valueX = 0;
                    float valueZ = 0;
                    switch (entry.Value)
                    {
                        case 0:
                            valueX = -5;
                            break;
                        case 4500:
                            valueX = -2.5f;
                            valueZ = -2.5f;
                            break;
                        case 9000:
                            valueZ = -5;
                            break;
                        case 13500:
                            valueX = 2.5f;
                            valueZ = -2.5f;
                            break;
                        case 18000:
                            valueX = 5;
                            break;
                        case 22500:
                            valueX = 2.5f;
                            valueZ = 2.5f;
                            break;
                        case 27000:
                            valueZ = 5;
                            break;
                        case 31500:
                            valueX = 2.5f;
                            valueZ = 2.5f;
                            break;
                    }
                    Hat1.transform.localEulerAngles = new Vector3(valueX, Hat1.transform.localEulerAngles.y, valueZ);
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
