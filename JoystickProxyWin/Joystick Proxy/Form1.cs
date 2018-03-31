using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace Joystick_Proxy
{
    public partial class Form1 : Form
    {
        private DirectInput directInput = new DirectInput();
        private BindingList<ControllerDevice> _devices;
        private BindingList<ControllerInput> _input;
        private List<string> supportedDevices = new List<string>();

        public Form1()
        {
            supportedDevices.Add("044f:0402");
            supportedDevices.Add("044f:0404");

            InitializeComponent();
            _devices = new BindingList<ControllerDevice>();
            controllerDeviceBindingSource.DataSource = _devices;

            _input = new BindingList<ControllerInput>();
            inputBindingSource.DataSource = _input;

            UpdateDevices();
        }

        private void UpdateDevices()
        {
            _devices.Clear();
            foreach (DeviceInstance device in directInput.GetDevices())
            {
                ControllerDevice cd = new ControllerDevice(directInput, device);
                _devices.Add(cd);
            }

            
        }

        private void refreshDevicesTimer_Tick(object sender, System.EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = devicesDataGridView.SelectedRows;
            UpdateDevices();
            devicesDataGridView.ClearSelection();
            
            foreach (DataGridViewRow row in devicesDataGridView.Rows)
            {
                
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateDevices();
        }

        private void devicesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            readInputTimer.Enabled = devicesDataGridView.CurrentRow != null;
        }

        private void PollDevice(ControllerDevice controller)
        {
            SortedDictionary<string, JoystickUpdate> inputStates = controller.Update();
            _input.Clear();
            foreach(JoystickUpdate inputState in inputStates.Values)
            {
                _input.Add(new ControllerInput(inputState));
            }
            
        }

        private void readInputTimer_Tick(object sender, EventArgs e)
        {
            PollDevice((ControllerDevice)devicesDataGridView.CurrentRow.DataBoundItem);
        }

        private void devicesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in devicesDataGridView.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                ControllerDevice cd = (ControllerDevice)row.DataBoundItem;

                if(!supportedDevices.Contains(cd.UsbId))
                    row.DefaultCellStyle.BackColor = Color.LightGray;
            }
        }
    }
}
