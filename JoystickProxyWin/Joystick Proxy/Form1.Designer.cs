namespace Joystick_Proxy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DevicesDataGridView = new System.Windows.Forms.DataGridView();
            this.RefreshDevicesTimer = new System.Windows.Forms.Timer(this.components);
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.InputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReadInputTimer = new System.Windows.Forms.Timer(this.components);
            this.ShowAllDevicesCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.LogToFileCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PollingRateInput = new System.Windows.Forms.NumericUpDown();
            this.VisualizerHostTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PortInput = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ControllerDeviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PollingRateInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerDeviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DevicesDataGridView
            // 
            this.DevicesDataGridView.AllowUserToAddRows = false;
            this.DevicesDataGridView.AllowUserToDeleteRows = false;
            this.DevicesDataGridView.AllowUserToResizeRows = false;
            this.DevicesDataGridView.AutoGenerateColumns = false;
            this.DevicesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DevicesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DevicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewCheckBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DevicesDataGridView.DataSource = this.ControllerDeviceBindingSource;
            this.DevicesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.DevicesDataGridView.MultiSelect = false;
            this.DevicesDataGridView.Name = "DevicesDataGridView";
            this.DevicesDataGridView.RowHeadersVisible = false;
            this.DevicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DevicesDataGridView.Size = new System.Drawing.Size(694, 372);
            this.DevicesDataGridView.TabIndex = 0;
            this.DevicesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevicesDataGridView_CellContentClick);
            this.DevicesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DevicesDataGridView_CellFormatting);
            this.DevicesDataGridView.SelectionChanged += new System.EventHandler(this.DevicesDataGridView_SelectionChanged);
            // 
            // RefreshDevicesTimer
            // 
            this.RefreshDevicesTimer.Enabled = true;
            this.RefreshDevicesTimer.Interval = 2000;
            this.RefreshDevicesTimer.Tick += new System.EventHandler(this.RefreshDevicesTimer_Tick);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AutoGenerateColumns = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InputName,
            this.InputValue});
            this.DataGridView1.DataSource = this.InputBindingSource;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.Size = new System.Drawing.Size(370, 372);
            this.DataGridView1.TabIndex = 2;
            // 
            // InputName
            // 
            this.InputName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InputName.DataPropertyName = "Name";
            this.InputName.FillWeight = 50F;
            this.InputName.HeaderText = "Input";
            this.InputName.Name = "InputName";
            // 
            // InputValue
            // 
            this.InputValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InputValue.DataPropertyName = "Value";
            this.InputValue.FillWeight = 50F;
            this.InputValue.HeaderText = "Value";
            this.InputValue.Name = "InputValue";
            // 
            // ReadInputTimer
            // 
            this.ReadInputTimer.Interval = global::Joystick_Proxy.Properties.Settings.Default.PollingRate;
            this.ReadInputTimer.Tick += new System.EventHandler(this.ReadInputTimer_Tick);
            // 
            // ShowAllDevicesCheckBox
            // 
            this.ShowAllDevicesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowAllDevicesCheckBox.AutoSize = true;
            this.ShowAllDevicesCheckBox.Location = new System.Drawing.Point(13, 403);
            this.ShowAllDevicesCheckBox.Name = "ShowAllDevicesCheckBox";
            this.ShowAllDevicesCheckBox.Size = new System.Drawing.Size(106, 17);
            this.ShowAllDevicesCheckBox.TabIndex = 4;
            this.ShowAllDevicesCheckBox.Text = "Show all devices";
            this.ShowAllDevicesCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllDevicesCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllDevicesCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(743, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Visualizer Host:";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "log";
            // 
            // LogToFileCheckbox
            // 
            this.LogToFileCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogToFileCheckbox.AutoSize = true;
            this.LogToFileCheckbox.Location = new System.Drawing.Point(125, 403);
            this.LogToFileCheckbox.Name = "LogToFileCheckbox";
            this.LogToFileCheckbox.Size = new System.Drawing.Size(72, 17);
            this.LogToFileCheckbox.TabIndex = 7;
            this.LogToFileCheckbox.Text = "Log to file";
            this.LogToFileCheckbox.UseVisualStyleBackColor = true;
            this.LogToFileCheckbox.Click += new System.EventHandler(this.LogToFileCheckbox_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(589, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Polling Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PollingRateInput
            // 
            this.PollingRateInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PollingRateInput.Location = new System.Drawing.Point(662, 398);
            this.PollingRateInput.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PollingRateInput.Name = "PollingRateInput";
            this.PollingRateInput.Size = new System.Drawing.Size(62, 20);
            this.PollingRateInput.TabIndex = 9;
            this.PollingRateInput.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this.PollingRateInput.ValueChanged += new System.EventHandler(this.PollingRateInput_ValueChanged);
            this.PollingRateInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PollingRateInput_KeyDown);
            this.PollingRateInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PollingRateInput_KeyPress);
            // 
            // VisualizerHostTextBox
            // 
            this.VisualizerHostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualizerHostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Joystick_Proxy.Properties.Settings.Default, "Host", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VisualizerHostTextBox.Location = new System.Drawing.Point(828, 398);
            this.VisualizerHostTextBox.Name = "VisualizerHostTextBox";
            this.VisualizerHostTextBox.Size = new System.Drawing.Size(124, 20);
            this.VisualizerHostTextBox.TabIndex = 5;
            this.VisualizerHostTextBox.Text = global::Joystick_Proxy.Properties.Settings.Default.Host;
            this.VisualizerHostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VisualizerHostTextBox_KeyPress);
            this.VisualizerHostTextBox.Leave += new System.EventHandler(this.VisualizerHostTextBox_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(965, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port:";
            // 
            // PortInput
            // 
            this.PortInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PortInput.Location = new System.Drawing.Point(1000, 397);
            this.PortInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(74, 20);
            this.PortInput.TabIndex = 11;
            this.PortInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PortInput.ValueChanged += new System.EventHandler(this.PortInput_ValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DevicesDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1068, 372);
            this.splitContainer1.SplitterDistance = 694;
            this.splitContainer1.TabIndex = 12;
            // 
            // ControllerDeviceBindingSource
            // 
            this.ControllerDeviceBindingSource.DataSource = typeof(Joystick_Proxy.ControllerDevice);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Joystick_Proxy.Form1);
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.FillWeight = 6.154823F;
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.ToolTipText = "Enable device input polling";
            this.enabledDataGridViewCheckBoxColumn.Width = 74;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.FillWeight = 43.08376F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 300;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UsbId";
            this.dataGridViewTextBoxColumn2.FillWeight = 50.76142F;
            this.dataGridViewTextBoxColumn2.HeaderText = "USB ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1093, 429);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PollingRateInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogToFileCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VisualizerHostTextBox);
            this.Controls.Add(this.ShowAllDevicesCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 250);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Joystick Proxy";
            ((System.ComponentModel.ISupportInitialize)(this.DevicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PollingRateInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ControllerDeviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DevicesDataGridView;
        private System.Windows.Forms.Timer RefreshDevicesTimer;
        private System.Windows.Forms.BindingSource ControllerDeviceBindingSource;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.BindingSource InputBindingSource;
        private System.Windows.Forms.Timer ReadInputTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputValue;
        private System.Windows.Forms.CheckBox ShowAllDevicesCheckBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeviceEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn USBIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox VisualizerHostTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.CheckBox LogToFileCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PollingRateInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PortInput;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}

