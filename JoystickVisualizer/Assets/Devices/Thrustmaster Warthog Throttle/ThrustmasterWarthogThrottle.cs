using Helpers;
using UnityEngine;

public class ThrustmasterWarthogThrottle : MonoBehaviour, IDeviceEventMessage
{
    private static float FlipSwitchRotation = 20.0f;

    public GameObject ThrottleLeft;
    public GameObject ThrottleRight;

    public GameObject FrictionLever;

    public GameObject MicSwitch;
    public GameObject SpeedBrake;
    public GameObject BoatSwitch;
    public GameObject ChinaHat;
    public GameObject CoolieHat;

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

    public void HandleEvent(string input, int value)
    {
        switch (input)
        {
            case "RotationZ":
                ThrottleLeft.transform.eulerAngles = new Vector3(
                    Convert.Range(value, 0, 65535, 40, -25),
                    ThrottleLeft.transform.eulerAngles.y,
                    ThrottleLeft.transform.eulerAngles.z);
                break;
            case "Z":
                ThrottleRight.transform.eulerAngles = new Vector3(
                    Convert.Range(value, 0, 65535, 40, -25),
                    ThrottleRight.transform.eulerAngles.y,
                    ThrottleRight.transform.eulerAngles.z);
                break;

            case "Buttons28": // Right Throttle Idle/Off
                if (value == 0)
                    ThrottleRight.transform.eulerAngles = new Vector3(
                        -25,
                        ThrottleRight.transform.eulerAngles.y,
                        ThrottleRight.transform.eulerAngles.z);
                else
                    ThrottleRight.transform.eulerAngles = new Vector3(
                        -35,
                        ThrottleRight.transform.eulerAngles.y,
                        ThrottleRight.transform.eulerAngles.z);
                break;

            case "Buttons29": // Left Throttle Idle/Off
                if (value == 0)
                    ThrottleLeft.transform.eulerAngles = new Vector3(
                        -25,
                        ThrottleLeft.transform.eulerAngles.y,
                        ThrottleLeft.transform.eulerAngles.z);
                else
                    ThrottleLeft.transform.eulerAngles = new Vector3(
                        -35,
                        ThrottleLeft.transform.eulerAngles.y,
                        ThrottleLeft.transform.eulerAngles.z);
                break;

            case "Sliders0": // Friction
                FrictionLever.transform.eulerAngles = new Vector3(
                    Convert.Range(value, 0, 65535, 40, -40),
                    FrictionLever.transform.eulerAngles.y,
                    FrictionLever.transform.eulerAngles.z);
                break;

            case "Buttons5":
                MicSwitch.transform.localEulerAngles = Vector3.up * ((value == 0) ? 0.0f : 10.0f);
                break;
            case "Buttons3":
                MicSwitch.transform.localEulerAngles = Vector3.down * ((value == 0) ? 0.0f : 10.0f);
                break;
            case "Buttons2":
                MicSwitch.transform.localEulerAngles = Vector3.forward * ((value == 0) ? 0.0f : 10.0f);
                break;
            case "Buttons4":
                MicSwitch.transform.localEulerAngles = Vector3.back * ((value == 0) ? 0.0f : 10.0f);
                break;


            case "Buttons6":
                SpeedBrake.transform.localPosition = Vector3.forward * ((value == 0) ? 0.0f : 0.4f);
                break;
            case "Buttons7":
                SpeedBrake.transform.localPosition = Vector3.back * ((value == 0) ? 0.0f : 0.4f);
                break;

            case "Buttons8":
                BoatSwitch.transform.localEulerAngles = Vector3.down * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;
            case "Buttons9":
                BoatSwitch.transform.localEulerAngles = Vector3.up * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;

            case "Buttons10":
                ChinaHat.transform.localEulerAngles = Vector3.down * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;
            case "Buttons11":
                ChinaHat.transform.localEulerAngles = Vector3.up * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;

            case "PointOfViewControllers0":
                switch (value)
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
                LeftThrottleButton.transform.localPosition = Vector3.back * ((value == 0) ? 0.0f : 0.003f);
                break;

            case "Buttons15":
                FlowL.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : 40.0f);
                break;

            case "Buttons16":
                FlowR.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : 40.0f);
                break;

            case "Buttons17":
                IgnL.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : -FlipSwitchRotation);
                break;
            case "Buttons30":
                IgnL.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;

            case "Buttons18":
                IgnR.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : -FlipSwitchRotation);
                break;
            case "Buttons31":
                IgnR.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;

            case "Buttons19":
                APU.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : 40.0f);
                break;

            case "Buttons20":
                LG.transform.localPosition = Vector3.down * ((value == 0) ? 0.0f : 0.0035f);
                break;

            case "Buttons25":
                AutopilotEngage.transform.localPosition = Vector3.down * ((value == 0) ? 0.0f : 0.0035f);
                break;

            case "Buttons23":
                EAC.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : 40.0f);
                break;

            case "Buttons24":
                RDR.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : 40.0f);
                break;

            case "Buttons26":
                AutopilotLaste.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;
            case "Buttons27":
                AutopilotLaste.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : -FlipSwitchRotation);
                break;

            case "Buttons21":
                Flaps.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;
            case "Buttons22":
                Flaps.transform.eulerAngles = Vector3.right * ((value == 0) ? 0.0f : -FlipSwitchRotation);
                break;

            case "Buttons12":
                PinkySwitch.transform.localEulerAngles = Vector3.up * ((value == 0) ? 0.0f : FlipSwitchRotation);
                break;
            case "Buttons13":
                PinkySwitch.transform.localEulerAngles = Vector3.up * ((value == 0) ? 0.0f : -FlipSwitchRotation);
                break;

            default:
                Debug.Log("Unhandled input " + input);
                break;
        }
    }
}
