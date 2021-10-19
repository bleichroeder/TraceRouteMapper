
namespace TraceRouteMapper
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MapControl = new GMap.NET.WindowsForms.GMapControl();
            this.StartTraceButton = new System.Windows.Forms.Button();
            this.ZoomInButton = new System.Windows.Forms.Button();
            this.ZoomOutButton = new System.Windows.Forms.Button();
            this.StatusOutput = new System.Windows.Forms.TextBox();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputGrid = new System.Windows.Forms.DataGridView();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.Hop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Postal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OutputGrid)).BeginInit();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.Bearing = 0F;
            this.MapControl.CanDragMap = true;
            this.MapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.MapControl.GrayScaleMode = false;
            this.MapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapControl.LevelsKeepInMemory = 5;
            this.MapControl.Location = new System.Drawing.Point(0, 0);
            this.MapControl.MarkersEnabled = true;
            this.MapControl.MaxZoom = 18;
            this.MapControl.MinZoom = 2;
            this.MapControl.MouseWheelZoomEnabled = true;
            this.MapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MapControl.Name = "MapControl";
            this.MapControl.NegativeMode = false;
            this.MapControl.PolygonsEnabled = true;
            this.MapControl.RetryLoadTile = 0;
            this.MapControl.RoutesEnabled = true;
            this.MapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MapControl.ShowTileGridLines = false;
            this.MapControl.Size = new System.Drawing.Size(801, 424);
            this.MapControl.TabIndex = 3;
            this.MapControl.Visible = false;
            this.MapControl.Zoom = 0D;
            // 
            // StartTraceButton
            // 
            this.StartTraceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTraceButton.Location = new System.Drawing.Point(298, -1);
            this.StartTraceButton.Name = "StartTraceButton";
            this.StartTraceButton.Size = new System.Drawing.Size(75, 24);
            this.StartTraceButton.TabIndex = 1;
            this.StartTraceButton.Text = "TraceRoute";
            this.StartTraceButton.UseVisualStyleBackColor = true;
            this.StartTraceButton.Click += new System.EventHandler(this.StartTraceButton_Click);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZoomInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomInButton.Location = new System.Drawing.Point(719, 400);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(41, 24);
            this.ZoomInButton.TabIndex = 2;
            this.ZoomInButton.Text = "+";
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZoomOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomOutButton.Location = new System.Drawing.Point(759, 400);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(41, 24);
            this.ZoomOutButton.TabIndex = 3;
            this.ZoomOutButton.Text = "-";
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // StatusOutput
            // 
            this.StatusOutput.BackColor = System.Drawing.SystemColors.Control;
            this.StatusOutput.Enabled = false;
            this.StatusOutput.Location = new System.Drawing.Point(0, 648);
            this.StatusOutput.Name = "StatusOutput";
            this.StatusOutput.ReadOnly = true;
            this.StatusOutput.Size = new System.Drawing.Size(801, 20);
            this.StatusOutput.TabIndex = 6;
            this.StatusOutput.Text = "Ready...";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(-1, -1);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(300, 24);
            this.InputTextBox.TabIndex = 0;
            // 
            // OutputGrid
            // 
            this.OutputGrid.AllowUserToAddRows = false;
            this.OutputGrid.AllowUserToDeleteRows = false;
            this.OutputGrid.AllowUserToResizeColumns = false;
            this.OutputGrid.AllowUserToResizeRows = false;
            this.OutputGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OutputGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OutputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hop,
            this.IPAddress,
            this.HostName,
            this.Time,
            this.Country,
            this.State,
            this.City,
            this.Postal,
            this.Latitude,
            this.Longitude});
            this.OutputGrid.Location = new System.Drawing.Point(-1, 423);
            this.OutputGrid.Name = "OutputGrid";
            this.OutputGrid.ReadOnly = true;
            this.OutputGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.OutputGrid.RowHeadersVisible = false;
            this.OutputGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputGrid.ShowCellErrors = false;
            this.OutputGrid.ShowEditingIcon = false;
            this.OutputGrid.ShowRowErrors = false;
            this.OutputGrid.Size = new System.Drawing.Size(801, 226);
            this.OutputGrid.TabIndex = 11;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.StartTraceButton);
            this.ControlPanel.Controls.Add(this.InputTextBox);
            this.ControlPanel.Location = new System.Drawing.Point(0, 400);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(374, 24);
            this.ControlPanel.TabIndex = 13;
            // 
            // Hop
            // 
            this.Hop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Hop.HeaderText = "Hop";
            this.Hop.Name = "Hop";
            this.Hop.ReadOnly = true;
            this.Hop.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Hop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Hop.Width = 33;
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IPAddress";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            this.IPAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // HostName
            // 
            this.HostName.HeaderText = "HostName";
            this.HostName.Name = "HostName";
            this.HostName.ReadOnly = true;
            this.HostName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Postal
            // 
            this.Postal.HeaderText = "Postal";
            this.Postal.Name = "Postal";
            this.Postal.ReadOnly = true;
            this.Postal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Latitude
            // 
            this.Latitude.HeaderText = "Latitude";
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            this.Latitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Longitude
            // 
            this.Longitude.HeaderText = "Longitude";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Longitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadingLabel.Location = new System.Drawing.Point(322, 197);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(168, 22);
            this.LoadingLabel.TabIndex = 14;
            this.LoadingLabel.Text = "Loading map data...";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 667);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.OutputGrid);
            this.Controls.Add(this.StatusOutput);
            this.Controls.Add(this.ZoomOutButton);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.MapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "TraceRouteMapper";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutputGrid)).EndInit();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl MapControl;
        private System.Windows.Forms.Button StartTraceButton;
        private System.Windows.Forms.Button ZoomInButton;
        private System.Windows.Forms.Button ZoomOutButton;
        private System.Windows.Forms.TextBox StatusOutput;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.DataGridView OutputGrid;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hop;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Postal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.Label LoadingLabel;
    }
}

