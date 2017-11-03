using System.Collections;
using System.Net.Sockets;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.Text;
using Assets;

public class UDPListener : MonoBehaviour {

    public int Port = 11000;

	public delegate void StickEvent (JoystickState state);
	public static event StickEvent StickEventListener;

    Dictionary<string, JoystickState> States = new Dictionary<string, JoystickState>();

    private UdpClient listener;

    // Use this for initialization
    void Start () {
        listener = new UdpClient(Port);
    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            while (listener.Available > 0)
            {
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, Port);
                Byte[] recieveBytes = listener.Receive(ref groupEP);
                string[] message = Encoding.ASCII.GetString(recieveBytes).Split(',');

                Debug.Log("Got packet: " + String.Join(",", message));
                if (StickEventListener != null)
                {
                    StickEventListener(new JoystickState(message));
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to read from UDP socket\n" + e.ToString());
        }
    }
}
