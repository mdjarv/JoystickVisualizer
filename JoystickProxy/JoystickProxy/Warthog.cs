using SharpDX.DirectInput;
using System;

namespace JoystickProxy
{
    abstract class Warthog
    {
        public const string FLOAT_PRECISION = "0.0000";

        public abstract void UpdateState(JoystickOffset offset, int value);

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

            Console.WriteLine("Parsed \"{0}\" into \"{1}\"", state, this.ToString());
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

        public override void UpdateState(JoystickOffset offset, int value)
        {
            switch (offset.ToString())
            {
                case "X":
                    X = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "Y":
                    Y = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "Buttons0":
                    Trigger1 = GetButtonValue(value);
                    break;
                case "Buttons5":
                    Trigger2 = GetButtonValue(value);
                    break;
                case "Buttons4":
                    MasterMode = GetButtonValue(value);
                    break;
                case "Buttons1":
                    Pickle = GetButtonValue(value);
                    break;
                case "Buttons2":
                    PinkySwitch = GetButtonValue(value);
                    break;
                case "Buttons3":
                    PinkyLever = GetButtonValue(value);
                    break;
                case "PointOfViewControllers0":
                    Trim.Update(value);
                    break;
                case "Buttons6":
                    TMS.Up = GetButtonValue(value);
                    break;
                case "Buttons8":
                    TMS.Down = GetButtonValue(value);
                    break;
                case "Buttons9":
                    TMS.Left = GetButtonValue(value);
                    break;
                case "Buttons7":
                    TMS.Right = GetButtonValue(value);
                    break;
                case "Buttons10":
                    DMS.Up = GetButtonValue(value);
                    break;
                case "Buttons12":
                    DMS.Down = GetButtonValue(value);
                    break;
                case "Buttons13":
                    DMS.Left = GetButtonValue(value);
                    break;
                case "Buttons11":
                    DMS.Right = GetButtonValue(value);
                    break;
                case "Buttons14":
                    CMS.Up = GetButtonValue(value);
                    break;
                case "Buttons16":
                    CMS.Down = GetButtonValue(value);
                    break;
                case "Buttons17":
                    CMS.Left = GetButtonValue(value);
                    break;
                case "Buttons15":
                    CMS.Right = GetButtonValue(value);
                    break;
                case "Buttons18":
                    CMS_Push = GetButtonValue(value);
                    break;
                default:
                    Console.WriteLine("Unknown Joystick state: " + offset.ToString() + " value: " + value);
                    break;
            }
        }

        public override string ToString()
        {
            return String.Format("Joystick|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}",
                X.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
                Y.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
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
            string[] values = state.Split('|');
            if (values.Length != 14)
                throw new Exception("Invalid Joystick state length, should be 14 but was " + values.Length);
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

        public override void UpdateState(JoystickOffset offset, int value)
        {
            switch (offset.ToString())
            {
                case "RotationZ":
                    LeftThrottle = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "Z":
                    RightThrottle = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "Sliders0":
                    Friction = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "X":
                    SlewX = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "Y":
                    SlewY = Remap(value, 0, 65535, -1.0f, 1.0f);
                    break;
                case "PointOfViewControllers0":
                    CoolieSwitch.Update(value);
                    break;
                case "Buttons0":
                    SlewPush = GetButtonValue(value);
                    break;
                case "Buttons1":
                    MicSwitchPush = GetButtonValue(value);
                    break;
                case "Buttons2":
                    MicSwitch.Up = GetButtonValue(value);
                    break;
                case "Buttons3":
                    MicSwitch.Right = GetButtonValue(value);
                    break;
                case "Buttons4":
                    MicSwitch.Down = GetButtonValue(value);
                    break;
                case "Buttons5":
                    MicSwitch.Left = GetButtonValue(value);
                    break;
                case "Buttons6":
                    SpeedBreak = GetButtonValue(value);
                    break;
                case "Buttons7":
                    SpeedBreak = -GetButtonValue(value);
                    break;
                case "Buttons8":
                    BoatSwitch = GetButtonValue(value);
                    break;
                case "Buttons9":
                    BoatSwitch = -GetButtonValue(value);
                    break;
                case "Buttons10":
                    ChinaHat = GetButtonValue(value);
                    break;
                case "Buttons11":
                    ChinaHat = -GetButtonValue(value);
                    break;
                case "Buttons12":
                    PinkySwitch = GetButtonValue(value);
                    break;
                case "Buttons13":
                    PinkySwitch = -GetButtonValue(value);
                    break;
                case "Buttons14":
                    LeftThrottleButton = GetButtonValue(value);
                    break;
                case "Buttons15":
                    EngineFuelFlowLeft = GetButtonValue(value);
                    break;
                case "Buttons16":
                    EngineFuelFlowRight = GetButtonValue(value);
                    break;
                case "Buttons19":
                    APU = GetButtonValue(value);
                    break;
                case "Buttons20":
                    LandingGearHornSilence = GetButtonValue(value);
                    break;
                case "Buttons23":
                    EAC = GetButtonValue(value);
                    break;
                case "Buttons24":
                    RDR_ALT = GetButtonValue(value);
                    break;
                case "Buttons25":
                    AutopilotEngageDisengage = GetButtonValue(value);
                    break;
                case "Buttons26":
                    AutopilotSelect = GetButtonValue(value);
                    break;
                case "Buttons27":
                    AutopilotSelect = -GetButtonValue(value);
                    break;
                case "Buttons28":
                    RightThrottleOff = GetButtonValue(value);
                    break;
                case "Buttons29":
                    LeftThrottleOff = GetButtonValue(value);
                    break;
                case "Buttons30":
                    EngineOperateLeft = GetButtonValue(value);
                    break;
                case "Buttons17":
                    EngineOperateLeft = -GetButtonValue(value);
                    break;
                case "Buttons31":
                    EngineOperateRight = GetButtonValue(value);
                    break;
                case "Buttons18":
                    EngineOperateRight = -GetButtonValue(value);
                    break;
                case "Buttons21":
                    Flaps = GetButtonValue(value);
                    break;
                case "Buttons22":
                    Flaps = -GetButtonValue(value);
                    break;
                default:
                    Console.WriteLine("Unknown Throttle state: " + offset.ToString());
                    break;
            }
        }

        public override string ToString()
        {
            return String.Format("Throttle|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}",
                LeftThrottle.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
                RightThrottle.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
                Friction.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
                SlewX.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
                SlewY.ToString(FLOAT_PRECISION, System.Globalization.CultureInfo.InvariantCulture),
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
            string[] values = state.Split('|');
            if (values.Length != 28)
                throw new Exception("Invalid Throttle state length, should be 28 but was " + values.Length);
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
