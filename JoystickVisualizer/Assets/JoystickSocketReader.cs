using UnityEngine;
using System.Net.Sockets;
using System;
using JoystickProxy;

public class JoystickSocketReader : MonoBehaviour {
    private int HAT_ANGLE = 8;
    private int FLIP_ANGLE = 16;

    private float BUTTON_PRESS = 0.22f;

    private float TRIGGER1_PRESS = 8.0f;
    private float TRIGGER2_PRESS = 24.0f;

    private float PINKY_LEVER_PRESS = 18.0f;

    private float SPEEDBRAKE_DISTANCE = 0.30f;

    private DateTime lastMessage = new DateTime(0);

    public GameObject connectionError;

    public string host = "127.0.0.1";
    public int port = 9998;

    public GameObject joystickGimbal;

    public GameObject triggerGimbal;

    public GameObject pinkyLeverGimbal;

    public GameObject masterModeGimbal;
    private Vector3 masterModeGimbalPosition;

    public GameObject pickleGimbal;
    private Vector3 pickleGimbalPosition;

    public GameObject pinkyButtonGimbal;
    private Vector3 pinkyButtonGimbalPosition;

    public GameObject trimGimbal;
    private Vector3 trimGimbalOrigins;

    public GameObject cmsGimbal;
    private Vector3 cmsGimbalOrigins;
    private Vector3 cmsGimbalPosition;

    public GameObject tmsGimbal;
    private Vector3 tmsGimbalOrigins;

    public GameObject dmsGimbal;
    private Vector3 dmsGimbalOrigins;

    public GameObject leftThrottle;
    public GameObject rightThrottle;
    public GameObject frictionSlider;

    public GameObject speedbrakeGimbal;
    private Vector3 speedbrakeGimbalPosition;

    public GameObject boatSwitchGimbal;
    private Vector3 boatSwitchGimbalOrigins;

    public GameObject chinaHatGimbal;
    private Vector3 chinaHatGimbalOrigins;

    public GameObject flapsGimbal;
    private Vector3 flapsGimbalOrigins;

    public GameObject micSwitchGimbal;
    private Vector3 micSwitchGimbalOrigins;
    private Vector3 micSwitchGimbalPosition;

    private TcpClient client;
    private NetworkStream stream;

    private WarthogJoystick warthogJoystick;
    private WarthogThrottle warthogThrottle;

    // Use this for initialization
    void Start () {
        warthogJoystick = new WarthogJoystick();
        warthogThrottle = new WarthogThrottle();

        masterModeGimbalPosition = masterModeGimbal.transform.localPosition;
        pickleGimbalPosition = pickleGimbal.transform.localPosition;
        pinkyButtonGimbalPosition = pinkyButtonGimbal.transform.localPosition;
        trimGimbalOrigins = trimGimbal.transform.localEulerAngles;
        cmsGimbalOrigins = cmsGimbal.transform.localEulerAngles;
        cmsGimbalPosition = cmsGimbal.transform.localPosition;
        tmsGimbalOrigins = tmsGimbal.transform.localEulerAngles;
        dmsGimbalOrigins = dmsGimbal.transform.localEulerAngles;

        micSwitchGimbalOrigins = micSwitchGimbal.transform.localEulerAngles;
        micSwitchGimbalPosition = micSwitchGimbal.transform.localPosition;
        speedbrakeGimbalPosition = speedbrakeGimbal.transform.localPosition;
        boatSwitchGimbalOrigins = boatSwitchGimbal.transform.localEulerAngles;
        chinaHatGimbalOrigins = chinaHatGimbal.transform.localEulerAngles;
        flapsGimbalOrigins = flapsGimbal.transform.localEulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        if (stream != null && stream.CanRead && stream.DataAvailable)
        {
            try
            {
                Byte[] data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                connectionError.SetActive(false);
                lastMessage = DateTime.Now;
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                foreach (string msg in responseData.Split('\n'))
                {
                    string[] package = msg.Split(',');

                    if(package.Length > 0)
                    {
                        switch(package[0])
                        {
                            case "Joystick":
                                UpdateJoystick(msg);
                                break;
                            case "Throttle":
                                UpdateThrottle(msg);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
        }
        if((DateTime.Now - lastMessage).TotalSeconds > 2)
        {
            // Messages should come every second, no message means we disconnect and try again.

            if(stream != null && stream.CanRead)
                stream.Close();

            if(client != null && client.Connected)
                client.Close();

            connectionError.SetActive(true);
            try
            {
                client = new TcpClient(host, port);
                stream = client.GetStream();
                connectionError.SetActive(false);
            }
            catch (Exception)
            {
            }
        }
    }

    void UpdateJoystick(string message)
    {
        warthogJoystick.FromString(message);
        joystickGimbal.transform.eulerAngles = new Vector3(-20 * warthogJoystick.Y, 0, -20 * warthogJoystick.X);

        if(warthogJoystick.Trigger2 == 1)
            triggerGimbal.transform.localEulerAngles = new Vector3(TRIGGER2_PRESS, 0, 0);
        else if (warthogJoystick.Trigger1 == 1)
            triggerGimbal.transform.localEulerAngles = new Vector3(TRIGGER1_PRESS, 0, 0);
        else
            triggerGimbal.transform.localEulerAngles = new Vector3(0, 0, 0);

        pinkyLeverGimbal.transform.localEulerAngles = new Vector3(warthogJoystick.PinkyLever * -PINKY_LEVER_PRESS, 0, 0);

        masterModeGimbal.transform.localPosition = masterModeGimbalPosition;
        masterModeGimbal.transform.Translate(new Vector3(0, 0, warthogJoystick.MasterMode * BUTTON_PRESS), Space.Self);

        pickleGimbal.transform.localPosition = pickleGimbalPosition;
        pickleGimbal.transform.Translate(new Vector3(0, 0, warthogJoystick.Pickle * BUTTON_PRESS), Space.Self);

        pinkyButtonGimbal.transform.localPosition = pinkyButtonGimbalPosition;
        pinkyButtonGimbal.transform.Translate(new Vector3(0, 0, warthogJoystick.PinkySwitch * BUTTON_PRESS), Space.Self);

        trimGimbal.transform.localEulerAngles = trimGimbalOrigins;
        trimGimbal.transform.Rotate(new Vector3(warthogJoystick.Trim.X * HAT_ANGLE, warthogJoystick.Trim.Y * -HAT_ANGLE, 0), Space.Self);

        cmsGimbal.transform.localEulerAngles = cmsGimbalOrigins;
        cmsGimbal.transform.localPosition = cmsGimbalPosition;
        cmsGimbal.transform.Translate(new Vector3(0, 0, warthogJoystick.CMS_Push * BUTTON_PRESS), Space.Self);
        cmsGimbal.transform.Rotate(new Vector3(warthogJoystick.CMS.X * HAT_ANGLE, warthogJoystick.CMS.Y * -HAT_ANGLE, 0), Space.Self);

        tmsGimbal.transform.localEulerAngles = tmsGimbalOrigins;
        tmsGimbal.transform.Rotate(new Vector3(warthogJoystick.TMS.X * HAT_ANGLE, warthogJoystick.TMS.Y * -HAT_ANGLE, 0), Space.Self);

        dmsGimbal.transform.localEulerAngles = dmsGimbalOrigins;
        dmsGimbal.transform.Rotate(new Vector3(warthogJoystick.DMS.X * HAT_ANGLE, warthogJoystick.DMS.Y * -HAT_ANGLE, 0), Space.Self);
    }

    void UpdateThrottle(string message)
    {
        warthogThrottle.FromString(message);
        leftThrottle.transform.eulerAngles = new Vector3(-30 * warthogThrottle.LeftThrottle, 0, 0);
        rightThrottle.transform.eulerAngles = new Vector3(-30 * warthogThrottle.RightThrottle, 0, 0);
        frictionSlider.transform.eulerAngles = new Vector3(-30 * warthogThrottle.Friction, 0, 0);

        micSwitchGimbal.transform.localEulerAngles = micSwitchGimbalOrigins;
        micSwitchGimbal.transform.localPosition = micSwitchGimbalPosition;
        micSwitchGimbal.transform.Translate(new Vector3(0, 0, warthogThrottle.MicSwitchPush * BUTTON_PRESS), Space.Self);
        micSwitchGimbal.transform.Rotate(new Vector3(warthogThrottle.MicSwitch.X * HAT_ANGLE, warthogThrottle.MicSwitch.Y * -HAT_ANGLE, 0), Space.Self);

        speedbrakeGimbal.transform.localPosition = speedbrakeGimbalPosition;
        speedbrakeGimbal.transform.Translate(new Vector3(0, 0, warthogThrottle.SpeedBreak * SPEEDBRAKE_DISTANCE), Space.Self);

        boatSwitchGimbal.transform.localEulerAngles = boatSwitchGimbalOrigins;
        boatSwitchGimbal.transform.Rotate(new Vector3(0, warthogThrottle.BoatSwitch * -FLIP_ANGLE, 0), Space.Self);

        chinaHatGimbal.transform.localEulerAngles = chinaHatGimbalOrigins;
        chinaHatGimbal.transform.Rotate(new Vector3(0, warthogThrottle.ChinaHat * -FLIP_ANGLE, 0), Space.Self);

        flapsGimbal.transform.localEulerAngles = flapsGimbalOrigins;
        flapsGimbal.transform.Rotate(new Vector3(warthogThrottle.Flaps * FLIP_ANGLE, 0, 0), Space.Self);
    }

    void OnApplicationQuit()
    {
        // Close everything.
        stream.Close();
        client.Close();
    }
}

/// <summary>
/// Pasted and modified from Proxy project
/// </summary>
namespace JoystickProxy
{
    abstract class Warthog
    {
        public const string FLOAT_PRECISION = "0.0000";

        public static float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public int GetButtonValue(int value)
        {
            return (value > 0) ? 1 : 0;
        }

        public byte[] GetBytes()
        {
            return System.Text.Encoding.ASCII.GetBytes(this.ToString() + '\n');
        }
    }

    class FourWayHatSwitch
    {
        public int Up = 0;
        public int Down = 0;
        public int Left = 0;
        public int Right = 0;

        public int X
        {
            get { return Up + (Down * -1); }
        }

        public int Y
        {
            get { return Right + (Left * -1); }
        }

        public override string ToString()
        {
            String state = "";
            if (Up == 1)
                state += "U";
            if (Down == 1)
                state += "D";
            if (Left == 1)
                state += "L";
            if (Right == 1)
                state += "R";
            return state;
        }

        public void Parse(string state)
        {
            Up = 0;
            Down = 0;
            Left = 0;
            Right = 0;

            if (state.Contains("U"))
                Up = 1;
            if (state.Contains("D"))
                Down = 1;
            if (state.Contains("L"))
                Left = 1;
            if (state.Contains("R"))
                Right = 1;
        }
    }

    class EightWayHatSwitch : FourWayHatSwitch
    {
        public void Update(float value)
        {
            Up = 0;
            Down = 0;
            Left = 0;
            Right = 0;

            switch ((int)value)
            {
                case 0:
                    Up = 1;
                    break;
                case 4500:
                    Up = 1;
                    Right = 1;
                    break;
                case 9000:
                    Right = 1;
                    break;
                case 13500:
                    Right = 1;
                    Down = 1;
                    break;
                case 18000:
                    Down = 1;
                    break;
                case 22500:
                    Down = 1;
                    Left = 1;
                    break;
                case 27000:
                    Left = 1;
                    break;
                case 31500:
                    Left = 1;
                    Up = 1;
                    break;
            }
        }
    }

    class WarthogJoystick : Warthog
    {
        public float X = 0.0f;
        public float Y = 0.0f;
        public int Trigger1 = 0;
        public int Trigger2 = 0;
        public int MasterMode = 0;
        public int Pickle = 0;
        public int PinkySwitch = 0;
        public int PinkyLever = 0;

        public EightWayHatSwitch Trim = new EightWayHatSwitch();
        public FourWayHatSwitch DMS = new FourWayHatSwitch();
        public FourWayHatSwitch TMS = new FourWayHatSwitch();
        public FourWayHatSwitch CMS = new FourWayHatSwitch();
        public int CMS_Push = 0;

        public override string ToString()
        {
            return String.Format("Joystick,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                X.ToString(FLOAT_PRECISION),
                Y.ToString(FLOAT_PRECISION),
                Trigger1.ToString(),
                Trigger2.ToString(),
                MasterMode.ToString(),
                Pickle.ToString(),
                PinkySwitch.ToString(),
                PinkyLever.ToString(),
                Trim.ToString(),
                DMS.ToString(),
                TMS.ToString(),
                CMS.ToString(),
                CMS_Push.ToString());
        }

        public void FromString(string state)
        {
            string[] values = state.Split(',');
            if (values.Length != 14)
                throw new Exception("Invalid Joystick state length, should be " + 14 + " but was " + values.Length);
            if (values[0] != "Joystick")
                throw new Exception("Invalid state: " + values[0]);

            X = float.Parse(values[1]);
            Y = float.Parse(values[2]);
            Trigger1 = int.Parse(values[3]);
            Trigger2 = int.Parse(values[4]);
            MasterMode = int.Parse(values[5]);
            Pickle = int.Parse(values[6]);
            PinkySwitch = int.Parse(values[7]);
            PinkyLever = int.Parse(values[8]);
            Trim.Parse(values[9]);
            DMS.Parse(values[10]);
            TMS.Parse(values[11]);
            CMS.Parse(values[12]);
            CMS_Push = int.Parse(values[13]);
        }
    }

    class WarthogThrottle : Warthog
    {
        public float LeftThrottle = 0.0f;
        public float RightThrottle = 0.0f;
        public float Friction = 0.0f;
        public float SlewX = 0.0f;
        public float SlewY = 0.0f;
        public int SlewPush = 0;
        public EightWayHatSwitch CoolieSwitch = new EightWayHatSwitch();
        public FourWayHatSwitch MicSwitch = new FourWayHatSwitch();
        public int MicSwitchPush = 0;
        public int LeftThrottleButton = 0;
        public int PinkySwitch = 0;
        public int SpeedBreak = 0;
        public int BoatSwitch = 0;
        public int ChinaHat = 0;
        public int EAC = 0;
        public int RDR_ALT = 0;
        public int AutopilotEngageDisengage = 0;
        public int AutopilotSelect = 0;
        public int LandingGearHornSilence = 0;
        public int RightThrottleOff = 0;
        public int LeftThrottleOff = 0;
        public int APU = 0;
        public int EngineOperateLeft = 0;
        public int EngineOperateRight = 0;
        public int EngineFuelFlowLeft = 0;
        public int EngineFuelFlowRight = 0;
        public int Flaps = 0;

        public override string ToString()
        {
            return String.Format("Throttle,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26}",
                LeftThrottle.ToString(FLOAT_PRECISION),
                RightThrottle.ToString(FLOAT_PRECISION),
                Friction.ToString(FLOAT_PRECISION),
                SlewX.ToString(FLOAT_PRECISION),
                SlewY.ToString(FLOAT_PRECISION),
                SlewPush.ToString(),
                CoolieSwitch.ToString(),
                MicSwitch.ToString(),
                MicSwitchPush.ToString(),
                LeftThrottleButton.ToString(),
                PinkySwitch.ToString(),
                SpeedBreak.ToString(),
                BoatSwitch.ToString(),
                ChinaHat.ToString(),
                EAC.ToString(),
                RDR_ALT.ToString(),
                AutopilotEngageDisengage.ToString(),
                AutopilotSelect.ToString(),
                LandingGearHornSilence.ToString(),
                RightThrottleOff.ToString(),
                LeftThrottleOff.ToString(),
                APU.ToString(),
                EngineOperateLeft.ToString(),
                EngineOperateRight.ToString(),
                EngineFuelFlowLeft.ToString(),
                EngineFuelFlowRight.ToString(),
                Flaps.ToString());
        }

        public void FromString(string state)
        {
            string[] values = state.Split(',');
            if (values.Length != 28)
                throw new Exception("Invalid Joystick state length, should be 28 but was " + values.Length);
            if (values[0] != "Throttle")
                throw new Exception("Invalid state: " + values[0]);

            LeftThrottle = float.Parse(values[1]);
            RightThrottle = float.Parse(values[2]);
            Friction = float.Parse(values[3]);
            SlewX = float.Parse(values[4]);
            SlewY = float.Parse(values[5]);
            SlewPush = int.Parse(values[6]);
            CoolieSwitch.Parse(values[7]);
            MicSwitch.Parse(values[8]);
            MicSwitchPush = int.Parse(values[9]);
            LeftThrottleButton = int.Parse(values[10]);
            PinkySwitch = int.Parse(values[11]);
            SpeedBreak = int.Parse(values[12]);
            BoatSwitch = int.Parse(values[13]);
            ChinaHat = int.Parse(values[14]);
            EAC = int.Parse(values[15]);
            RDR_ALT = int.Parse(values[16]);
            AutopilotEngageDisengage = int.Parse(values[17]);
            AutopilotSelect = int.Parse(values[18]);
            LandingGearHornSilence = int.Parse(values[19]);
            RightThrottleOff = int.Parse(values[20]);
            LeftThrottleOff = int.Parse(values[21]);
            APU = int.Parse(values[22]);
            EngineOperateLeft = int.Parse(values[23]);
            EngineOperateRight = int.Parse(values[24]);
            EngineFuelFlowLeft = int.Parse(values[25]);
            EngineFuelFlowRight = int.Parse(values[26]);
            Flaps = int.Parse(values[27]);
        }
    }
}
