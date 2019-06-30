using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickEventHandler : MonoBehaviour
{
    public GameObject DeviceOrigin;
    public GameObject TMWHJ;

    private Dictionary<string, GameObject> activeDevices;

    // Start is called before the first frame update
    void Start()
    {
        activeDevices = new Dictionary<string, GameObject>();

        Debug.Log("Registering Stick Event Handler");
        UDPListener.StickEventListener += StickEvent;
    }

    void StickEvent(JoystickState state)
    {
        if (!activeDevices.ContainsKey(state.UsbID))
        {
            GameObject obj;
            obj = Instantiate<GameObject>(TMWHJ, DeviceOrigin.transform);
            obj.name = "My thingy [" + obj.name + "]";
            obj.transform.parent = DeviceOrigin.transform;

            activeDevices[state.UsbID] = obj;
        }

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            //Debug.Log("Got event: " + entry.Key);
            switch (entry.Key)
            {
                case "Connected":
                    if (entry.Value == 0)
                    {
                        Object.Destroy(activeDevices[state.UsbID]);
                        activeDevices.Remove(state.UsbID);
                    }
                    break;
            }
        }
    }
}
