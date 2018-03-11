using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekX55Throttle : MonoBehaviour {
    public const string USB_ID = "0738:a215";
    //public const string USB_ID = "044f:0404";

    public GameObject Model;

    public GameObject LeftThrottle;
    public GameObject RightThrottle;

    public GameObject SW1_SW2;
    public GameObject SW3_SW4;
    public GameObject SW5_SW6;

    public GameObject RTY3;
    public GameObject RTY4;

    public GameObject TGL1;
    public GameObject TGL2;
    public GameObject TGL3;
    public GameObject TGL4;

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
                case "Y":
                    RightThrottle.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, 0), 0, 0);
                    break;

                case "RotationY":
                    RTY3.transform.localEulerAngles = new Vector3(0, 0, ConvertRange(entry.Value, 0, 65535, -150, 150));
                    break;

                case "RotationZ":
                    RTY3.transform.localEulerAngles = new Vector3(0, 0, ConvertRange(entry.Value, 0, 65535, -150, 150));
                    break;

                case "Buttons5":
                    SW1_SW2.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons6":
                    SW1_SW2.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
                    break;

                case "Buttons7":
                    SW3_SW4.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons8":
                    SW3_SW4.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
                    break;

                case "Buttons9":
                    SW5_SW6.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons10":
                    SW5_SW6.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
                    break;

                case "Buttons11":
                    TGL1.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons12":
                    TGL1.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
                    break;

                case "Buttons13":
                    TGL2.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons14":
                    TGL2.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
                    break;

                case "Buttons15":
                    TGL3.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons16":
                    TGL3.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
                    break;

                case "Buttons17":
                    TGL4.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : 30, 0, 0);
                    break;
                case "Buttons18":
                    TGL4.transform.localEulerAngles = new Vector3(entry.Value == 0 ? 0 : -30, 0, 0);
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
