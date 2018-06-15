﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private static bool _debug = false;

        private DirectInput _directInput = new DirectInput();

        private BindingList<ControllerDevice> _devices;
        private BindingList<ControllerInput> _input;

        private Socket _socket;
        private IPEndPoint _endPoint;

        private StreamWriter logFileStream = null;

        private int pollingRate = 12;

        private static Dictionary<string, string> SupportedDevices = new Dictionary<string, string>();

        public Form1()
        {
            LoadConfig();

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            UpdateEndpoint(Properties.Settings.Default.Host, Properties.Settings.Default.Port);

            _devices = new BindingList<ControllerDevice>();
            _input = new BindingList<ControllerInput>();

            InitializeComponent();

            controllerDeviceBindingSource.DataSource = _devices;
            inputBindingSource.DataSource = _input;

            visualizerHostTextBox.Text = Properties.Settings.Default.Host;

            ScanJoysticks();
        }

        private void UpdateEndpoint(string host, int port)
        {
            IPAddress hostIp = IPAddress.Loopback;
            foreach(IPAddress ip in Dns.GetHostAddresses(host))
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    hostIp = ip;
                    break;
                }
            }

            if(_endPoint == null)
            {
                _endPoint = new IPEndPoint(hostIp, port);
            } else
            {
                _endPoint.Address = hostIp;
                _endPoint.Port = port;
            }
        }

        private void LoadConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("settings.ini");

            foreach (KeyData supportedDevice in data["Devices"])
            {
                if (supportedDevice.KeyName.StartsWith("#"))
                {
                    continue;
                }

                SupportedDevices.Add(supportedDevice.KeyName, supportedDevice.Value);
                Debug(" * " + supportedDevice.Value);
            }

            foreach (KeyData option in data["Options"])
            {
                switch (option.KeyName)
                {
                    case "pollingRate":
                        this.pollingRate = int.Parse(option.Value);
                        break;
                }
                Debug(" * " + option.Value);

            }
        }

        private void ScanJoysticks()
        {
            List<ControllerDevice> removedDevices = new List<ControllerDevice>();
            List<ControllerDevice> addedDevices = new List<ControllerDevice>(); //_directInput.GetDevices().ToList().ConvertAll(device => new ControllerDevice(_directInput, device));

            List<DeviceInstance> oldDeviceInstances = _devices.ToList().ConvertAll(d => d.DeviceInstance);
            List<DeviceInstance> foundDeviceInstances = _directInput.GetDevices().ToList();

            //List<DeviceInstance> removedDeviceInstances = oldDeviceInstances.Except(foundDeviceInstances).Where(d => !IsSupported(d)).ToList();

            foreach(DeviceInstance deviceInstance in foundDeviceInstances)
            {
                if (_devices.Where(d => d.DeviceInstance.InstanceGuid == deviceInstance.InstanceGuid).Count() == 0)
                {
                    if (ShowAllDevicesCheckBox.Checked == true || SupportedDevices.ContainsKey(ControllerDevice.ProductGuidToUSBID(deviceInstance.ProductGuid)))
                        addedDevices.Add(new ControllerDevice(_directInput, deviceInstance));
                }
            }
            
            foreach(ControllerDevice device in _devices)
            {
                bool match = false;
                if (SupportedDevices.ContainsKey(device.UsbId) || ShowAllDevicesCheckBox.Checked)
                {
                    match = foundDeviceInstances.ConvertAll(d => d.InstanceGuid.ToString()).Contains(device.Guid);
                }
                if(!match)
                {
                    // Remove device
                    removedDevices.Add(device);
                }
            }
            
            foreach(ControllerDevice device in removedDevices)
            {
                RemoveDevice(device);
            }

            foreach (ControllerDevice device in addedDevices)
            {
                AddDevice(device);
            }
        }

        private bool IsSupported(DeviceInstance deviceInstance)
        {
            return IsSupported(ControllerDevice.ProductGuidToUSBID(deviceInstance.ProductGuid));
        }

        private bool IsSupported(string usbId)
        {
            return SupportedDevices.ContainsKey(usbId);
        }

        private void AddDevice(ControllerDevice addedDevice)
        {
            if (SupportedDevices.ContainsKey(addedDevice.UsbId))
            {
                addedDevice.OnStateUpdated += Device_OnStateUpdated;
                addedDevice.Supported = true;
                addedDevice.Enabled = true;
            }
            addedDevice.Acquire();
            _devices.Add(addedDevice);
            SendEvent(addedDevice, "Connected=1");
        }

        private void RemoveDevice(ControllerDevice removedDevice)
        {
            removedDevice.Unacquire();
            _devices.Remove(removedDevice);
            SendEvent(removedDevice, "Connected=0");
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
            try
            {
                if (_socket == null || _endPoint == null)
                    return;

                bool supportedDevice = SupportedDevices.ContainsKey(device.UsbId);
                string outgoingString = String.Format("{0},{1},{2}", device.UsbId, device.Name, e);

                if (supportedDevice)
                {
                    byte[] send_buffer = Encoding.ASCII.GetBytes(outgoingString);
                    _socket.SendTo(send_buffer, _endPoint);
                }

                if (logFileStream != null)
                {
                    double timestamp = DateTime.UtcNow.ToUniversalTime()
                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                        .TotalMilliseconds;
                    logFileStream.WriteLine(Math.Round(timestamp) + "," + outgoingString);
                }

                Debug(outgoingString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
                bool enabled = (bool)this.devicesDataGridView.CurrentCell.Value == true;
                this.devicesDataGridView.Rows[e.RowIndex].Cells[0].Value = enabled;

                ControllerDevice selectedDevice = (ControllerDevice)this.devicesDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (enabled)
                    selectedDevice.OnStateUpdated += Device_OnStateUpdated;
                else
                    selectedDevice.OnStateUpdated -= Device_OnStateUpdated;

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

        private void visualizerHostTextBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.Host = visualizerHostTextBox.Text;
            Properties.Settings.Default.Save();
            UpdateEndpoint(visualizerHostTextBox.Text, Properties.Settings.Default.Port);
        }

        private void visualizerHostTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = null;
            }
        }

        private void logToFileCheckbox_Click(object sender, EventArgs e)
        {
            if (logToFileCheckbox.Checked)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != "")
                    {
                        logFileStream = new StreamWriter(saveFileDialog.FileName);
                    }
                }
                else
                {
                    if (logFileStream != null)
                        logFileStream.Close();
                    logToFileCheckbox.Checked = false;
                }
            }
            else
            {
                if (logFileStream != null)
                    logFileStream.Close();

                logFileStream = null;
            }
        }
    }
}
