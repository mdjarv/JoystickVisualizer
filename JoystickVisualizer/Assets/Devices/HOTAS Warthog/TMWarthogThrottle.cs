using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMWarthogThrottle : MonoBehaviour {
    public const string USB_ID = "044f:0404";
    private const float FLIP_SWITCH_ROTATION = 20.0f;
    public GameObject Model;

    public GameObject GimbalLeft;
    public GameObject GimbalRight;

    public GameObject GimbalFriction;

    public GameObject FlowL;
    public GameObject FlowR;
    public GameObject IgnL;
    public GameObject IgnR;
    public GameObject Flaps;
    public GameObject APU;
    public GameObject LG;
    public GameObject EAC;
    public GameObject RDR;
    public GameObject AutopilotEngage;
    public GameObject AutopilotLaste;

    public GameObject PinkySwitch;
    public GameObject LeftThrottleButton;

    public GameObject MicSwitch;
    public GameObject SpeedBrake;
    public GameObject BoatSwitch;
    public GameObject ChinaHat;
    public GameObject CoolieHat;

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
                case "RotationZ": // Left Throttle
                    // Rotate Z between -30 and 30
                    GimbalLeft.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    break;

                case "Z": // Right Throttle
                    // Rotate X between -30 and 30
                    GimbalRight.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -25), GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
                    break;
                    
                case "Buttons28": // Right Throttle Idle/Off
                    if (entry.Value == 0)
                        GimbalRight.transform.eulerAngles = new Vector3(-25, GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
                    else
                        GimbalRight.transform.eulerAngles = new Vector3(-35, GimbalRight.transform.eulerAngles.y, GimbalRight.transform.eulerAngles.z);
                    break;

                case "Buttons29": // Left Throttle Idle/Off
                    if (entry.Value == 0)
                        GimbalLeft.transform.eulerAngles = new Vector3(-25, GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    else
                        GimbalLeft.transform.eulerAngles = new Vector3(-35, GimbalLeft.transform.eulerAngles.y, GimbalLeft.transform.eulerAngles.z);
                    break;

                case "Sliders0": // Friction
                    GimbalFriction.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 40, -40), GimbalFriction.transform.eulerAngles.y, GimbalFriction.transform.eulerAngles.z);
                    break;



                case "Buttons5":
                    MicSwitch.transform.localEulerAngles = Vector3.up * ((entry.Value == 0) ? 0.0f : 10.0f);
                    break;
                case "Buttons3":
                    MicSwitch.transform.localEulerAngles = Vector3.down * ((entry.Value == 0) ? 0.0f : 10.0f);
                    break;
                case "Buttons2":
                    MicSwitch.transform.localEulerAngles = Vector3.forward * ((entry.Value == 0) ? 0.0f : 10.0f);
                    break;
                case "Buttons4":
                    MicSwitch.transform.localEulerAngles = Vector3.back * ((entry.Value == 0) ? 0.0f : 10.0f);
                    break;


                case "Buttons6":
                    SpeedBrake.transform.localPosition = Vector3.forward * ((entry.Value == 0) ? 0.0f : 0.4f);
                    break;
                case "Buttons7":
                    SpeedBrake.transform.localPosition = Vector3.back * ((entry.Value == 0) ? 0.0f : 0.4f);
                    break;

                case "Buttons8":
                    BoatSwitch.transform.localEulerAngles = Vector3.down * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons9":
                    BoatSwitch.transform.localEulerAngles = Vector3.up * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;

                case "Buttons10":
                    ChinaHat.transform.localEulerAngles = Vector3.down * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons11":
                    ChinaHat.transform.localEulerAngles = Vector3.up * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;

                case "PointOfViewControllers0":
                    switch(entry.Value)
                    {
                        case -1: // zero
                            CoolieHat.transform.localEulerAngles = Vector3.zero;
                            break;
                        case 0: // up
                            CoolieHat.transform.localEulerAngles = Vector3.left * 10.0f;
                            break;
                        case 4500: // up/right
                            CoolieHat.transform.localEulerAngles = Vector3.left * 10.0f + Vector3.up * 10.0f;
                            break;
                        case 9000: // right
                            CoolieHat.transform.localEulerAngles = Vector3.up * 10.0f;
                            break;
                        case 13500: // down/right
                            CoolieHat.transform.localEulerAngles = Vector3.up * 10.0f + Vector3.right * 10.0f;
                            break;
                        case 18000: // down
                            CoolieHat.transform.localEulerAngles = Vector3.right * 10.0f;
                            break;
                        case 22500: // down/left
                            CoolieHat.transform.localEulerAngles = Vector3.right * 10.0f + Vector3.down * 10.0f;
                            break;
                        case 27000: // left
                            CoolieHat.transform.localEulerAngles = Vector3.down * 10.0f;
                            break;
                        case 31500: // up/left
                            CoolieHat.transform.localEulerAngles = Vector3.down * 10.0f + Vector3.left * 10.0f;
                            break;
                    }
                    break;

                case "Buttons14":
                    LeftThrottleButton.transform.localPosition = Vector3.back * ((entry.Value == 0) ? 0.0f : 0.003f);
                    break;

                case "Buttons15":
                    FlowL.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : 40.0f);
                    break;

                case "Buttons16":
                    FlowR.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : 40.0f);
                    break;

                case "Buttons17":
                    IgnL.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : -FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons30":
                    IgnL.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;

                case "Buttons18":
                    IgnR.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : -FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons31":
                    IgnR.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;

                case "Buttons19":
                    APU.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : 40.0f);
                    break;

                case "Buttons20":
                    LG.transform.localPosition = Vector3.down * ((entry.Value == 0) ? 0.0f : 0.0035f);
                    break;

                case "Buttons25":
                    AutopilotEngage.transform.localPosition = Vector3.down * ((entry.Value == 0) ? 0.0f : 0.0035f);
                    break;

                case "Buttons23":
                    EAC.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : 40.0f);
                    break;

                case "Buttons24":
                    RDR.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : 40.0f);
                    break;

                case "Buttons26":
                    AutopilotLaste.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons27":
                    AutopilotLaste.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : -FLIP_SWITCH_ROTATION);
                    break;

                case "Buttons21":
                    Flaps.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons22":
                    Flaps.transform.eulerAngles = Vector3.right * ((entry.Value == 0) ? 0.0f : -FLIP_SWITCH_ROTATION);
                    break;

                case "Buttons12":
                    PinkySwitch.transform.localEulerAngles = Vector3.up * ((entry.Value == 0) ? 0.0f : FLIP_SWITCH_ROTATION);
                    break;
                case "Buttons13":
                    PinkySwitch.transform.localEulerAngles = Vector3.up * ((entry.Value == 0) ? 0.0f : -FLIP_SWITCH_ROTATION);
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
