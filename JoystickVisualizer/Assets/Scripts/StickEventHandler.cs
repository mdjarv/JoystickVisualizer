using Assets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickEventHandler : MonoBehaviour
{
    public GameObject DeviceParent;

    public GameObject SaitekCombatRudderPedals;
    public GameObject ThrustmasterWarthogJoystick;
    public GameObject ThrustmasterWarthogThrottle;

    private Dictionary<string, GameObject> activeDevices = new Dictionary<string, GameObject>();

    private GameObject InstantiateDevice(GameObject prefab, GameObject parent)
    {
        GameObject obj = Instantiate<GameObject>(prefab, parent.transform);
        obj.name = "Device [" + obj.name + "]";
        obj.transform.parent = parent.transform;
        return obj;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Registering Stick Event Handler");
        UDPListener.StickEventListener += StickEvent;
    }

    void StickEvent(JoystickState state)
    {
        if (!activeDevices.ContainsKey(state.UsbID))
        {
            Debug.Log("New device found " + state.UsbID);
            switch (state.UsbID)
            {
                case "044f:0402":
                    activeDevices[state.UsbID] = InstantiateDevice(ThrustmasterWarthogJoystick, DeviceParent);
                    break;
                case "044f:0404":
                    activeDevices[state.UsbID] = InstantiateDevice(ThrustmasterWarthogThrottle, DeviceParent);
                    break;
            }
        }

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            // Debug.Log("Got event: " + entry.Key);
            switch (entry.Key)
            {
                case "Connected":
                    if (entry.Value == 0)
                    {
                        Object.Destroy(activeDevices[state.UsbID]);
                        activeDevices.Remove(state.UsbID);
                    }
                    break;
                default:
                    ExecuteEvents.Execute<IDeviceEventMessage>(activeDevices[state.UsbID], null, (x, y) => x.HandleEvent(entry.Key, entry.Value));
                    break;
            }
        }
    }
}
