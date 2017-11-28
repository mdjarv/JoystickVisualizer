using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VKBGunfighter : MonoBehaviour {
    public const string USB_ID = "231d:011f";

    public GameObject Model;
    public GameObject StickGimbal;

    public GameObject DMS;
    public GameObject CMS;
    public GameObject MasterMode;
    public GameObject Pickle;
    public GameObject PinkyButton;
    public GameObject PinkyLever;
    public GameObject TMS;
    public GameObject Trigger;
    public GameObject Trim;

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
                    // Rotate Z between -30 and 30
                    StickGimbal.transform.eulerAngles = new Vector3(StickGimbal.transform.eulerAngles.x, StickGimbal.transform.eulerAngles.y, ConvertRange(entry.Value, 0, 65535, 20, -20));
                    break;
                case "Y":
                    // Rotate X between -30 and 30
                    StickGimbal.transform.eulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 20, -20), StickGimbal.transform.eulerAngles.y, StickGimbal.transform.eulerAngles.z);
                    break;



                case "Buttons10":
                    DMS.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : 10.0f), DMS.transform.localEulerAngles.y, DMS.transform.localEulerAngles.z);
                    break;
                case "Buttons11":
                    DMS.transform.localEulerAngles = new Vector3(DMS.transform.localEulerAngles.x, ((entry.Value == 0) ? 0.0f : -10.0f), DMS.transform.localEulerAngles.z);
                    break;
                case "Buttons12":
                    DMS.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : -10.0f), DMS.transform.localEulerAngles.y, DMS.transform.localEulerAngles.z);
                    break;
                case "Buttons13":
                    DMS.transform.localEulerAngles = new Vector3(DMS.transform.localEulerAngles.x, ((entry.Value == 0) ? 0.0f : 10.0f), DMS.transform.localEulerAngles.z);
                    break;

                case "Buttons14":
                    CMS.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : 10.0f), CMS.transform.localEulerAngles.y, CMS.transform.localEulerAngles.z);
                    break;
                case "Buttons15":
                    CMS.transform.localEulerAngles = new Vector3(CMS.transform.localEulerAngles.x, CMS.transform.localEulerAngles.y, ((entry.Value == 0) ? 0.0f : -10.0f));
                    break;
                case "Buttons16":
                    CMS.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : -10.0f), CMS.transform.localEulerAngles.y, CMS.transform.localEulerAngles.z);
                    break;
                case "Buttons17":
                    CMS.transform.localEulerAngles = new Vector3(CMS.transform.localEulerAngles.x, CMS.transform.localEulerAngles.y, ((entry.Value == 0) ? 0.0f : 10.0f));
                    break;
                case "Buttons18":
                    CMS.transform.localPosition = new Vector3(CMS.transform.localPosition.x, ((entry.Value == 0) ? 0.0f : -0.10f), CMS.transform.localPosition.z);
                    break;

                case "Buttons6":
                    TMS.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : 10.0f), TMS.transform.localEulerAngles.y, TMS.transform.localEulerAngles.z);
                    break;
                case "Buttons7":
                    TMS.transform.localEulerAngles = new Vector3(TMS.transform.localEulerAngles.x, ((entry.Value == 0) ? 0.0f : -10.0f), TMS.transform.localEulerAngles.z);
                    break;
                case "Buttons8":
                    TMS.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : -10.0f), TMS.transform.localEulerAngles.y, TMS.transform.localEulerAngles.z);
                    break;
                case "Buttons9":
                    TMS.transform.localEulerAngles = new Vector3(TMS.transform.localEulerAngles.x, ((entry.Value == 0) ? 0.0f : 10.0f), TMS.transform.localEulerAngles.z);
                    break;

                case "Buttons1":
                    Pickle.transform.localPosition = new Vector3(Pickle.transform.localPosition.x, Pickle.transform.localPosition.y, ((entry.Value == 0) ? 0.0f : 0.25f));
                    break;

                case "Buttons4":
                    MasterMode.transform.localPosition = new Vector3(((entry.Value == 0) ? 0.0f : -0.20f), MasterMode.transform.localPosition.y, MasterMode.transform.localPosition.z);
                    break;

                case "Buttons2":
                    PinkyButton.transform.localPosition = new Vector3(PinkyButton.transform.localPosition.x, PinkyButton.transform.localPosition.y, ((entry.Value == 0) ? 0.0f : -0.20f));
                    break;

                case "Buttons3":
                    PinkyLever.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : -10.0f), PinkyLever.transform.localEulerAngles.y, PinkyLever.transform.localEulerAngles.z);
                    break;

                case "Buttons0":
                    Trigger.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 0.0f : 10.0f), Trigger.transform.localEulerAngles.y, Trigger.transform.localEulerAngles.z);
                    break;
                case "Buttons5":
                    Trigger.transform.localEulerAngles = new Vector3(((entry.Value == 0) ? 10.0f : 20.0f), Trigger.transform.localEulerAngles.y, Trigger.transform.localEulerAngles.z);
                    break;

                case "PointOfViewControllers0":
                    switch (entry.Value)
                    {
                        case -1: // zero
                            Trim.transform.localEulerAngles = Vector3.zero;
                            break;
                        case 0: // up
                            Trim.transform.localEulerAngles = Vector3.right * 10.0f;
                            break;
                        case 4500: // up/right
                            Trim.transform.localEulerAngles = Vector3.right * 10.0f + Vector3.down * 10.0f;
                            break;
                        case 9000: // right
                            Trim.transform.localEulerAngles = Vector3.down * 10.0f;
                            break;
                        case 13500: // down/right
                            Trim.transform.localEulerAngles = Vector3.down * 10.0f + Vector3.left * 10.0f;
                            break;
                        case 18000: // down
                            Trim.transform.localEulerAngles = Vector3.left * 10.0f;
                            break;
                        case 22500: // down/left
                            Trim.transform.localEulerAngles = Vector3.left * 10.0f + Vector3.up * 10.0f;
                            break;
                        case 27000: // left
                            Trim.transform.localEulerAngles = Vector3.up * 10.0f;
                            break;
                        case 31500: // up/left
                            Trim.transform.localEulerAngles = Vector3.up * 10.0f + Vector3.right * 10.0f;
                            break;
                    }
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
