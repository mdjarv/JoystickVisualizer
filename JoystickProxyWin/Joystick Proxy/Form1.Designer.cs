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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DevicesDataGridView = new System.Windows.Forms.DataGridView();
            this.deviceEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSBIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControllerDeviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RefreshDevicesTimer = new System.Windows.Forms.Timer(this.components);
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.InputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReadInputTimer = new System.Windows.Forms.Timer(this.components);
            this.TipJarImage = new System.Windows.Forms.PictureBox();
            this.ShowAllDevicesCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.LogToFileCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PollingRateInput = new System.Windows.Forms.NumericUpDown();
            this.VisualizerHostTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PortInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DevicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerDeviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipJarImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PollingRateInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).BeginInit();
            this.SuspendLayout();
            // 
            // DevicesDataGridView
            // 
            this.DevicesDataGridView.AllowUserToAddRows = false;
            this.DevicesDataGridView.AllowUserToDeleteRows = false;
            this.DevicesDataGridView.AllowUserToResizeRows = false;
            this.DevicesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DevicesDataGridView.AutoGenerateColumns = false;
            this.DevicesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DevicesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DevicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DevicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceEnabled,
            this.nameDataGridViewTextBoxColumn,
            this.uSBIDDataGridViewTextBoxColumn});
            this.DevicesDataGridView.DataSource = this.ControllerDeviceBindingSource;
            this.DevicesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.DevicesDataGridView.MultiSelect = false;
            this.DevicesDataGridView.Name = "DevicesDataGridView";
            this.DevicesDataGridView.RowHeadersVisible = false;
            this.DevicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DevicesDataGridView.Size = new System.Drawing.Size(550, 355);
            this.DevicesDataGridView.TabIndex = 0;
            this.DevicesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevicesDataGridView_CellContentClick);
            this.DevicesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DevicesDataGridView_CellFormatting);
            this.DevicesDataGridView.SelectionChanged += new System.EventHandler(this.DevicesDataGridView_SelectionChanged);
            // 
            // deviceEnabled
            // 
            this.deviceEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceEnabled.DataPropertyName = "Enabled";
            this.deviceEnabled.FalseValue = "false";
            this.deviceEnabled.FillWeight = 10F;
            this.deviceEnabled.HeaderText = "Enabled";
            this.deviceEnabled.IndeterminateValue = "";
            this.deviceEnabled.Name = "deviceEnabled";
            this.deviceEnabled.ToolTipText = "Enable device input polling";
            this.deviceEnabled.TrueValue = "true";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 70F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uSBIDDataGridViewTextBoxColumn
            // 
            this.uSBIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.uSBIDDataGridViewTextBoxColumn.DataPropertyName = "UsbId";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uSBIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.uSBIDDataGridViewTextBoxColumn.FillWeight = 20F;
            this.uSBIDDataGridViewTextBoxColumn.HeaderText = "USB ID";
            this.uSBIDDataGridViewTextBoxColumn.Name = "uSBIDDataGridViewTextBoxColumn";
            this.uSBIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ControllerDeviceBindingSource
            // 
            this.ControllerDeviceBindingSource.DataSource = typeof(Joystick_Proxy.ControllerDevice);
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
            this.DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView1.AutoGenerateColumns = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InputName,
            this.InputValue});
            this.DataGridView1.DataSource = this.InputBindingSource;
            this.DataGridView1.Location = new System.Drawing.Point(568, 12);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.Size = new System.Drawing.Size(302, 355);
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
            // TipJarImage
            // 
            this.TipJarImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TipJarImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TipJarImage.Image = global::Joystick_Proxy.Properties.Resources.tipjar;
            this.TipJarImage.Location = new System.Drawing.Point(778, 377);
            this.TipJarImage.Name = "TipJarImage";
            this.TipJarImage.Size = new System.Drawing.Size(92, 20);
            this.TipJarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TipJarImage.TabIndex = 3;
            this.TipJarImage.TabStop = false;
            this.TipJarImage.Click += new System.EventHandler(this.TipJar_Click);
            // 
            // ShowAllDevicesCheckBox
            // 
            this.ShowAllDevicesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowAllDevicesCheckBox.AutoSize = true;
            this.ShowAllDevicesCheckBox.Location = new System.Drawing.Point(13, 379);
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
            this.label1.Location = new System.Drawing.Point(455, 380);
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
            this.LogToFileCheckbox.Location = new System.Drawing.Point(125, 379);
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
            this.label2.Location = new System.Drawing.Point(323, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Polling Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PollingRateInput
            // 
            this.PollingRateInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PollingRateInput.Location = new System.Drawing.Point(396, 377);
            this.PollingRateInput.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PollingRateInput.Name = "PollingRateInput";
            this.PollingRateInput.Size = new System.Drawing.Size(53, 20);
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
            this.VisualizerHostTextBox.Location = new System.Drawing.Point(540, 377);
            this.VisualizerHostTextBox.Name = "VisualizerHostTextBox";
            this.VisualizerHostTextBox.Size = new System.Drawing.Size(115, 20);
            this.VisualizerHostTextBox.TabIndex = 5;
            this.VisualizerHostTextBox.Text = global::Joystick_Proxy.Properties.Settings.Default.Host;
            this.VisualizerHostTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VisualizerHostTextBox_KeyPress);
            this.VisualizerHostTextBox.Leave += new System.EventHandler(this.VisualizerHostTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(661, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port:";
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(696, 377);
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
            this.PortInput.Size = new System.Drawing.Size(65, 20);
            this.PortInput.TabIndex = 11;
            this.PortInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PortInput.ValueChanged += new System.EventHandler(this.PortInput_ValueChanged);
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(882, 405);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PollingRateInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogToFileCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VisualizerHostTextBox);
            this.Controls.Add(this.ShowAllDevicesCheckBox);
            this.Controls.Add(this.TipJarImage);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.DevicesDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 250);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Joystick Proxy";
            ((System.ComponentModel.ISupportInitialize)(this.DevicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControllerDeviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipJarImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PollingRateInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortInput)).EndInit();
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
        private System.Windows.Forms.PictureBox TipJarImage;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn deviceEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSBIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PortInput;
    }
}

