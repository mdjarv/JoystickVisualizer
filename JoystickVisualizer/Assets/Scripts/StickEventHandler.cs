using Assets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickEventHandler : MonoBehaviour
{
    public GameObject Camera;
    public GameObject CameraTarget;

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

    void AddDevice(string id, GameObject device)
    {
        activeDevices[id] = device;

        DistributeDevices();
    }

    void RemoveDevice(string id)
    {
        Object.Destroy(activeDevices[id]);
        activeDevices.Remove(id);

        DistributeDevices();
    }

    void DistributeDevices()
    {
        var devices = activeDevices.ToList();
        devices.Sort((x, y) => x.Key.CompareTo(y.Key));

        for (int i = 0; i < devices.Count; i++)
        {
            devices[i].Value.transform.position = new Vector3(
                i * 20.0f,
                devices[i].Value.transform.position.y,
                devices[i].Value.transform.position.z);
        }

        float center = ((devices.Count-1) * 20.0f) / 2;

        CameraTarget.transform.position = new Vector3(center, CameraTarget.transform.position.y, CameraTarget.transform.position.z);
        Camera.transform.position = new Vector3(center, Camera.transform.position.y, Camera.transform.position.z);
    }

    void ManageDeviceState(JoystickState state)
    {
        if (!activeDevices.ContainsKey(state.UsbID))
        {
            Debug.Log("New device found " + state.UsbID);
            switch (state.UsbID)
            {
                case "044f:0402":
                    AddDevice(state.UsbID, InstantiateDevice(ThrustmasterWarthogJoystick, DeviceParent));
                    break;
                case "044f:0404":
                    AddDevice(state.UsbID, InstantiateDevice(ThrustmasterWarthogThrottle, DeviceParent));
                    break;
            }
        }
    }

    void StickEvent(JoystickState state)
    {
        ManageDeviceState(state);
        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            // Debug.Log("Got event: " + entry.Key);
            switch (entry.Key)
            {
                case "Connected":
                    if (entry.Value == 0)
                        RemoveDevice(state.UsbID);
                    break;
                default:
                    ExecuteEvents.Execute<IDeviceEventMessage>(activeDevices[state.UsbID], null, (x, y) => x.HandleEvent(entry.Key, entry.Value));
                    break;
            }
        }
    }
}
