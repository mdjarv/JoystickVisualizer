using Helpers;
using UnityEngine;

public class ThrustmasterWarthogJoystick: MonoBehaviour, IDeviceEventMessage
{
    public GameObject Handle;

    public void HandleEvent(string input, int value)
    {
        switch (input)
        {
            case "X":
                Handle.transform.localEulerAngles = new Vector3(Handle.transform.localEulerAngles.x, Convert.Range(value, 0, 65535, 20, -20), Handle.transform.localEulerAngles.z);
                break;
            case "Y":
                Handle.transform.localEulerAngles = new Vector3(Convert.Range(value, 0, 65535, -20, 20), Handle.transform.localEulerAngles.y, Handle.transform.localEulerAngles.z);
                break;
            default:
                Debug.Log("Unhandled input " + input);
                break;
        }
    }
}
