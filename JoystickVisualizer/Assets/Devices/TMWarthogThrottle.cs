using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMWarthogThrottle : MonoBehaviour {
	private static string USB_ID = "044f:0404";

    public GameObject Throttle;

	// Use this for initialization
	void Start () {
		UDPListener.StickEventListener += StickEvent;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void StickEvent(JoystickState state) {
		if(state.UsbID != USB_ID)
        {
            return;
        }

        foreach (KeyValuePair<string, int> entry in state.Data)
        {
            switch(entry.Key)
            {
                case "X":
                    break;
                case "Y":
                    break;
            }
        }
	}
}
