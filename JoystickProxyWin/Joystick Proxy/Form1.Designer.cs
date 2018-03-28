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
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSBIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controllerDeviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.devicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerDeviceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // devicesDataGridView
            // 
            this.devicesDataGridView.AllowUserToAddRows = false;
            this.devicesDataGridView.AllowUserToDeleteRows = false;
            this.devicesDataGridView.AllowUserToResizeRows = false;
            this.devicesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.devicesDataGridView.AutoGenerateColumns = false;
            this.devicesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.devicesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.devicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.uSBIDDataGridViewTextBoxColumn});
            this.devicesDataGridView.DataSource = this.controllerDeviceBindingSource;
            this.devicesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.devicesDataGridView.MultiSelect = false;
            this.devicesDataGridView.Name = "devicesDataGridView";
            this.devicesDataGridView.RowHeadersVisible = false;
            this.devicesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.devicesDataGridView.Size = new System.Drawing.Size(1101, 585);
            this.devicesDataGridView.TabIndex = 0;
            // 
            // refreshDevicesTimer
            // 
            this.refreshDevicesTimer.Interval = 2000;
            this.refreshDevicesTimer.Tick += new System.EventHandler(this.refreshDevicesTimer_Tick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uSBIDDataGridViewTextBoxColumn
            // 
            this.uSBIDDataGridViewTextBoxColumn.DataPropertyName = "UsbId";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uSBIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.uSBIDDataGridViewTextBoxColumn.HeaderText = "USB ID";
            this.uSBIDDataGridViewTextBoxColumn.Name = "uSBIDDataGridViewTextBoxColumn";
            this.uSBIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.uSBIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // controllerDeviceBindingSource
            // 
            this.controllerDeviceBindingSource.DataSource = typeof(Joystick_Proxy.ControllerDevice);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 603);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // Form1
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1125, 638);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.devicesDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DirectInput Device List";
            ((System.ComponentModel.ISupportInitialize)(this.devicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerDeviceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView devicesDataGridView;
        private System.Windows.Forms.Timer refreshDevicesTimer;
        private System.Windows.Forms.BindingSource controllerDeviceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSBIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button refreshButton;
    }
}

