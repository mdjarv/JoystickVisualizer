using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaitekCombatRudder : MonoBehaviour {
    public const string USB_ID = "06a3:0764";

    public GameObject Model;

    public GameObject LeftPedal;
    public GameObject RightPedal;

    public GameObject LeftPedalBrake;
    public GameObject RightPedalBrake;
    
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
                case "RotationZ": // Pedal Position -0.05 0.05
                    LeftPedal.transform.position = new Vector3(LeftPedal.transform.position.x, LeftPedal.transform.position.y, ConvertRange(entry.Value, 0, 65535, 3, -3));
                    RightPedal.transform.position = new Vector3(RightPedal.transform.position.x, RightPedal.transform.position.y, ConvertRange(entry.Value, 0, 65535, -3, 3));
                    break;
                case "X": // Left brake
                    // Rotate Z between 0 and 20
                    LeftPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 0, 20), 0, 0);
                    break;
                case "Y": // Right brake
                    RightPedalBrake.transform.localEulerAngles = new Vector3(ConvertRange(entry.Value, 0, 65535, 0, 20), 0, 0);
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
