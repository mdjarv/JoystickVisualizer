using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using SharpDX.DirectInput;

namespace Joystick_Proxy
{
    public partial class Form1 : Form
    {
        private static bool _debug = true;

        private DirectInput _directInput = new DirectInput();

        private BindingList<ControllerDevice> _devices;
        private BindingList<ControllerInput> _input;

        private Socket _socket;
        private IPEndPoint _endPoint;

        private static Dictionary<string, string> SupportedDevices = new Dictionary<string, string>();
        private static IPAddress _host;
        private static int _port;

        public Form1()
        {
            LoadConfig();

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _endPoint = new IPEndPoint(_host, _port);
            _devices = new BindingList<ControllerDevice>();
            _input = new BindingList<ControllerInput>();

            InitializeComponent();

            controllerDeviceBindingSource.DataSource = _devices;
            inputBindingSource.DataSource = _input;

            ScanJoysticks();
        }

        private static void LoadConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            _host = IPAddress.Parse(data["Config"]["Host"]);
            _port = Int32.Parse(data["Config"]["Port"]);
            //_frameTime = 1000 / Int32.Parse(data["Config"]["FPS"]);

            foreach (KeyData supportedDevice in data["Devices"])
            {
                if (supportedDevice.KeyName.StartsWith("#"))
                {
                    continue;
                }

                SupportedDevices.Add(supportedDevice.KeyName, supportedDevice.Value);
                Debug(" * " + supportedDevice.Value);
            }
        }

        private void ScanJoysticks()
        {
            List<ControllerDevice> foundDevices = _directInput.GetDevices().ToList().ConvertAll(device => new ControllerDevice(_directInput,  device));

            if(ShowAllDevicesCheckBox.Checked == false)
            {
                foundDevices = foundDevices.Where(d => SupportedDevices.ContainsKey(d.UsbId)).ToList();
            }

            var removedDevices = _devices.Except(foundDevices).ToList();
            var addedDevices = foundDevices.Except(_devices).ToList();

            foreach(ControllerDevice device in removedDevices)
            {
                device.Unacquire();
                _devices.Remove(device);
                SendEvent(device, "Connected=0");
            }

            foreach (ControllerDevice device in addedDevices)
            {
                if (SupportedDevices.ContainsKey(device.UsbId))
                {
                    device.OnStateUpdated += Device_OnStateUpdated;
                    device.Supported = true;
                    device.Enabled = true;
                }

                device.Acquire();
                _devices.Add(device);
            }
        }

        private void Device_OnStateUpdated(object sender, DeviceStateUpdateEventArgs e)
        {
            Debug("State updated for " + e.Device.Name + " with " + e.UpdatedStates.Count + " events");
            SendEvents(e.Device, e.UpdatedStates.Select(ev => ev.ToString()).ToList());
        }

        private void SendEvents(ControllerDevice device, List<string> events)
        {
            SendEvent(device, String.Join(",", events));
        }

        private void SendEvent(ControllerDevice device, string e)
        {
            if (_socket == null || _endPoint == null || !SupportedDevices.ContainsKey(device.UsbId))
                return;

            string outgoingString = String.Format("{0},{1},{2}", device.UsbId, SupportedDevices[device.UsbId], e);
            byte[] send_buffer = Encoding.ASCII.GetBytes(outgoingString);
            _socket.SendTo(send_buffer, _endPoint);

            Debug(outgoingString);
        }

        private static void Debug(string outgoingString)
        {
            if (_debug)
            {
                Console.WriteLine(outgoingString);
            }
        }

        private void refreshDevicesTimer_Tick(object sender, System.EventArgs e)
        {
            ControllerDevice selectedItem = null;
            int selectedCell = 0;

            if (devicesDataGridView.SelectedCells.Count > 0)
            {
                selectedItem = (ControllerDevice)devicesDataGridView.SelectedCells[0].OwningRow.DataBoundItem;
                selectedCell = devicesDataGridView.SelectedCells[0].ColumnIndex;
            }

            ScanJoysticks();

            foreach (DataGridViewRow row in devicesDataGridView.Rows)
            {
                ControllerDevice rowObject = (ControllerDevice)row.DataBoundItem;

                if (selectedItem != null && rowObject == selectedItem)
                {
                    devicesDataGridView.ClearSelection();
                    row.Cells[selectedCell].Selected = true;
                    break;
                }
            }
        }

        private void DevicesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            readInputTimer.Enabled = devicesDataGridView.CurrentRow != null;
        }

        private void ReadInputTimer_Tick(object sender, EventArgs e)
        {
            foreach(ControllerDevice device in _devices)
            {
                try { device.Update(); } catch(Exception ex) {
                    Debug("Failure when running device Update()");
                    Debug(ex.Message);
                }
            }

            ControllerDevice selectedDevice = (ControllerDevice)devicesDataGridView.CurrentRow.DataBoundItem;

            _input.Clear();
            foreach (JoystickUpdate inputState in selectedDevice.CurrentState.Values)
            {
                _input.Add(new ControllerInput(inputState));
            }
        }

        private void devicesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in devicesDataGridView.Rows)
            {
                ControllerDevice cd = (ControllerDevice)row.DataBoundItem;
                if(!SupportedDevices.ContainsKey(cd.UsbId))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    //row.Cells[0].ReadOnly = true;
                }
            }
        }

        private void devicesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                devicesDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                this.devicesDataGridView.Rows[e.RowIndex].Cells[0].Value = ((bool)this.devicesDataGridView.CurrentCell.Value == true);
            }
        }

        private void TipJar_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://paypal.me/mdjarv");
        }

        private void ShowAllDevicesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refreshDevicesTimer_Tick(sender, e);
        }
    }
}
