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
            this.devicesDataGridView = new System.Windows.Forms.DataGridView();
            this.refreshDevicesTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.readInputTimer = new System.Windows.Forms.Timer(this.components);
            this.TipJarImage = new System.Windows.Forms.PictureBox();
            this.ShowAllDevicesCheckBox = new System.Windows.Forms.CheckBox();
            this.controllerDeviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deviceEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSBIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.devicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipJarImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerDeviceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // devicesDataGridView
            // 
            this.devicesDataGridView.AllowUserToAddRows = false;
            this.devicesDataGridView.AllowUserToDeleteRows = false;
            this.devicesDataGridView.AllowUserToResizeRows = false;
            this.devicesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesDataGridView.AutoGenerateColumns = false;
            this.devicesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.devicesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.devicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceEnabled,
            this.nameDataGridViewTextBoxColumn,
            this.uSBIDDataGridViewTextBoxColumn});
            this.devicesDataGridView.DataSource = this.controllerDeviceBindingSource;
            this.devicesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.devicesDataGridView.MultiSelect = false;
            this.devicesDataGridView.Name = "devicesDataGridView";
            this.devicesDataGridView.RowHeadersVisible = false;
            this.devicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.devicesDataGridView.Size = new System.Drawing.Size(559, 359);
            this.devicesDataGridView.TabIndex = 0;
            this.devicesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.devicesDataGridView_CellContentClick);
            this.devicesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.devicesDataGridView_CellFormatting);
            this.devicesDataGridView.SelectionChanged += new System.EventHandler(this.DevicesDataGridView_SelectionChanged);
            // 
            // refreshDevicesTimer
            // 
            this.refreshDevicesTimer.Enabled = true;
            this.refreshDevicesTimer.Interval = 2000;
            this.refreshDevicesTimer.Tick += new System.EventHandler(this.refreshDevicesTimer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InputName,
            this.InputValue});
            this.dataGridView1.DataSource = this.inputBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(577, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(302, 359);
            this.dataGridView1.TabIndex = 2;
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
            // readInputTimer
            // 
            this.readInputTimer.Interval = 12;
            this.readInputTimer.Tick += new System.EventHandler(this.ReadInputTimer_Tick);
            // 
            // TipJarImage
            // 
            this.TipJarImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TipJarImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TipJarImage.Image = global::Joystick_Proxy.Properties.Resources.tipjar;
            this.TipJarImage.Location = new System.Drawing.Point(787, 377);
            this.TipJarImage.Name = "TipJarImage";
            this.TipJarImage.Size = new System.Drawing.Size(92, 20);
            this.TipJarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TipJarImage.TabIndex = 3;
            this.TipJarImage.TabStop = false;
            this.TipJarImage.Click += new System.EventHandler(this.TipJar_Click);
            // 
            // ShowAllDevicesCheckBox
            // 
            this.ShowAllDevicesCheckBox.AutoSize = true;
            this.ShowAllDevicesCheckBox.Location = new System.Drawing.Point(13, 380);
            this.ShowAllDevicesCheckBox.Name = "ShowAllDevicesCheckBox";
            this.ShowAllDevicesCheckBox.Size = new System.Drawing.Size(106, 17);
            this.ShowAllDevicesCheckBox.TabIndex = 4;
            this.ShowAllDevicesCheckBox.Text = "Show all devices";
            this.ShowAllDevicesCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllDevicesCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllDevicesCheckBox_CheckedChanged);
            // 
            // controllerDeviceBindingSource
            // 
            this.controllerDeviceBindingSource.DataSource = typeof(Joystick_Proxy.ControllerDevice);
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
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(891, 409);
            this.Controls.Add(this.ShowAllDevicesCheckBox);
            this.Controls.Add(this.TipJarImage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.devicesDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Joystick Proxy";
            ((System.ComponentModel.ISupportInitialize)(this.devicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipJarImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerDeviceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView devicesDataGridView;
        private System.Windows.Forms.Timer refreshDevicesTimer;
        private System.Windows.Forms.BindingSource controllerDeviceBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource inputBindingSource;
        private System.Windows.Forms.Timer readInputTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputValue;
        private System.Windows.Forms.PictureBox TipJarImage;
        private System.Windows.Forms.CheckBox ShowAllDevicesCheckBox;
        private System.Windows.Forms.DataGridViewCheckBoxColumn deviceEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSBIDDataGridViewTextBoxColumn;
    }
}

