namespace Projectile_Sim
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
            this.groupCurrentValues = new System.Windows.Forms.GroupBox();
            this.tabSelectProjectile = new System.Windows.Forms.TabControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeUnits = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupAnimation = new System.Windows.Forms.GroupBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.upDownRefreshRate = new System.Windows.Forms.NumericUpDown();
            this.radioNoAnimation = new System.Windows.Forms.RadioButton();
            this.radioRefreshRate = new System.Windows.Forms.RadioButton();
            this.radioRealTime = new System.Windows.Forms.RadioButton();
            this.lblHzRefresh = new System.Windows.Forms.Label();
            this.groupAddProjectile = new System.Windows.Forms.GroupBox();
            this.btnAddProjectile = new System.Windows.Forms.Button();
            this.comboColour = new System.Windows.Forms.ComboBox();
            this.lblColour = new System.Windows.Forms.Label();
            this.tabProjectileType = new System.Windows.Forms.TabControl();
            this.tabSpeedAngle = new System.Windows.Forms.TabPage();
            this.upDownG = new System.Windows.Forms.NumericUpDown();
            this.upDownInitHeight = new System.Windows.Forms.NumericUpDown();
            this.upDownAngle = new System.Windows.Forms.NumericUpDown();
            this.upDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblGUnits = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblHeightUnits = new System.Windows.Forms.Label();
            this.lblInitHeight = new System.Windows.Forms.Label();
            this.lblAngleUnits = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.lblSpeedUnits = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tabComponents = new System.Windows.Forms.TabPage();
            this.tabEnergy = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.itemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImportBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportGraph = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            this.groupCurrentValues.SuspendLayout();
            this.groupAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRefreshRate)).BeginInit();
            this.groupAddProjectile.SuspendLayout();
            this.tabProjectileType.SuspendLayout();
            this.tabSpeedAngle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSpeed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxPlot);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupCurrentValues);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.groupAnimation);
            this.splitContainer1.Panel2.Controls.Add(this.groupAddProjectile);
            this.splitContainer1.Size = new System.Drawing.Size(832, 690);
            this.splitContainer1.SplitterDistance = 563;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBoxPlot
            // 
            this.pictureBoxPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPlot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPlot.Location = new System.Drawing.Point(9, 9);
            this.pictureBoxPlot.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pictureBoxPlot.Name = "pictureBoxPlot";
            this.pictureBoxPlot.Size = new System.Drawing.Size(544, 672);
            this.pictureBoxPlot.TabIndex = 0;
            this.pictureBoxPlot.TabStop = false;
            // 
            // groupCurrentValues
            // 
            this.groupCurrentValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCurrentValues.Controls.Add(this.tabSelectProjectile);
            this.groupCurrentValues.Controls.Add(this.textBox1);
            this.groupCurrentValues.Controls.Add(this.lblTime);
            this.groupCurrentValues.Controls.Add(this.lblTimeUnits);
            this.groupCurrentValues.Location = new System.Drawing.Point(3, 230);
            this.groupCurrentValues.Name = "groupCurrentValues";
            this.groupCurrentValues.Size = new System.Drawing.Size(259, 327);
            this.groupCurrentValues.TabIndex = 3;
            this.groupCurrentValues.TabStop = false;
            this.groupCurrentValues.Text = "Current Values";
            // 
            // tabSelectProjectile
            // 
            this.tabSelectProjectile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelectProjectile.Location = new System.Drawing.Point(6, 51);
            this.tabSelectProjectile.Name = "tabSelectProjectile";
            this.tabSelectProjectile.SelectedIndex = 0;
            this.tabSelectProjectile.Size = new System.Drawing.Size(247, 270);
            this.tabSelectProjectile.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(7, 28);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time:";
            // 
            // lblTimeUnits
            // 
            this.lblTimeUnits.AutoSize = true;
            this.lblTimeUnits.Location = new System.Drawing.Point(152, 28);
            this.lblTimeUnits.Name = "lblTimeUnits";
            this.lblTimeUnits.Size = new System.Drawing.Size(12, 13);
            this.lblTimeUnits.TabIndex = 0;
            this.lblTimeUnits.Text = "s";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(2, 664);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // groupAnimation
            // 
            this.groupAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAnimation.Controls.Add(this.btnPlot);
            this.groupAnimation.Controls.Add(this.upDownRefreshRate);
            this.groupAnimation.Controls.Add(this.radioNoAnimation);
            this.groupAnimation.Controls.Add(this.radioRefreshRate);
            this.groupAnimation.Controls.Add(this.radioRealTime);
            this.groupAnimation.Controls.Add(this.lblHzRefresh);
            this.groupAnimation.Location = new System.Drawing.Point(2, 563);
            this.groupAnimation.Name = "groupAnimation";
            this.groupAnimation.Size = new System.Drawing.Size(259, 95);
            this.groupAnimation.TabIndex = 1;
            this.groupAnimation.TabStop = false;
            this.groupAnimation.Text = "Animation";
            // 
            // btnPlot
            // 
            this.btnPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlot.Location = new System.Drawing.Point(163, 24);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(90, 62);
            this.btnPlot.TabIndex = 3;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // upDownRefreshRate
            // 
            this.upDownRefreshRate.Location = new System.Drawing.Point(30, 43);
            this.upDownRefreshRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownRefreshRate.Name = "upDownRefreshRate";
            this.upDownRefreshRate.Size = new System.Drawing.Size(67, 20);
            this.upDownRefreshRate.TabIndex = 2;
            this.upDownRefreshRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownRefreshRate.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // radioNoAnimation
            // 
            this.radioNoAnimation.AutoSize = true;
            this.radioNoAnimation.Location = new System.Drawing.Point(10, 69);
            this.radioNoAnimation.Name = "radioNoAnimation";
            this.radioNoAnimation.Size = new System.Drawing.Size(87, 17);
            this.radioNoAnimation.TabIndex = 0;
            this.radioNoAnimation.TabStop = true;
            this.radioNoAnimation.Text = "No animation";
            this.radioNoAnimation.UseVisualStyleBackColor = true;
            // 
            // radioRefreshRate
            // 
            this.radioRefreshRate.AutoSize = true;
            this.radioRefreshRate.Location = new System.Drawing.Point(10, 45);
            this.radioRefreshRate.Name = "radioRefreshRate";
            this.radioRefreshRate.Size = new System.Drawing.Size(14, 13);
            this.radioRefreshRate.TabIndex = 0;
            this.radioRefreshRate.TabStop = true;
            this.radioRefreshRate.UseVisualStyleBackColor = true;
            // 
            // radioRealTime
            // 
            this.radioRealTime.AutoSize = true;
            this.radioRealTime.Checked = true;
            this.radioRealTime.Location = new System.Drawing.Point(10, 20);
            this.radioRealTime.Name = "radioRealTime";
            this.radioRealTime.Size = new System.Drawing.Size(69, 17);
            this.radioRealTime.TabIndex = 0;
            this.radioRealTime.TabStop = true;
            this.radioRealTime.Text = "Real time";
            this.radioRealTime.UseVisualStyleBackColor = true;
            // 
            // lblHzRefresh
            // 
            this.lblHzRefresh.AutoSize = true;
            this.lblHzRefresh.Location = new System.Drawing.Point(103, 45);
            this.lblHzRefresh.Name = "lblHzRefresh";
            this.lblHzRefresh.Size = new System.Drawing.Size(55, 13);
            this.lblHzRefresh.TabIndex = 0;
            this.lblHzRefresh.Text = "Hz refresh";
            // 
            // groupAddProjectile
            // 
            this.groupAddProjectile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAddProjectile.Controls.Add(this.btnAddProjectile);
            this.groupAddProjectile.Controls.Add(this.comboColour);
            this.groupAddProjectile.Controls.Add(this.lblColour);
            this.groupAddProjectile.Controls.Add(this.tabProjectileType);
            this.groupAddProjectile.Location = new System.Drawing.Point(3, 3);
            this.groupAddProjectile.Name = "groupAddProjectile";
            this.groupAddProjectile.Size = new System.Drawing.Size(259, 221);
            this.groupAddProjectile.TabIndex = 0;
            this.groupAddProjectile.TabStop = false;
            this.groupAddProjectile.Text = "Add Projectile";
            // 
            // btnAddProjectile
            // 
            this.btnAddProjectile.Location = new System.Drawing.Point(9, 189);
            this.btnAddProjectile.Name = "btnAddProjectile";
            this.btnAddProjectile.Size = new System.Drawing.Size(247, 23);
            this.btnAddProjectile.TabIndex = 3;
            this.btnAddProjectile.Text = "Add Projectile";
            this.btnAddProjectile.UseVisualStyleBackColor = true;
            this.btnAddProjectile.Click += new System.EventHandler(this.BtnAddProjectile_Click);
            // 
            // comboColour
            // 
            this.comboColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColour.FormattingEnabled = true;
            this.comboColour.Items.AddRange(new object[] {
            "Black",
            "Blue",
            "Green",
            "Red",
            "Magenta"});
            this.comboColour.Location = new System.Drawing.Point(90, 162);
            this.comboColour.Name = "comboColour";
            this.comboColour.Size = new System.Drawing.Size(159, 21);
            this.comboColour.TabIndex = 2;
            // 
            // lblColour
            // 
            this.lblColour.AutoSize = true;
            this.lblColour.Location = new System.Drawing.Point(44, 165);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(40, 13);
            this.lblColour.TabIndex = 1;
            this.lblColour.Text = "Colour:";
            // 
            // tabProjectileType
            // 
            this.tabProjectileType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProjectileType.Controls.Add(this.tabSpeedAngle);
            this.tabProjectileType.Controls.Add(this.tabComponents);
            this.tabProjectileType.Controls.Add(this.tabEnergy);
            this.tabProjectileType.Location = new System.Drawing.Point(6, 19);
            this.tabProjectileType.Multiline = true;
            this.tabProjectileType.Name = "tabProjectileType";
            this.tabProjectileType.SelectedIndex = 0;
            this.tabProjectileType.Size = new System.Drawing.Size(247, 141);
            this.tabProjectileType.TabIndex = 0;
            // 
            // tabSpeedAngle
            // 
            this.tabSpeedAngle.Controls.Add(this.upDownG);
            this.tabSpeedAngle.Controls.Add(this.upDownInitHeight);
            this.tabSpeedAngle.Controls.Add(this.upDownAngle);
            this.tabSpeedAngle.Controls.Add(this.upDownSpeed);
            this.tabSpeedAngle.Controls.Add(this.lblGUnits);
            this.tabSpeedAngle.Controls.Add(this.lblG);
            this.tabSpeedAngle.Controls.Add(this.lblHeightUnits);
            this.tabSpeedAngle.Controls.Add(this.lblInitHeight);
            this.tabSpeedAngle.Controls.Add(this.lblAngleUnits);
            this.tabSpeedAngle.Controls.Add(this.lblAngle);
            this.tabSpeedAngle.Controls.Add(this.lblSpeedUnits);
            this.tabSpeedAngle.Controls.Add(this.lblSpeed);
            this.tabSpeedAngle.Location = new System.Drawing.Point(4, 22);
            this.tabSpeedAngle.Name = "tabSpeedAngle";
            this.tabSpeedAngle.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpeedAngle.Size = new System.Drawing.Size(239, 115);
            this.tabSpeedAngle.TabIndex = 0;
            this.tabSpeedAngle.Text = "Speed / Angle";
            this.tabSpeedAngle.UseVisualStyleBackColor = true;
            // 
            // upDownG
            // 
            this.upDownG.DecimalPlaces = 1;
            this.upDownG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownG.Location = new System.Drawing.Point(80, 84);
            this.upDownG.Name = "upDownG";
            this.upDownG.Size = new System.Drawing.Size(76, 20);
            this.upDownG.TabIndex = 1;
            this.upDownG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownG.Value = new decimal(new int[] {
            98,
            0,
            0,
            65536});
            // 
            // upDownInitHeight
            // 
            this.upDownInitHeight.DecimalPlaces = 1;
            this.upDownInitHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownInitHeight.Location = new System.Drawing.Point(80, 58);
            this.upDownInitHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownInitHeight.Name = "upDownInitHeight";
            this.upDownInitHeight.Size = new System.Drawing.Size(76, 20);
            this.upDownInitHeight.TabIndex = 1;
            this.upDownInitHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // upDownAngle
            // 
            this.upDownAngle.DecimalPlaces = 1;
            this.upDownAngle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownAngle.Location = new System.Drawing.Point(80, 32);
            this.upDownAngle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownAngle.Name = "upDownAngle";
            this.upDownAngle.Size = new System.Drawing.Size(76, 20);
            this.upDownAngle.TabIndex = 1;
            this.upDownAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownAngle.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // upDownSpeed
            // 
            this.upDownSpeed.DecimalPlaces = 1;
            this.upDownSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownSpeed.Location = new System.Drawing.Point(80, 6);
            this.upDownSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownSpeed.Name = "upDownSpeed";
            this.upDownSpeed.Size = new System.Drawing.Size(76, 20);
            this.upDownSpeed.TabIndex = 1;
            this.upDownSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGUnits
            // 
            this.lblGUnits.AutoSize = true;
            this.lblGUnits.Location = new System.Drawing.Point(162, 86);
            this.lblGUnits.Name = "lblGUnits";
            this.lblGUnits.Size = new System.Drawing.Size(28, 13);
            this.lblGUnits.TabIndex = 0;
            this.lblGUnits.Text = "m/s²";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(58, 86);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(16, 13);
            this.lblG.TabIndex = 0;
            this.lblG.Text = "g:";
            // 
            // lblHeightUnits
            // 
            this.lblHeightUnits.AutoSize = true;
            this.lblHeightUnits.Location = new System.Drawing.Point(162, 60);
            this.lblHeightUnits.Name = "lblHeightUnits";
            this.lblHeightUnits.Size = new System.Drawing.Size(15, 13);
            this.lblHeightUnits.TabIndex = 0;
            this.lblHeightUnits.Text = "m";
            // 
            // lblInitHeight
            // 
            this.lblInitHeight.AutoSize = true;
            this.lblInitHeight.Location = new System.Drawing.Point(13, 60);
            this.lblInitHeight.Name = "lblInitHeight";
            this.lblInitHeight.Size = new System.Drawing.Size(61, 13);
            this.lblInitHeight.TabIndex = 0;
            this.lblInitHeight.Text = "Init. Height:";
            // 
            // lblAngleUnits
            // 
            this.lblAngleUnits.AutoSize = true;
            this.lblAngleUnits.Location = new System.Drawing.Point(162, 34);
            this.lblAngleUnits.Name = "lblAngleUnits";
            this.lblAngleUnits.Size = new System.Drawing.Size(11, 13);
            this.lblAngleUnits.TabIndex = 0;
            this.lblAngleUnits.Text = "°\r\n";
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(37, 34);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(37, 13);
            this.lblAngle.TabIndex = 0;
            this.lblAngle.Text = "Angle:";
            // 
            // lblSpeedUnits
            // 
            this.lblSpeedUnits.AutoSize = true;
            this.lblSpeedUnits.Location = new System.Drawing.Point(162, 8);
            this.lblSpeedUnits.Name = "lblSpeedUnits";
            this.lblSpeedUnits.Size = new System.Drawing.Size(25, 13);
            this.lblSpeedUnits.TabIndex = 0;
            this.lblSpeedUnits.Text = "m/s";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(33, 8);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "Speed:";
            // 
            // tabComponents
            // 
            this.tabComponents.Location = new System.Drawing.Point(4, 22);
            this.tabComponents.Name = "tabComponents";
            this.tabComponents.Padding = new System.Windows.Forms.Padding(3);
            this.tabComponents.Size = new System.Drawing.Size(239, 115);
            this.tabComponents.TabIndex = 1;
            this.tabComponents.Text = "Components";
            this.tabComponents.UseVisualStyleBackColor = true;
            // 
            // tabEnergy
            // 
            this.tabEnergy.Location = new System.Drawing.Point(4, 22);
            this.tabEnergy.Name = "tabEnergy";
            this.tabEnergy.Size = new System.Drawing.Size(239, 115);
            this.tabEnergy.TabIndex = 2;
            this.tabEnergy.Text = "Energy";
            this.tabEnergy.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // itemFile
            // 
            this.itemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportPreset,
            this.btnExportPreset,
            this.toolStripSeparator1,
            this.btnImportBackground,
            this.btnExportGraph});
            this.itemFile.Name = "itemFile";
            this.itemFile.Size = new System.Drawing.Size(37, 20);
            this.itemFile.Text = "File";
            // 
            // btnImportPreset
            // 
            this.btnImportPreset.Name = "btnImportPreset";
            this.btnImportPreset.Size = new System.Drawing.Size(186, 22);
            this.btnImportPreset.Text = "Import Preset...";
            // 
            // btnExportPreset
            // 
            this.btnExportPreset.Name = "btnExportPreset";
            this.btnExportPreset.Size = new System.Drawing.Size(186, 22);
            this.btnExportPreset.Text = "Export Preset...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // btnImportBackground
            // 
            this.btnImportBackground.Name = "btnImportBackground";
            this.btnImportBackground.Size = new System.Drawing.Size(186, 22);
            this.btnImportBackground.Text = "Import Background...";
            // 
            // btnExportGraph
            // 
            this.btnExportGraph.Name = "btnExportGraph";
            this.btnExportGraph.Size = new System.Drawing.Size(186, 22);
            this.btnExportGraph.Text = "Export Graph...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 714);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Projectile Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            this.groupCurrentValues.ResumeLayout(false);
            this.groupCurrentValues.PerformLayout();
            this.groupAnimation.ResumeLayout(false);
            this.groupAnimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownRefreshRate)).EndInit();
            this.groupAddProjectile.ResumeLayout(false);
            this.groupAddProjectile.PerformLayout();
            this.tabProjectileType.ResumeLayout(false);
            this.tabSpeedAngle.ResumeLayout(false);
            this.tabSpeedAngle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSpeed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBoxPlot;
        private System.Windows.Forms.GroupBox groupAddProjectile;
        private System.Windows.Forms.TabControl tabProjectileType;
        private System.Windows.Forms.TabPage tabSpeedAngle;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblInitHeight;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TabPage tabComponents;
        private System.Windows.Forms.TabPage tabEnergy;
        private System.Windows.Forms.NumericUpDown upDownG;
        private System.Windows.Forms.NumericUpDown upDownInitHeight;
        private System.Windows.Forms.NumericUpDown upDownAngle;
        private System.Windows.Forms.NumericUpDown upDownSpeed;
        private System.Windows.Forms.Label lblGUnits;
        private System.Windows.Forms.Label lblHeightUnits;
        private System.Windows.Forms.Label lblAngleUnits;
        private System.Windows.Forms.Label lblSpeedUnits;
        private System.Windows.Forms.ComboBox comboColour;
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.Button btnAddProjectile;
        private System.Windows.Forms.GroupBox groupAnimation;
        private System.Windows.Forms.NumericUpDown upDownRefreshRate;
        private System.Windows.Forms.RadioButton radioNoAnimation;
        private System.Windows.Forms.RadioButton radioRefreshRate;
        private System.Windows.Forms.RadioButton radioRealTime;
        private System.Windows.Forms.Label lblHzRefresh;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupCurrentValues;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeUnits;
        private System.Windows.Forms.TabControl tabSelectProjectile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemFile;
        private System.Windows.Forms.ToolStripMenuItem btnImportPreset;
        private System.Windows.Forms.ToolStripMenuItem btnExportPreset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnImportBackground;
        private System.Windows.Forms.ToolStripMenuItem btnExportGraph;
    }
}

