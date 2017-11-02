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

                if (!States.ContainsKey(message[0]))
                {
                    States.Add(message[0], new JoystickState(message[0], message[1]));
                }

                States[message[0]].Update(message);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to read from UDP socket");
        }
    }
}
