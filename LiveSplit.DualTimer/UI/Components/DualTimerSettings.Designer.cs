namespace LiveSplit.UI.Components
{
    partial class DualTimerSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTimingMethod = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trkSize = new System.Windows.Forms.TrackBar();
            this.lblSize = new System.Windows.Forms.Label();
            this.trkAlternateTimerRatio = new System.Windows.Forms.TrackBar();
            this.cmbGradientType = new System.Windows.Forms.ComboBox();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.trkDecimalsSize = new System.Windows.Forms.TrackBar();
            this.cmbDigitsFormat = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chkShowGradientTimer = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimerColor = new System.Windows.Forms.Button();
            this.chkOverrideTimerColors = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbAccuracy = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.trkAlternateDecimalsSize = new System.Windows.Forms.TrackBar();
            this.btnAlternateTimerColor = new System.Windows.Forms.Button();
            this.cmbAlternateDigitsFormat = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkShowGradientAlternateTimer = new System.Windows.Forms.CheckBox();
            this.cmbAlternateAccuracy = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trkSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAlternateTimerRatio)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkDecimalsSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkAlternateDecimalsSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.41109F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.58891F));
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(433, 59);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 0;
            // 
            // cmbTimingMethod
            // 
            this.cmbTimingMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cmbTimingMethod, 3);
            this.cmbTimingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimingMethod.FormattingEnabled = true;
            this.cmbTimingMethod.Items.AddRange(new object[] {
            "Current Timing Method",
            "Real Time",
            "Game Time"});
            this.cmbTimingMethod.Location = new System.Drawing.Point(156, 33);
            this.cmbTimingMethod.Name = "cmbTimingMethod";
            this.cmbTimingMethod.Size = new System.Drawing.Size(286, 21);
            this.cmbTimingMethod.TabIndex = 3;
            this.cmbTimingMethod.SelectedIndexChanged += new System.EventHandler(this.cmbTimingMethod_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Timing Method:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Alternate Timer Size:";
            // 
            // trkSize
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.trkSize, 3);
            this.trkSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkSize.Location = new System.Drawing.Point(156, 76);
            this.trkSize.Name = "trkSize";
            this.trkSize.Size = new System.Drawing.Size(286, 23);
            this.trkSize.TabIndex = 5;
            this.trkSize.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 81);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(147, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Height:";
            // 
            // trkAlternateTimerRatio
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.trkAlternateTimerRatio, 3);
            this.trkAlternateTimerRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trkAlternateTimerRatio.Location = new System.Drawing.Point(156, 105);
            this.trkAlternateTimerRatio.Maximum = 90;
            this.trkAlternateTimerRatio.Minimum = 10;
            this.trkAlternateTimerRatio.Name = "trkAlternateTimerRatio";
            this.trkAlternateTimerRatio.Size = new System.Drawing.Size(286, 23);
            this.trkAlternateTimerRatio.TabIndex = 6;
            this.trkAlternateTimerRatio.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkAlternateTimerRatio.Value = 10;
            // 
            // cmbGradientType
            // 
            this.cmbGradientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradientType.FormattingEnabled = true;
            this.cmbGradientType.Items.AddRange(new object[] {
            "Plain",
            "Vertical",
            "Horizontal",
            "Plain With Delta Color",
            "Vertical With Delta Color",
            "Horizontal With Delta Color"});
            this.cmbGradientType.Location = new System.Drawing.Point(214, 4);
            this.cmbGradientType.Name = "cmbGradientType";
            this.cmbGradientType.Size = new System.Drawing.Size(228, 21);
            this.cmbGradientType.TabIndex = 2;
            this.cmbGradientType.SelectedIndexChanged += new System.EventHandler(this.cmbGradientType_SelectedIndexChanged);
            // 
            // btnColor1
            // 
            this.btnColor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnColor1.Location = new System.Drawing.Point(156, 3);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(23, 23);
            this.btnColor1.TabIndex = 0;
            this.btnColor1.UseVisualStyleBackColor = false;
            this.btnColor1.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Background Color:";
            // 
            // btnColor2
            // 
            this.btnColor2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnColor2.Location = new System.Drawing.Point(185, 3);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(23, 23);
            this.btnColor2.TabIndex = 1;
            this.btnColor2.UseVisualStyleBackColor = false;
            this.btnColor2.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnColor2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnColor1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbGradientType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.trkAlternateTimerRatio, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblSize, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trkSize, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbTimingMethod, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(445, 509);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.cmbAccuracy, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkShowGradientTimer, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbDigitsFormat, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.trkDecimalsSize, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(433, 170);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // trkDecimalsSize
            // 
            this.trkDecimalsSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.trkDecimalsSize, 2);
            this.trkDecimalsSize.Location = new System.Drawing.Point(147, 143);
            this.trkDecimalsSize.Maximum = 50;
            this.trkDecimalsSize.Minimum = 10;
            this.trkDecimalsSize.Name = "trkDecimalsSize";
            this.trkDecimalsSize.Size = new System.Drawing.Size(283, 24);
            this.trkDecimalsSize.TabIndex = 6;
            this.trkDecimalsSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkDecimalsSize.Value = 10;
            // 
            // cmbDigitsFormat
            // 
            this.cmbDigitsFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDigitsFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDigitsFormat.FormattingEnabled = true;
            this.cmbDigitsFormat.Items.AddRange(new object[] {
            "1",
            "00:01",
            "0:00:01",
            "00:00:01"});
            this.cmbDigitsFormat.Location = new System.Drawing.Point(147, 115);
            this.cmbDigitsFormat.Name = "cmbDigitsFormat";
            this.cmbDigitsFormat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDigitsFormat.Size = new System.Drawing.Size(138, 21);
            this.cmbDigitsFormat.TabIndex = 4;
            this.cmbDigitsFormat.SelectedIndexChanged += new System.EventHandler(this.cmbDigitsFormat_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 148);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Decimals Font Size:";
            // 
            // chkShowGradientTimer
            // 
            this.chkShowGradientTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowGradientTimer.AutoSize = true;
            this.chkShowGradientTimer.Location = new System.Drawing.Point(7, 88);
            this.chkShowGradientTimer.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.chkShowGradientTimer.Name = "chkShowGradientTimer";
            this.chkShowGradientTimer.Size = new System.Drawing.Size(134, 17);
            this.chkShowGradientTimer.TabIndex = 1;
            this.chkShowGradientTimer.Text = "Show Gradient";
            this.chkShowGradientTimer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Color:";
            // 
            // btnTimerColor
            // 
            this.btnTimerColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTimerColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimerColor.Location = new System.Drawing.Point(141, 32);
            this.btnTimerColor.Name = "btnTimerColor";
            this.btnTimerColor.Size = new System.Drawing.Size(23, 23);
            this.btnTimerColor.TabIndex = 1;
            this.btnTimerColor.UseVisualStyleBackColor = false;
            this.btnTimerColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // chkOverrideTimerColors
            // 
            this.chkOverrideTimerColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOverrideTimerColors.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.chkOverrideTimerColors, 2);
            this.chkOverrideTimerColors.Location = new System.Drawing.Point(7, 6);
            this.chkOverrideTimerColors.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.chkOverrideTimerColors.Name = "chkOverrideTimerColors";
            this.chkOverrideTimerColors.Size = new System.Drawing.Size(411, 17);
            this.chkOverrideTimerColors.TabIndex = 0;
            this.chkOverrideTimerColors.Text = "Override Layout Settings";
            this.chkOverrideTimerColors.UseVisualStyleBackColor = true;
            this.chkOverrideTimerColors.CheckedChanged += new System.EventHandler(this.chkOverrideTimerColors_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Format:";
            // 
            // cmbAccuracy
            // 
            this.cmbAccuracy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAccuracy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccuracy.FormattingEnabled = true;
            this.cmbAccuracy.Items.AddRange(new object[] {
            "",
            ".2",
            ".23"});
            this.cmbAccuracy.Location = new System.Drawing.Point(291, 115);
            this.cmbAccuracy.Name = "cmbAccuracy";
            this.cmbAccuracy.Size = new System.Drawing.Size(139, 21);
            this.cmbAccuracy.TabIndex = 7;
            this.cmbAccuracy.SelectedIndexChanged += new System.EventHandler(this.cmbAccuracy_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 189);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Timer";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33778F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33778F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.32444F));
            this.tableLayoutPanel4.Controls.Add(this.cmbAlternateAccuracy, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.chkShowGradientAlternateTimer, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label18, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.cmbAlternateDigitsFormat, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnAlternateTimerColor, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.trkAlternateDecimalsSize, 1, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(433, 118);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // trkAlternateDecimalsSize
            // 
            this.trkAlternateDecimalsSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.trkAlternateDecimalsSize, 2);
            this.trkAlternateDecimalsSize.Location = new System.Drawing.Point(147, 90);
            this.trkAlternateDecimalsSize.Maximum = 50;
            this.trkAlternateDecimalsSize.Minimum = 10;
            this.trkAlternateDecimalsSize.Name = "trkAlternateDecimalsSize";
            this.trkAlternateDecimalsSize.Size = new System.Drawing.Size(283, 25);
            this.trkAlternateDecimalsSize.TabIndex = 5;
            this.trkAlternateDecimalsSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkAlternateDecimalsSize.Value = 10;
            // 
            // btnAlternateTimerColor
            // 
            this.btnAlternateTimerColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlternateTimerColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlternateTimerColor.Location = new System.Drawing.Point(147, 3);
            this.btnAlternateTimerColor.Name = "btnAlternateTimerColor";
            this.btnAlternateTimerColor.Size = new System.Drawing.Size(23, 23);
            this.btnAlternateTimerColor.TabIndex = 0;
            this.btnAlternateTimerColor.UseVisualStyleBackColor = false;
            this.btnAlternateTimerColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // cmbAlternateDigitsFormat
            // 
            this.cmbAlternateDigitsFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAlternateDigitsFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlternateDigitsFormat.FormattingEnabled = true;
            this.cmbAlternateDigitsFormat.Items.AddRange(new object[] {
            "1",
            "00:01",
            "0:00:01",
            "00:00:01"});
            this.cmbAlternateDigitsFormat.Location = new System.Drawing.Point(147, 62);
            this.cmbAlternateDigitsFormat.Name = "cmbAlternateDigitsFormat";
            this.cmbAlternateDigitsFormat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAlternateDigitsFormat.Size = new System.Drawing.Size(138, 21);
            this.cmbAlternateDigitsFormat.TabIndex = 3;
            this.cmbAlternateDigitsFormat.SelectedIndexChanged += new System.EventHandler(this.cmbAlternateDigitsFormat_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(138, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Decimals Font Size:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Format:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Color:";
            // 
            // chkShowGradientAlternateTimer
            // 
            this.chkShowGradientAlternateTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowGradientAlternateTimer.AutoSize = true;
            this.chkShowGradientAlternateTimer.Location = new System.Drawing.Point(7, 35);
            this.chkShowGradientAlternateTimer.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.chkShowGradientAlternateTimer.Name = "chkShowGradientAlternateTimer";
            this.chkShowGradientAlternateTimer.Size = new System.Drawing.Size(134, 17);
            this.chkShowGradientAlternateTimer.TabIndex = 1;
            this.chkShowGradientAlternateTimer.Text = "Show Gradient";
            this.chkShowGradientAlternateTimer.UseVisualStyleBackColor = true;
            // 
            // cmbAlternateAccuracy
            // 
            this.cmbAlternateAccuracy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAlternateAccuracy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlternateAccuracy.FormattingEnabled = true;
            this.cmbAlternateAccuracy.Items.AddRange(new object[] {
            "",
            ".2",
            ".23"});
            this.cmbAlternateAccuracy.Location = new System.Drawing.Point(291, 62);
            this.cmbAlternateAccuracy.Name = "cmbAlternateAccuracy";
            this.cmbAlternateAccuracy.Size = new System.Drawing.Size(139, 21);
            this.cmbAlternateAccuracy.TabIndex = 6;
            this.cmbAlternateAccuracy.SelectedIndexChanged += new System.EventHandler(this.cmbAlternateAccuracy_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 4);
            this.groupBox3.Controls.Add(this.tableLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 137);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alternate Timer";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.7791F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.2209F));
            this.tableLayoutPanel3.Controls.Add(this.chkOverrideTimerColors, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnTimerColor, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(421, 58);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 77);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // DualTimerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DualTimerSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(459, 523);
            this.Load += new System.EventHandler(this.DualTimerSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trkSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAlternateTimerRatio)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkDecimalsSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkAlternateDecimalsSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        //private System.Windows.Forms.CheckBox chkSplitName;
        //private System.Windows.Forms.Button btnSplitNameColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTimingMethod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.ComboBox cmbGradientType;
        private System.Windows.Forms.TrackBar trkAlternateTimerRatio;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TrackBar trkSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cmbAccuracy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkOverrideTimerColors;
        private System.Windows.Forms.Button btnTimerColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowGradientTimer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbDigitsFormat;
        private System.Windows.Forms.TrackBar trkDecimalsSize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox cmbAlternateAccuracy;
        private System.Windows.Forms.CheckBox chkShowGradientAlternateTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbAlternateDigitsFormat;
        private System.Windows.Forms.Button btnAlternateTimerColor;
        private System.Windows.Forms.TrackBar trkAlternateDecimalsSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
