using Helpers;
using UnityEngine;

public class ThrustmasterWarthogJoystick: MonoBehaviour, IDeviceEventMessage
{
    private float ButtonDistance = 10.0f;

    public GameObject Handle;

    public GameObject Trigger;
    public GameObject DMS;
    public GameObject CMS;
    public GameObject MasterMode;
    public GameObject Pickle;
    public GameObject PinkyButton;
    public GameObject PinkyLever;
    public GameObject TMS;
    public GameObject Trim;

    public void HandleEvent(string input, int value)
    {
        switch (input)
        {
            case "X":
                Handle.transform.localEulerAngles = new Vector3(Handle.transform.localEulerAngles.x, Handle.transform.localEulerAngles.y, Convert.Range(value, 0, 65535, 20, -20));
                break;
            case "Y":
                Handle.transform.localEulerAngles = new Vector3(Convert.Range(value, 0, 65535, 20, -20), Handle.transform.localEulerAngles.y, Handle.transform.localEulerAngles.z);
                break;
            case "Buttons0":
                Trigger.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : -ButtonDistance), Trigger.transform.localEulerAngles.y, Trigger.transform.localEulerAngles.z);
                break;
            case "Buttons5":
                Trigger.transform.localEulerAngles = new Vector3(((value == 0) ? -ButtonDistance : -20.0f), Trigger.transform.localEulerAngles.y, Trigger.transform.localEulerAngles.z);
                break;

            case "Buttons10":
                DMS.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : ButtonDistance), DMS.transform.localEulerAngles.y, DMS.transform.localEulerAngles.z);
                break;
            case "Buttons11":
                DMS.transform.localEulerAngles = new Vector3(DMS.transform.localEulerAngles.x, ((value == 0) ? 0.0f : -ButtonDistance), DMS.transform.localEulerAngles.z);
                break;
            case "Buttons12":
                DMS.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : -ButtonDistance), DMS.transform.localEulerAngles.y, DMS.transform.localEulerAngles.z);
                break;
            case "Buttons13":
                DMS.transform.localEulerAngles = new Vector3(DMS.transform.localEulerAngles.x, ((value == 0) ? 0.0f : ButtonDistance), DMS.transform.localEulerAngles.z);
                break;

            case "Buttons14":
                CMS.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : ButtonDistance), CMS.transform.localEulerAngles.y, CMS.transform.localEulerAngles.z);
                break;
            case "Buttons15":
                CMS.transform.localEulerAngles = new Vector3(CMS.transform.localEulerAngles.x, CMS.transform.localEulerAngles.y, ((value == 0) ? 0.0f : -ButtonDistance));
                break;
            case "Buttons16":
                CMS.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : -ButtonDistance), CMS.transform.localEulerAngles.y, CMS.transform.localEulerAngles.z);
                break;
            case "Buttons17":
                CMS.transform.localEulerAngles = new Vector3(CMS.transform.localEulerAngles.x, CMS.transform.localEulerAngles.y, ((value == 0) ? 0.0f : ButtonDistance));
                break;
            case "Buttons18":
                CMS.transform.localPosition = new Vector3(CMS.transform.localPosition.x, ((value == 0) ? 0.0f : -0.10f), CMS.transform.localPosition.z);
                break;

            case "Buttons6":
                TMS.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : ButtonDistance), TMS.transform.localEulerAngles.y, TMS.transform.localEulerAngles.z);
                break;
            case "Buttons7":
                TMS.transform.localEulerAngles = new Vector3(TMS.transform.localEulerAngles.x, ((value == 0) ? 0.0f : -ButtonDistance), TMS.transform.localEulerAngles.z);
                break;
            case "Buttons8":
                TMS.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : -ButtonDistance), TMS.transform.localEulerAngles.y, TMS.transform.localEulerAngles.z);
                break;
            case "Buttons9":
                TMS.transform.localEulerAngles = new Vector3(TMS.transform.localEulerAngles.x, ((value == 0) ? 0.0f : ButtonDistance), TMS.transform.localEulerAngles.z);
                break;

            case "Buttons1":
                Pickle.transform.localPosition = new Vector3(Pickle.transform.localPosition.x, Pickle.transform.localPosition.y, ((value == 0) ? 0.0f : 0.25f));
                break;

            case "Buttons4":
                MasterMode.transform.localPosition = new Vector3(((value == 0) ? 0.0f : -0.20f), MasterMode.transform.localPosition.y, MasterMode.transform.localPosition.z);
                break;

            case "Buttons2":
                PinkyButton.transform.localPosition = new Vector3(PinkyButton.transform.localPosition.x, PinkyButton.transform.localPosition.y, ((value == 0) ? 0.0f : -0.20f));
                break;

            case "Buttons3":
                PinkyLever.transform.localEulerAngles = new Vector3(((value == 0) ? 0.0f : ButtonDistance), PinkyLever.transform.localEulerAngles.y, PinkyLever.transform.localEulerAngles.z);
                break;

            case "PointOfViewControllers0":
                switch (value)
                {
                    case -1: // zero
                        Trim.transform.localEulerAngles = Vector3.zero;
                        break;
                    case 0: // up
                        Trim.transform.localEulerAngles = Vector3.right * ButtonDistance;
                        break;
                    case 4500: // up/right
                        Trim.transform.localEulerAngles = Vector3.right * ButtonDistance + Vector3.down * ButtonDistance;
                        break;
                    case 9000: // right
                        Trim.transform.localEulerAngles = Vector3.down * ButtonDistance;
                        break;
                    case 13500: // down/right
                        Trim.transform.localEulerAngles = Vector3.down * ButtonDistance + Vector3.left * ButtonDistance;
                        break;
                    case 18000: // down
                        Trim.transform.localEulerAngles = Vector3.left * ButtonDistance;
                        break;
                    case 22500: // down/left
                        Trim.transform.localEulerAngles = Vector3.left * ButtonDistance + Vector3.up * ButtonDistance;
                        break;
                    case 27000: // left
                        Trim.transform.localEulerAngles = Vector3.up * ButtonDistance;
                        break;
                    case 31500: // up/left
                        Trim.transform.localEulerAngles = Vector3.up * ButtonDistance + Vector3.right * ButtonDistance;
                        break;
                }
                break;

            default:
                Debug.Log("Unhandled input " + input);
                break;
        }
    }
}
