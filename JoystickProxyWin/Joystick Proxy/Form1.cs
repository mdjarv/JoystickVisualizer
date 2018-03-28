using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace Joystick_Proxy
{
    public partial class Form1 : Form
    {
        private DirectInput directInput = new DirectInput();
        private BindingList<ControllerDevice> _devices;

        public Form1()
        {
            InitializeComponent();
            _devices = new BindingList<ControllerDevice>();
            controllerDeviceBindingSource.DataSource = _devices;

            UpdateDevices();
        }

        private void UpdateDevices()
        {
            _devices.Clear();
            foreach (DeviceInstance device in directInput.GetDevices())
            {
                ControllerDevice cd = new ControllerDevice(device);
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
    }
}
