
using System.Drawing;

namespace LiveSplit.UI.Components
{
    partial class AutoCounterComponentSettings
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

            if (disposing)
                foreach (Image image in ImagesToDispose)
                    image.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_addItem = new System.Windows.Forms.Button();
            this.btn_removeSelected = new System.Windows.Forms.Button();
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_moveUp = new System.Windows.Forms.Button();
            this.btn_moveDown = new System.Windows.Forms.Button();
            this.chk_displayIcons = new System.Windows.Forms.CheckBox();
            this.lbl_iconSize = new System.Windows.Forms.Label();
            this.chk_showGoal = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_itemNameFont = new System.Windows.Forms.Label();
            this.font_name = new System.Windows.Forms.Label();
            this.font_count = new System.Windows.Forms.Label();
            this.lbl_countFont = new System.Windows.Forms.Label();
            this.lbl_goalFont = new System.Windows.Forms.Label();
            this.font_goal = new System.Windows.Forms.Label();
            this.btn_chooseNameFont = new System.Windows.Forms.Button();
            this.btn_chooseCountFont = new System.Windows.Forms.Button();
            this.btn_chooseGoalFont = new System.Windows.Forms.Button();
            this.lbl_bgColor = new System.Windows.Forms.Label();
            this.lbl_goalColor = new System.Windows.Forms.Label();
            this.btn_bgColor = new System.Windows.Forms.Button();
            this.btn_goalColor = new System.Windows.Forms.Button();
            this.grp_color = new System.Windows.Forms.GroupBox();
            this.grp_font = new System.Windows.Forms.GroupBox();
            this.chk_font = new System.Windows.Forms.CheckBox();
            this.trk_iconSize = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lbl_rowHeight = new System.Windows.Forms.Label();
            this.lbl_oldPersonalBest = new System.Windows.Forms.Label();
            this.grp_PB = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_currentPersonalBest = new System.Windows.Forms.TextBox();
            this.txt_oldPersonalBest = new System.Windows.Forms.TextBox();
            this.lbl_currentPersonalBest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.grp_color.SuspendLayout();
            this.grp_font.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_iconSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.grp_PB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addItem
            // 
            this.btn_addItem.Location = new System.Drawing.Point(318, 36);
            this.btn_addItem.Name = "btn_addItem";
            this.btn_addItem.Size = new System.Drawing.Size(103, 23);
            this.btn_addItem.TabIndex = 1;
            this.btn_addItem.Text = "Add Item";
            this.btn_addItem.UseVisualStyleBackColor = true;
            this.btn_addItem.Click += new System.EventHandler(this.btn_addItem_Click);
            // 
            // btn_removeSelected
            // 
            this.btn_removeSelected.Location = new System.Drawing.Point(318, 65);
            this.btn_removeSelected.Name = "btn_removeSelected";
            this.btn_removeSelected.Size = new System.Drawing.Size(103, 23);
            this.btn_removeSelected.TabIndex = 2;
            this.btn_removeSelected.Text = "Remove Selected";
            this.btn_removeSelected.UseVisualStyleBackColor = true;
            this.btn_removeSelected.Click += new System.EventHandler(this.btn_removeItem_Click);
            // 
            // itemGrid
            // 
            this.itemGrid.AllowUserToAddRows = false;
            this.itemGrid.AllowUserToDeleteRows = false;
            this.itemGrid.AllowUserToResizeColumns = false;
            this.itemGrid.AllowUserToResizeRows = false;
            this.itemGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.itemGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Icon,
            this.ItemName,
            this.InitialValue,
            this.GoalValue});
            this.itemGrid.GridColor = System.Drawing.SystemColors.Control;
            this.itemGrid.Location = new System.Drawing.Point(10, 16);
            this.itemGrid.Margin = new System.Windows.Forms.Padding(0);
            this.itemGrid.MaximumSize = new System.Drawing.Size(300, 176);
            this.itemGrid.MinimumSize = new System.Drawing.Size(300, 176);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.itemGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.itemGrid.RowHeadersVisible = false;
            this.itemGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.itemGrid.ShowCellErrors = false;
            this.itemGrid.ShowCellToolTips = false;
            this.itemGrid.ShowEditingIcon = false;
            this.itemGrid.ShowRowErrors = false;
            this.itemGrid.Size = new System.Drawing.Size(300, 176);
            this.itemGrid.TabIndex = 0;
            // 
            // Icon
            // 
            this.Icon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Icon.HeaderText = "Icon";
            this.Icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Icon.MinimumWidth = 50;
            this.Icon.Name = "Icon";
            this.Icon.Width = 50;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 100;
            this.ItemName.Name = "ItemName";
            // 
            // InitialValue
            // 
            this.InitialValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InitialValue.HeaderText = "Initial";
            this.InitialValue.MinimumWidth = 50;
            this.InitialValue.Name = "InitialValue";
            this.InitialValue.Width = 50;
            // 
            // GoalValue
            // 
            this.GoalValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GoalValue.HeaderText = "Goal";
            this.GoalValue.MinimumWidth = 50;
            this.GoalValue.Name = "GoalValue";
            this.GoalValue.Width = 50;
            // 
            // btn_moveUp
            // 
            this.btn_moveUp.Location = new System.Drawing.Point(318, 119);
            this.btn_moveUp.Name = "btn_moveUp";
            this.btn_moveUp.Size = new System.Drawing.Size(103, 23);
            this.btn_moveUp.TabIndex = 3;
            this.btn_moveUp.Text = "Move Up";
            this.btn_moveUp.UseVisualStyleBackColor = true;
            this.btn_moveUp.Click += new System.EventHandler(this.btn_moveUp_Click);
            // 
            // btn_moveDown
            // 
            this.btn_moveDown.Location = new System.Drawing.Point(318, 148);
            this.btn_moveDown.Name = "btn_moveDown";
            this.btn_moveDown.Size = new System.Drawing.Size(103, 23);
            this.btn_moveDown.TabIndex = 4;
            this.btn_moveDown.Text = "Move Down";
            this.btn_moveDown.UseVisualStyleBackColor = true;
            this.btn_moveDown.Click += new System.EventHandler(this.btn_moveDown_Click);
            // 
            // chk_displayIcons
            // 
            this.chk_displayIcons.AutoSize = true;
            this.chk_displayIcons.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_displayIcons.Checked = true;
            this.chk_displayIcons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_displayIcons.Location = new System.Drawing.Point(10, 210);
            this.chk_displayIcons.Name = "chk_displayIcons";
            this.chk_displayIcons.Size = new System.Drawing.Size(89, 17);
            this.chk_displayIcons.TabIndex = 0;
            this.chk_displayIcons.Text = "Display Icons";
            this.chk_displayIcons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_displayIcons.UseVisualStyleBackColor = true;
            this.chk_displayIcons.CheckStateChanged += new System.EventHandler(this.chk_displayIcons_CheckStateChanged);
            // 
            // lbl_iconSize
            // 
            this.lbl_iconSize.AutoSize = true;
            this.lbl_iconSize.Location = new System.Drawing.Point(154, 211);
            this.lbl_iconSize.Name = "lbl_iconSize";
            this.lbl_iconSize.Size = new System.Drawing.Size(51, 13);
            this.lbl_iconSize.TabIndex = 2;
            this.lbl_iconSize.Text = "Icon Size";
            // 
            // chk_showGoal
            // 
            this.chk_showGoal.AutoSize = true;
            this.chk_showGoal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_showGoal.Checked = true;
            this.chk_showGoal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_showGoal.Location = new System.Drawing.Point(10, 247);
            this.chk_showGoal.Name = "chk_showGoal";
            this.chk_showGoal.Size = new System.Drawing.Size(78, 17);
            this.chk_showGoal.TabIndex = 3;
            this.chk_showGoal.Text = "Show Goal";
            this.chk_showGoal.UseVisualStyleBackColor = true;
            this.chk_showGoal.CheckStateChanged += new System.EventHandler(this.chk_showGoal_CheckStateChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_itemNameFont, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.font_name, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.font_count, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_countFont, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_goalFont, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.font_goal, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_chooseNameFont, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_chooseCountFont, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_chooseGoalFont, 2, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(42, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(347, 89);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // lbl_itemNameFont
            // 
            this.lbl_itemNameFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_itemNameFont.AutoSize = true;
            this.lbl_itemNameFont.Location = new System.Drawing.Point(3, 8);
            this.lbl_itemNameFont.Name = "lbl_itemNameFont";
            this.lbl_itemNameFont.Size = new System.Drawing.Size(88, 13);
            this.lbl_itemNameFont.TabIndex = 0;
            this.lbl_itemNameFont.Text = "Item Name Font :";
            // 
            // font_name
            // 
            this.font_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.font_name.AutoSize = true;
            this.font_name.Location = new System.Drawing.Point(164, 8);
            this.font_name.Name = "font_name";
            this.font_name.Size = new System.Drawing.Size(36, 13);
            this.font_name.TabIndex = 1;
            this.font_name.Text = "FONT";
            this.font_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // font_count
            // 
            this.font_count.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.font_count.AutoSize = true;
            this.font_count.Location = new System.Drawing.Point(164, 37);
            this.font_count.Name = "font_count";
            this.font_count.Size = new System.Drawing.Size(36, 13);
            this.font_count.TabIndex = 3;
            this.font_count.Text = "FONT";
            this.font_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_countFont
            // 
            this.lbl_countFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_countFont.AutoSize = true;
            this.lbl_countFont.Location = new System.Drawing.Point(3, 37);
            this.lbl_countFont.Name = "lbl_countFont";
            this.lbl_countFont.Size = new System.Drawing.Size(65, 13);
            this.lbl_countFont.TabIndex = 2;
            this.lbl_countFont.Text = "Count Font :";
            // 
            // lbl_goalFont
            // 
            this.lbl_goalFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_goalFont.AutoSize = true;
            this.lbl_goalFont.Location = new System.Drawing.Point(3, 67);
            this.lbl_goalFont.Name = "lbl_goalFont";
            this.lbl_goalFont.Size = new System.Drawing.Size(59, 13);
            this.lbl_goalFont.TabIndex = 4;
            this.lbl_goalFont.Text = "Goal Font :";
            // 
            // font_goal
            // 
            this.font_goal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.font_goal.AutoSize = true;
            this.font_goal.Location = new System.Drawing.Point(164, 67);
            this.font_goal.Name = "font_goal";
            this.font_goal.Size = new System.Drawing.Size(36, 13);
            this.font_goal.TabIndex = 5;
            this.font_goal.Text = "FONT";
            this.font_goal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_chooseNameFont
            // 
            this.btn_chooseNameFont.Location = new System.Drawing.Point(269, 3);
            this.btn_chooseNameFont.Name = "btn_chooseNameFont";
            this.btn_chooseNameFont.Size = new System.Drawing.Size(75, 22);
            this.btn_chooseNameFont.TabIndex = 6;
            this.btn_chooseNameFont.Text = "Choose...";
            this.btn_chooseNameFont.UseVisualStyleBackColor = true;
            this.btn_chooseNameFont.Click += new System.EventHandler(this.btn_chooseNameFont_Click);
            // 
            // btn_chooseCountFont
            // 
            this.btn_chooseCountFont.Location = new System.Drawing.Point(269, 32);
            this.btn_chooseCountFont.Name = "btn_chooseCountFont";
            this.btn_chooseCountFont.Size = new System.Drawing.Size(75, 21);
            this.btn_chooseCountFont.TabIndex = 7;
            this.btn_chooseCountFont.Text = "Choose...";
            this.btn_chooseCountFont.UseVisualStyleBackColor = true;
            this.btn_chooseCountFont.Click += new System.EventHandler(this.btn_chooseCountFont_Click);
            // 
            // btn_chooseGoalFont
            // 
            this.btn_chooseGoalFont.Location = new System.Drawing.Point(269, 61);
            this.btn_chooseGoalFont.Name = "btn_chooseGoalFont";
            this.btn_chooseGoalFont.Size = new System.Drawing.Size(75, 23);
            this.btn_chooseGoalFont.TabIndex = 8;
            this.btn_chooseGoalFont.Text = "Choose...";
            this.btn_chooseGoalFont.UseVisualStyleBackColor = true;
            this.btn_chooseGoalFont.Click += new System.EventHandler(this.btn_chooseGoalFont_Click);
            // 
            // lbl_bgColor
            // 
            this.lbl_bgColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_bgColor.AutoSize = true;
            this.lbl_bgColor.Location = new System.Drawing.Point(22, 21);
            this.lbl_bgColor.Name = "lbl_bgColor";
            this.lbl_bgColor.Size = new System.Drawing.Size(98, 13);
            this.lbl_bgColor.TabIndex = 0;
            this.lbl_bgColor.Text = "Background Color :";
            this.lbl_bgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_goalColor
            // 
            this.lbl_goalColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_goalColor.AutoSize = true;
            this.lbl_goalColor.Location = new System.Drawing.Point(229, 21);
            this.lbl_goalColor.Name = "lbl_goalColor";
            this.lbl_goalColor.Size = new System.Drawing.Size(104, 13);
            this.lbl_goalColor.TabIndex = 1;
            this.lbl_goalColor.Text = "Finished Goal Color :";
            this.lbl_goalColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_bgColor
            // 
            this.btn_bgColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_bgColor.Location = new System.Drawing.Point(128, 16);
            this.btn_bgColor.Name = "btn_bgColor";
            this.btn_bgColor.Size = new System.Drawing.Size(72, 23);
            this.btn_bgColor.TabIndex = 2;
            this.btn_bgColor.UseMnemonic = false;
            this.btn_bgColor.UseVisualStyleBackColor = true;
            this.btn_bgColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // btn_goalColor
            // 
            this.btn_goalColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_goalColor.Location = new System.Drawing.Point(341, 16);
            this.btn_goalColor.Name = "btn_goalColor";
            this.btn_goalColor.Size = new System.Drawing.Size(72, 23);
            this.btn_goalColor.TabIndex = 3;
            this.btn_goalColor.UseVisualStyleBackColor = true;
            this.btn_goalColor.Click += new System.EventHandler(this.ColorButtonClick);
            // 
            // grp_color
            // 
            this.grp_color.Controls.Add(this.lbl_bgColor);
            this.grp_color.Controls.Add(this.btn_bgColor);
            this.grp_color.Controls.Add(this.lbl_goalColor);
            this.grp_color.Controls.Add(this.btn_goalColor);
            this.grp_color.Location = new System.Drawing.Point(13, 571);
            this.grp_color.Name = "grp_color";
            this.grp_color.Size = new System.Drawing.Size(432, 48);
            this.grp_color.TabIndex = 10;
            this.grp_color.TabStop = false;
            this.grp_color.Text = "Colors";
            // 
            // grp_font
            // 
            this.grp_font.Controls.Add(this.tableLayoutPanel2);
            this.grp_font.Location = new System.Drawing.Point(13, 439);
            this.grp_font.Name = "grp_font";
            this.grp_font.Size = new System.Drawing.Size(432, 116);
            this.grp_font.TabIndex = 11;
            this.grp_font.TabStop = false;
            this.grp_font.Text = "Fonts";
            // 
            // chk_font
            // 
            this.chk_font.AutoSize = true;
            this.chk_font.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_font.Location = new System.Drawing.Point(13, 414);
            this.chk_font.Name = "chk_font";
            this.chk_font.Size = new System.Drawing.Size(125, 17);
            this.chk_font.TabIndex = 7;
            this.chk_font.Text = "Override Layout Font";
            this.chk_font.UseVisualStyleBackColor = true;
            // 
            // trk_iconSize
            // 
            this.trk_iconSize.BackColor = System.Drawing.SystemColors.Control;
            this.trk_iconSize.Location = new System.Drawing.Point(219, 208);
            this.trk_iconSize.Maximum = 80;
            this.trk_iconSize.Minimum = 10;
            this.trk_iconSize.Name = "trk_iconSize";
            this.trk_iconSize.Size = new System.Drawing.Size(152, 45);
            this.trk_iconSize.TabIndex = 13;
            this.trk_iconSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trk_iconSize.Value = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.lbl_rowHeight);
            this.groupBox1.Controls.Add(this.trk_iconSize);
            this.groupBox1.Controls.Add(this.chk_displayIcons);
            this.groupBox1.Controls.Add(this.lbl_iconSize);
            this.groupBox1.Controls.Add(this.chk_showGoal);
            this.groupBox1.Controls.Add(this.btn_moveDown);
            this.groupBox1.Controls.Add(this.btn_moveUp);
            this.groupBox1.Controls.Add(this.btn_removeSelected);
            this.groupBox1.Controls.Add(this.btn_addItem);
            this.groupBox1.Controls.Add(this.itemGrid);
            this.groupBox1.Location = new System.Drawing.Point(13, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 279);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(219, 245);
            this.trackBar1.Maximum = 80;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(152, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 10;
            this.trackBar1.Visible = false;
            // 
            // lbl_rowHeight
            // 
            this.lbl_rowHeight.AutoSize = true;
            this.lbl_rowHeight.Location = new System.Drawing.Point(154, 248);
            this.lbl_rowHeight.Name = "lbl_rowHeight";
            this.lbl_rowHeight.Size = new System.Drawing.Size(63, 13);
            this.lbl_rowHeight.TabIndex = 14;
            this.lbl_rowHeight.Text = "Row Height";
            this.lbl_rowHeight.Visible = false;
            // 
            // lbl_oldPersonalBest
            // 
            this.lbl_oldPersonalBest.AutoSize = true;
            this.lbl_oldPersonalBest.Location = new System.Drawing.Point(22, 26);
            this.lbl_oldPersonalBest.Name = "lbl_oldPersonalBest";
            this.lbl_oldPersonalBest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_oldPersonalBest.Size = new System.Drawing.Size(85, 13);
            this.lbl_oldPersonalBest.TabIndex = 15;
            this.lbl_oldPersonalBest.Text = "PB History Label";
            this.lbl_oldPersonalBest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grp_PB
            // 
            this.grp_PB.Controls.Add(this.button2);
            this.grp_PB.Controls.Add(this.button1);
            this.grp_PB.Controls.Add(this.txt_currentPersonalBest);
            this.grp_PB.Controls.Add(this.txt_oldPersonalBest);
            this.grp_PB.Controls.Add(this.lbl_currentPersonalBest);
            this.grp_PB.Controls.Add(this.lbl_oldPersonalBest);
            this.grp_PB.Location = new System.Drawing.Point(13, 15);
            this.grp_PB.Name = "grp_PB";
            this.grp_PB.Size = new System.Drawing.Size(432, 83);
            this.grp_PB.TabIndex = 16;
            this.grp_PB.TabStop = false;
            this.grp_PB.Text = "Personal Best Component Info";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(338, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Reset Value";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Reset Value";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_currentPersonalBest
            // 
            this.txt_currentPersonalBest.Location = new System.Drawing.Point(116, 53);
            this.txt_currentPersonalBest.Name = "txt_currentPersonalBest";
            this.txt_currentPersonalBest.Size = new System.Drawing.Size(204, 20);
            this.txt_currentPersonalBest.TabIndex = 18;
            this.txt_currentPersonalBest.TextChanged += new System.EventHandler(this.txt_currentPersonalBest_TextChanged);
            // 
            // txt_oldPersonalBest
            // 
            this.txt_oldPersonalBest.Location = new System.Drawing.Point(116, 22);
            this.txt_oldPersonalBest.Name = "txt_oldPersonalBest";
            this.txt_oldPersonalBest.Size = new System.Drawing.Size(204, 20);
            this.txt_oldPersonalBest.TabIndex = 17;
            this.txt_oldPersonalBest.TextChanged += new System.EventHandler(this.txt_oldPersonalBest_TextChanged);
            // 
            // lbl_currentPersonalBest
            // 
            this.lbl_currentPersonalBest.AutoSize = true;
            this.lbl_currentPersonalBest.Location = new System.Drawing.Point(22, 57);
            this.lbl_currentPersonalBest.Name = "lbl_currentPersonalBest";
            this.lbl_currentPersonalBest.Size = new System.Drawing.Size(90, 13);
            this.lbl_currentPersonalBest.TabIndex = 16;
            this.lbl_currentPersonalBest.Text = "Session PB Label";
            this.lbl_currentPersonalBest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoCounterComponentSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_PB);
            this.Controls.Add(this.chk_font);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_font);
            this.Controls.Add(this.grp_color);
            this.Name = "AutoCounterComponentSettings";
            this.Size = new System.Drawing.Size(453, 669);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.grp_color.ResumeLayout(false);
            this.grp_color.PerformLayout();
            this.grp_font.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trk_iconSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.grp_PB.ResumeLayout(false);
            this.grp_PB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_addItem;
        private System.Windows.Forms.Button btn_removeSelected;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoalValue;
        private System.Windows.Forms.Button btn_moveUp;
        private System.Windows.Forms.Button btn_moveDown;
        private System.Windows.Forms.CheckBox chk_displayIcons;
        private System.Windows.Forms.Label lbl_iconSize;
        private System.Windows.Forms.CheckBox chk_showGoal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_itemNameFont;
        private System.Windows.Forms.Label font_name;
        private System.Windows.Forms.Label lbl_countFont;
        private System.Windows.Forms.Label font_count;
        private System.Windows.Forms.Label lbl_goalFont;
        private System.Windows.Forms.Label font_goal;
        private System.Windows.Forms.Button btn_chooseNameFont;
        private System.Windows.Forms.Button btn_chooseCountFont;
        private System.Windows.Forms.Button btn_chooseGoalFont;
        private System.Windows.Forms.Label lbl_bgColor;
        private System.Windows.Forms.Label lbl_goalColor;
        private System.Windows.Forms.Button btn_bgColor;
        private System.Windows.Forms.Button btn_goalColor;
        private System.Windows.Forms.GroupBox grp_color;
        private System.Windows.Forms.GroupBox grp_font;
        private System.Windows.Forms.CheckBox chk_font;
        private System.Windows.Forms.TrackBar trk_iconSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_rowHeight;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lbl_oldPersonalBest;
        private System.Windows.Forms.GroupBox grp_PB;
        private System.Windows.Forms.TextBox txt_oldPersonalBest;
        private System.Windows.Forms.Label lbl_currentPersonalBest;
        private System.Windows.Forms.TextBox txt_currentPersonalBest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
