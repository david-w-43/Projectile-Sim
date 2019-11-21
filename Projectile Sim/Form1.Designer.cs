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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewMagnitudeDirection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewEnergies = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
            this.groupCurrentValues = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabSelectProjectile = new System.Windows.Forms.TabControl();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeUnits = new System.Windows.Forms.Label();
            this.groupAddProjectile = new System.Windows.Forms.GroupBox();
            this.btnAddProjectile = new System.Windows.Forms.Button();
            this.comboColour = new System.Windows.Forms.ComboBox();
            this.lblColour = new System.Windows.Forms.Label();
            this.tabProjectileType = new System.Windows.Forms.TabControl();
            this.tabSpeedAngle = new System.Windows.Forms.TabPage();
            this.upDownG1 = new System.Windows.Forms.NumericUpDown();
            this.upDownInitHeight1 = new System.Windows.Forms.NumericUpDown();
            this.upDownAngle1 = new System.Windows.Forms.NumericUpDown();
            this.upDownSpeed1 = new System.Windows.Forms.NumericUpDown();
            this.lblGUnits = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblHeightUnits = new System.Windows.Forms.Label();
            this.lblInitHeight = new System.Windows.Forms.Label();
            this.lblAngleUnits = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.lblSpeedUnits = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tabComponents = new System.Windows.Forms.TabPage();
            this.upDownG2 = new System.Windows.Forms.NumericUpDown();
            this.upDownInitHeight2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.upDownVVelocity = new System.Windows.Forms.NumericUpDown();
            this.upDownHVelocity = new System.Windows.Forms.NumericUpDown();
            this.lblVelocityUnits = new System.Windows.Forms.Label();
            this.lblVelCloseBracket = new System.Windows.Forms.Label();
            this.lblVelOpenBracket = new System.Windows.Forms.Label();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.tabEnergy = new System.Windows.Forms.TabPage();
            this.upDownG3 = new System.Windows.Forms.NumericUpDown();
            this.upDownMass = new System.Windows.Forms.NumericUpDown();
            this.upDownEnergy = new System.Windows.Forms.NumericUpDown();
            this.upDownInitHeight3 = new System.Windows.Forms.NumericUpDown();
            this.upDownAngle3 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.groupPlotOptions = new System.Windows.Forms.GroupBox();
            this.upDownLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.lblDurationUnits2 = new System.Windows.Forms.Label();
            this.txtPlotTo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupScales = new System.Windows.Forms.GroupBox();
            this.upDownVertical = new System.Windows.Forms.NumericUpDown();
            this.upDownHorizontal = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnPlot = new System.Windows.Forms.Button();
            this.groupAnimation = new System.Windows.Forms.GroupBox();
            this.animationProgressBar = new System.Windows.Forms.ProgressBar();
            this.upDownTimescale = new System.Windows.Forms.NumericUpDown();
            this.radioNoAnimation = new System.Windows.Forms.RadioButton();
            this.radioAnimated = new System.Windows.Forms.RadioButton();
            this.btnPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportPreset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrightenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
            this.groupCurrentValues.SuspendLayout();
            this.groupAddProjectile.SuspendLayout();
            this.tabProjectileType.SuspendLayout();
            this.tabSpeedAngle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSpeed1)).BeginInit();
            this.tabComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownVVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHVelocity)).BeginInit();
            this.tabEnergy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAngle3)).BeginInit();
            this.groupPlotOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLineWidth)).BeginInit();
            this.groupScales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHorizontal)).BeginInit();
            this.groupAnimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownTimescale)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreset,
            this.btnBackground,
            this.btnView,
            this.btnExportGraph,
            this.btnSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnView
            // 
            this.btnView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewComponent,
            this.btnViewMagnitudeDirection,
            this.btnViewEnergies});
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(44, 20);
            this.btnView.Text = "View";
            // 
            // btnViewComponent
            // 
            this.btnViewComponent.Checked = true;
            this.btnViewComponent.CheckOnClick = true;
            this.btnViewComponent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnViewComponent.Name = "btnViewComponent";
            this.btnViewComponent.Size = new System.Drawing.Size(191, 22);
            this.btnViewComponent.Text = "Component";
            this.btnViewComponent.Click += new System.EventHandler(this.HandleTabStyleChange);
            // 
            // btnViewMagnitudeDirection
            // 
            this.btnViewMagnitudeDirection.Name = "btnViewMagnitudeDirection";
            this.btnViewMagnitudeDirection.Size = new System.Drawing.Size(191, 22);
            this.btnViewMagnitudeDirection.Text = "Magnitude / Direction";
            this.btnViewMagnitudeDirection.Click += new System.EventHandler(this.HandleTabStyleChange);
            // 
            // btnViewEnergies
            // 
            this.btnViewEnergies.CheckOnClick = true;
            this.btnViewEnergies.Name = "btnViewEnergies";
            this.btnViewEnergies.Size = new System.Drawing.Size(191, 22);
            this.btnViewEnergies.Text = "Energies";
            this.btnViewEnergies.Click += new System.EventHandler(this.HandleTabStyleChange);
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(70, 20);
            this.btnSettings.Text = "Settings...";
            this.btnSettings.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPause);
            this.splitContainer1.Panel2.Controls.Add(this.groupPlotOptions);
            this.splitContainer1.Panel2.Controls.Add(this.groupScales);
            this.splitContainer1.Panel2.Controls.Add(this.btnPlot);
            this.splitContainer1.Panel2.Controls.Add(this.groupAnimation);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 83;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(884, 637);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.SplitterIncrement = 5;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxPlot);
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.groupCurrentValues);
            this.splitContainer2.Panel2.Controls.Add(this.groupAddProjectile);
            this.splitContainer2.Panel2MinSize = 50;
            this.splitContainer2.Size = new System.Drawing.Size(884, 550);
            this.splitContainer2.SplitterDistance = 648;
            this.splitContainer2.SplitterIncrement = 5;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // pictureBoxPlot
            // 
            this.pictureBoxPlot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPlot.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPlot.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPlot.Name = "pictureBoxPlot";
            this.pictureBoxPlot.Size = new System.Drawing.Size(648, 550);
            this.pictureBoxPlot.TabIndex = 2;
            this.pictureBoxPlot.TabStop = false;
            // 
            // groupCurrentValues
            // 
            this.groupCurrentValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCurrentValues.Controls.Add(this.btnDelete);
            this.groupCurrentValues.Controls.Add(this.tabSelectProjectile);
            this.groupCurrentValues.Controls.Add(this.txtTime);
            this.groupCurrentValues.Controls.Add(this.lblTime);
            this.groupCurrentValues.Controls.Add(this.lblTimeUnits);
            this.groupCurrentValues.Location = new System.Drawing.Point(3, 257);
            this.groupCurrentValues.Name = "groupCurrentValues";
            this.groupCurrentValues.Size = new System.Drawing.Size(226, 290);
            this.groupCurrentValues.TabIndex = 1;
            this.groupCurrentValues.TabStop = false;
            this.groupCurrentValues.Text = "Current Values";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(6, 261);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(214, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tabSelectProjectile
            // 
            this.tabSelectProjectile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelectProjectile.Location = new System.Drawing.Point(6, 45);
            this.tabSelectProjectile.Name = "tabSelectProjectile";
            this.tabSelectProjectile.SelectedIndex = 0;
            this.tabSelectProjectile.Size = new System.Drawing.Size(214, 209);
            this.tabSelectProjectile.TabIndex = 2;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(44, 19);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 1;
            this.txtTime.TabStop = false;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(5, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time:";
            // 
            // lblTimeUnits
            // 
            this.lblTimeUnits.AutoSize = true;
            this.lblTimeUnits.Location = new System.Drawing.Point(150, 22);
            this.lblTimeUnits.Name = "lblTimeUnits";
            this.lblTimeUnits.Size = new System.Drawing.Size(12, 13);
            this.lblTimeUnits.TabIndex = 0;
            this.lblTimeUnits.Text = "s";
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
            this.groupAddProjectile.Size = new System.Drawing.Size(226, 248);
            this.groupAddProjectile.TabIndex = 0;
            this.groupAddProjectile.TabStop = false;
            this.groupAddProjectile.Text = "Add Projectile";
            // 
            // btnAddProjectile
            // 
            this.btnAddProjectile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProjectile.Location = new System.Drawing.Point(6, 219);
            this.btnAddProjectile.Name = "btnAddProjectile";
            this.btnAddProjectile.Size = new System.Drawing.Size(214, 23);
            this.btnAddProjectile.TabIndex = 7;
            this.btnAddProjectile.Text = "Add Projectile";
            this.btnAddProjectile.UseVisualStyleBackColor = true;
            this.btnAddProjectile.Click += new System.EventHandler(this.BtnAddProjectile_Click);
            // 
            // comboColour
            // 
            this.comboColour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboColour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboColour.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColour.FormattingEnabled = true;
            this.comboColour.Items.AddRange(new object[] {
            "Black",
            "Blue",
            "Green",
            "Magenta",
            "Red"});
            this.comboColour.Location = new System.Drawing.Point(87, 192);
            this.comboColour.Name = "comboColour";
            this.comboColour.Size = new System.Drawing.Size(126, 21);
            this.comboColour.TabIndex = 6;
            // 
            // lblColour
            // 
            this.lblColour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColour.AutoSize = true;
            this.lblColour.Location = new System.Drawing.Point(41, 195);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(40, 13);
            this.lblColour.TabIndex = 1;
            this.lblColour.Text = "Colour:";
            // 
            // tabProjectileType
            // 
            this.tabProjectileType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProjectileType.Controls.Add(this.tabSpeedAngle);
            this.tabProjectileType.Controls.Add(this.tabComponents);
            this.tabProjectileType.Controls.Add(this.tabEnergy);
            this.tabProjectileType.Location = new System.Drawing.Point(6, 19);
            this.tabProjectileType.Multiline = true;
            this.tabProjectileType.Name = "tabProjectileType";
            this.tabProjectileType.SelectedIndex = 0;
            this.tabProjectileType.Size = new System.Drawing.Size(214, 167);
            this.tabProjectileType.TabIndex = 0;
            // 
            // tabSpeedAngle
            // 
            this.tabSpeedAngle.Controls.Add(this.upDownG1);
            this.tabSpeedAngle.Controls.Add(this.upDownInitHeight1);
            this.tabSpeedAngle.Controls.Add(this.upDownAngle1);
            this.tabSpeedAngle.Controls.Add(this.upDownSpeed1);
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
            this.tabSpeedAngle.Size = new System.Drawing.Size(206, 141);
            this.tabSpeedAngle.TabIndex = 0;
            this.tabSpeedAngle.Text = "Speed / Angle";
            this.tabSpeedAngle.UseVisualStyleBackColor = true;
            // 
            // upDownG1
            // 
            this.upDownG1.DecimalPlaces = 2;
            this.upDownG1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownG1.Location = new System.Drawing.Point(92, 84);
            this.upDownG1.Name = "upDownG1";
            this.upDownG1.Size = new System.Drawing.Size(76, 20);
            this.upDownG1.TabIndex = 4;
            this.upDownG1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownG1.Value = new decimal(new int[] {
            98,
            0,
            0,
            65536});
            // 
            // upDownInitHeight1
            // 
            this.upDownInitHeight1.DecimalPlaces = 2;
            this.upDownInitHeight1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownInitHeight1.Location = new System.Drawing.Point(92, 58);
            this.upDownInitHeight1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownInitHeight1.Name = "upDownInitHeight1";
            this.upDownInitHeight1.Size = new System.Drawing.Size(76, 20);
            this.upDownInitHeight1.TabIndex = 3;
            this.upDownInitHeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // upDownAngle1
            // 
            this.upDownAngle1.DecimalPlaces = 2;
            this.upDownAngle1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownAngle1.Location = new System.Drawing.Point(92, 32);
            this.upDownAngle1.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.upDownAngle1.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.upDownAngle1.Name = "upDownAngle1";
            this.upDownAngle1.Size = new System.Drawing.Size(76, 20);
            this.upDownAngle1.TabIndex = 2;
            this.upDownAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownAngle1.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // upDownSpeed1
            // 
            this.upDownSpeed1.DecimalPlaces = 2;
            this.upDownSpeed1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownSpeed1.Location = new System.Drawing.Point(92, 6);
            this.upDownSpeed1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownSpeed1.Name = "upDownSpeed1";
            this.upDownSpeed1.Size = new System.Drawing.Size(76, 20);
            this.upDownSpeed1.TabIndex = 1;
            this.upDownSpeed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGUnits
            // 
            this.lblGUnits.AutoSize = true;
            this.lblGUnits.Location = new System.Drawing.Point(174, 86);
            this.lblGUnits.Name = "lblGUnits";
            this.lblGUnits.Size = new System.Drawing.Size(28, 13);
            this.lblGUnits.TabIndex = 0;
            this.lblGUnits.Text = "m/s²";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(70, 86);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(16, 13);
            this.lblG.TabIndex = 0;
            this.lblG.Text = "g:";
            // 
            // lblHeightUnits
            // 
            this.lblHeightUnits.AutoSize = true;
            this.lblHeightUnits.Location = new System.Drawing.Point(174, 60);
            this.lblHeightUnits.Name = "lblHeightUnits";
            this.lblHeightUnits.Size = new System.Drawing.Size(15, 13);
            this.lblHeightUnits.TabIndex = 0;
            this.lblHeightUnits.Text = "m";
            // 
            // lblInitHeight
            // 
            this.lblInitHeight.AutoSize = true;
            this.lblInitHeight.Location = new System.Drawing.Point(25, 60);
            this.lblInitHeight.Name = "lblInitHeight";
            this.lblInitHeight.Size = new System.Drawing.Size(61, 13);
            this.lblInitHeight.TabIndex = 0;
            this.lblInitHeight.Text = "Init. Height:";
            // 
            // lblAngleUnits
            // 
            this.lblAngleUnits.AutoSize = true;
            this.lblAngleUnits.Location = new System.Drawing.Point(174, 34);
            this.lblAngleUnits.Name = "lblAngleUnits";
            this.lblAngleUnits.Size = new System.Drawing.Size(11, 13);
            this.lblAngleUnits.TabIndex = 0;
            this.lblAngleUnits.Text = "°\r\n";
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(49, 34);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(37, 13);
            this.lblAngle.TabIndex = 0;
            this.lblAngle.Text = "Angle:";
            // 
            // lblSpeedUnits
            // 
            this.lblSpeedUnits.AutoSize = true;
            this.lblSpeedUnits.Location = new System.Drawing.Point(174, 8);
            this.lblSpeedUnits.Name = "lblSpeedUnits";
            this.lblSpeedUnits.Size = new System.Drawing.Size(25, 13);
            this.lblSpeedUnits.TabIndex = 0;
            this.lblSpeedUnits.Text = "m/s";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(45, 8);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "Speed:";
            // 
            // tabComponents
            // 
            this.tabComponents.Controls.Add(this.upDownG2);
            this.tabComponents.Controls.Add(this.upDownInitHeight2);
            this.tabComponents.Controls.Add(this.label1);
            this.tabComponents.Controls.Add(this.label2);
            this.tabComponents.Controls.Add(this.label3);
            this.tabComponents.Controls.Add(this.label4);
            this.tabComponents.Controls.Add(this.upDownVVelocity);
            this.tabComponents.Controls.Add(this.upDownHVelocity);
            this.tabComponents.Controls.Add(this.lblVelocityUnits);
            this.tabComponents.Controls.Add(this.lblVelCloseBracket);
            this.tabComponents.Controls.Add(this.lblVelOpenBracket);
            this.tabComponents.Controls.Add(this.lblVelocity);
            this.tabComponents.Location = new System.Drawing.Point(4, 22);
            this.tabComponents.Name = "tabComponents";
            this.tabComponents.Padding = new System.Windows.Forms.Padding(3);
            this.tabComponents.Size = new System.Drawing.Size(206, 141);
            this.tabComponents.TabIndex = 1;
            this.tabComponents.Text = "Components";
            this.tabComponents.UseVisualStyleBackColor = true;
            // 
            // upDownG2
            // 
            this.upDownG2.DecimalPlaces = 2;
            this.upDownG2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownG2.Location = new System.Drawing.Point(92, 84);
            this.upDownG2.Name = "upDownG2";
            this.upDownG2.Size = new System.Drawing.Size(76, 20);
            this.upDownG2.TabIndex = 4;
            this.upDownG2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownG2.Value = new decimal(new int[] {
            98,
            0,
            0,
            65536});
            // 
            // upDownInitHeight2
            // 
            this.upDownInitHeight2.DecimalPlaces = 2;
            this.upDownInitHeight2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownInitHeight2.Location = new System.Drawing.Point(92, 58);
            this.upDownInitHeight2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownInitHeight2.Name = "upDownInitHeight2";
            this.upDownInitHeight2.Size = new System.Drawing.Size(76, 20);
            this.upDownInitHeight2.TabIndex = 3;
            this.upDownInitHeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "m/s²";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "g:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "m";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Init. Height:";
            // 
            // upDownVVelocity
            // 
            this.upDownVVelocity.DecimalPlaces = 2;
            this.upDownVVelocity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownVVelocity.Location = new System.Drawing.Point(92, 32);
            this.upDownVVelocity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownVVelocity.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.upDownVVelocity.Name = "upDownVVelocity";
            this.upDownVVelocity.Size = new System.Drawing.Size(76, 20);
            this.upDownVVelocity.TabIndex = 2;
            this.upDownVVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // upDownHVelocity
            // 
            this.upDownHVelocity.DecimalPlaces = 2;
            this.upDownHVelocity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownHVelocity.Location = new System.Drawing.Point(92, 6);
            this.upDownHVelocity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownHVelocity.Name = "upDownHVelocity";
            this.upDownHVelocity.Size = new System.Drawing.Size(76, 20);
            this.upDownHVelocity.TabIndex = 1;
            this.upDownHVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVelocityUnits
            // 
            this.lblVelocityUnits.AutoSize = true;
            this.lblVelocityUnits.Location = new System.Drawing.Point(177, 28);
            this.lblVelocityUnits.Name = "lblVelocityUnits";
            this.lblVelocityUnits.Size = new System.Drawing.Size(25, 13);
            this.lblVelocityUnits.TabIndex = 52;
            this.lblVelocityUnits.Text = "m/s";
            // 
            // lblVelCloseBracket
            // 
            this.lblVelCloseBracket.AutoSize = true;
            this.lblVelCloseBracket.Font = new System.Drawing.Font("Calibri Light", 28F);
            this.lblVelCloseBracket.Location = new System.Drawing.Point(159, 4);
            this.lblVelCloseBracket.Name = "lblVelCloseBracket";
            this.lblVelCloseBracket.Size = new System.Drawing.Size(31, 46);
            this.lblVelCloseBracket.TabIndex = 49;
            this.lblVelCloseBracket.Text = ")";
            // 
            // lblVelOpenBracket
            // 
            this.lblVelOpenBracket.AutoSize = true;
            this.lblVelOpenBracket.Font = new System.Drawing.Font("Calibri Light", 28F);
            this.lblVelOpenBracket.Location = new System.Drawing.Point(73, 4);
            this.lblVelOpenBracket.Name = "lblVelOpenBracket";
            this.lblVelOpenBracket.Size = new System.Drawing.Size(31, 46);
            this.lblVelOpenBracket.TabIndex = 48;
            this.lblVelOpenBracket.Text = "(";
            // 
            // lblVelocity
            // 
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Location = new System.Drawing.Point(28, 14);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(47, 13);
            this.lblVelocity.TabIndex = 47;
            this.lblVelocity.Text = "Velocity:";
            // 
            // tabEnergy
            // 
            this.tabEnergy.Controls.Add(this.upDownG3);
            this.tabEnergy.Controls.Add(this.upDownMass);
            this.tabEnergy.Controls.Add(this.upDownEnergy);
            this.tabEnergy.Controls.Add(this.upDownInitHeight3);
            this.tabEnergy.Controls.Add(this.upDownAngle3);
            this.tabEnergy.Controls.Add(this.label14);
            this.tabEnergy.Controls.Add(this.label5);
            this.tabEnergy.Controls.Add(this.label12);
            this.tabEnergy.Controls.Add(this.label13);
            this.tabEnergy.Controls.Add(this.label6);
            this.tabEnergy.Controls.Add(this.label11);
            this.tabEnergy.Controls.Add(this.label7);
            this.tabEnergy.Controls.Add(this.label8);
            this.tabEnergy.Controls.Add(this.label9);
            this.tabEnergy.Controls.Add(this.label10);
            this.tabEnergy.Location = new System.Drawing.Point(4, 22);
            this.tabEnergy.Name = "tabEnergy";
            this.tabEnergy.Size = new System.Drawing.Size(206, 141);
            this.tabEnergy.TabIndex = 2;
            this.tabEnergy.Text = "Energy";
            this.tabEnergy.UseVisualStyleBackColor = true;
            // 
            // upDownG3
            // 
            this.upDownG3.DecimalPlaces = 2;
            this.upDownG3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownG3.Location = new System.Drawing.Point(92, 110);
            this.upDownG3.Name = "upDownG3";
            this.upDownG3.Size = new System.Drawing.Size(76, 20);
            this.upDownG3.TabIndex = 5;
            this.upDownG3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownG3.Value = new decimal(new int[] {
            98,
            0,
            0,
            65536});
            // 
            // upDownMass
            // 
            this.upDownMass.DecimalPlaces = 2;
            this.upDownMass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownMass.Location = new System.Drawing.Point(92, 32);
            this.upDownMass.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownMass.Name = "upDownMass";
            this.upDownMass.Size = new System.Drawing.Size(76, 20);
            this.upDownMass.TabIndex = 2;
            this.upDownMass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // upDownEnergy
            // 
            this.upDownEnergy.DecimalPlaces = 2;
            this.upDownEnergy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownEnergy.Location = new System.Drawing.Point(92, 6);
            this.upDownEnergy.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownEnergy.Name = "upDownEnergy";
            this.upDownEnergy.Size = new System.Drawing.Size(76, 20);
            this.upDownEnergy.TabIndex = 1;
            this.upDownEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // upDownInitHeight3
            // 
            this.upDownInitHeight3.DecimalPlaces = 2;
            this.upDownInitHeight3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownInitHeight3.Location = new System.Drawing.Point(92, 84);
            this.upDownInitHeight3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.upDownInitHeight3.Name = "upDownInitHeight3";
            this.upDownInitHeight3.Size = new System.Drawing.Size(76, 20);
            this.upDownInitHeight3.TabIndex = 4;
            this.upDownInitHeight3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // upDownAngle3
            // 
            this.upDownAngle3.DecimalPlaces = 2;
            this.upDownAngle3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownAngle3.Location = new System.Drawing.Point(92, 58);
            this.upDownAngle3.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.upDownAngle3.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.upDownAngle3.Name = "upDownAngle3";
            this.upDownAngle3.Size = new System.Drawing.Size(76, 20);
            this.upDownAngle3.TabIndex = 3;
            this.upDownAngle3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownAngle3.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(174, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "kg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "m/s²";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(174, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "J";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(51, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Mass:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "g:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Kinetic Energy:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "m";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Init. Height:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "°\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Angle:";
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(727, 0);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(48, 83);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "II";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // groupPlotOptions
            // 
            this.groupPlotOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPlotOptions.Controls.Add(this.upDownLineWidth);
            this.groupPlotOptions.Controls.Add(this.label21);
            this.groupPlotOptions.Controls.Add(this.lblDurationUnits2);
            this.groupPlotOptions.Controls.Add(this.txtPlotTo);
            this.groupPlotOptions.Controls.Add(this.label18);
            this.groupPlotOptions.Controls.Add(this.label15);
            this.groupPlotOptions.Location = new System.Drawing.Point(190, 3);
            this.groupPlotOptions.Name = "groupPlotOptions";
            this.groupPlotOptions.Size = new System.Drawing.Size(200, 77);
            this.groupPlotOptions.TabIndex = 3;
            this.groupPlotOptions.TabStop = false;
            this.groupPlotOptions.Text = "Plot Options";
            // 
            // upDownLineWidth
            // 
            this.upDownLineWidth.Location = new System.Drawing.Point(71, 44);
            this.upDownLineWidth.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownLineWidth.Name = "upDownLineWidth";
            this.upDownLineWidth.Size = new System.Drawing.Size(82, 20);
            this.upDownLineWidth.TabIndex = 42;
            this.upDownLineWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(159, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 13);
            this.label21.TabIndex = 41;
            this.label21.Text = "px";
            // 
            // lblDurationUnits2
            // 
            this.lblDurationUnits2.AutoSize = true;
            this.lblDurationUnits2.Location = new System.Drawing.Point(159, 21);
            this.lblDurationUnits2.Name = "lblDurationUnits2";
            this.lblDurationUnits2.Size = new System.Drawing.Size(12, 13);
            this.lblDurationUnits2.TabIndex = 41;
            this.lblDurationUnits2.Text = "s";
            // 
            // txtPlotTo
            // 
            this.txtPlotTo.Location = new System.Drawing.Point(71, 18);
            this.txtPlotTo.Name = "txtPlotTo";
            this.txtPlotTo.Size = new System.Drawing.Size(82, 20);
            this.txtPlotTo.TabIndex = 1;
            this.txtPlotTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlotTo.TextChanged += new System.EventHandler(this.txtPlotToValidate);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Line width:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Plot to:";
            // 
            // groupScales
            // 
            this.groupScales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupScales.Controls.Add(this.upDownVertical);
            this.groupScales.Controls.Add(this.upDownHorizontal);
            this.groupScales.Controls.Add(this.label20);
            this.groupScales.Controls.Add(this.label19);
            this.groupScales.Controls.Add(this.label17);
            this.groupScales.Controls.Add(this.label16);
            this.groupScales.Location = new System.Drawing.Point(3, 3);
            this.groupScales.Name = "groupScales";
            this.groupScales.Size = new System.Drawing.Size(181, 77);
            this.groupScales.TabIndex = 2;
            this.groupScales.TabStop = false;
            this.groupScales.Text = "Scales";
            // 
            // upDownVertical
            // 
            this.upDownVertical.DecimalPlaces = 2;
            this.upDownVertical.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upDownVertical.Location = new System.Drawing.Point(73, 45);
            this.upDownVertical.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.upDownVertical.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownVertical.Name = "upDownVertical";
            this.upDownVertical.Size = new System.Drawing.Size(79, 20);
            this.upDownVertical.TabIndex = 11;
            this.upDownVertical.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // upDownHorizontal
            // 
            this.upDownHorizontal.DecimalPlaces = 2;
            this.upDownHorizontal.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upDownHorizontal.Location = new System.Drawing.Point(73, 19);
            this.upDownHorizontal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.upDownHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownHorizontal.Name = "upDownHorizontal";
            this.upDownHorizontal.Size = new System.Drawing.Size(79, 20);
            this.upDownHorizontal.TabIndex = 11;
            this.upDownHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(158, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "m";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(158, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "m";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Vertical:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Horizontal:";
            // 
            // btnPlot
            // 
            this.btnPlot.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPlot.Enabled = false;
            this.btnPlot.Location = new System.Drawing.Point(781, 0);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(103, 83);
            this.btnPlot.TabIndex = 5;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // groupAnimation
            // 
            this.groupAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAnimation.Controls.Add(this.animationProgressBar);
            this.groupAnimation.Controls.Add(this.upDownTimescale);
            this.groupAnimation.Controls.Add(this.radioNoAnimation);
            this.groupAnimation.Controls.Add(this.radioAnimated);
            this.groupAnimation.Location = new System.Drawing.Point(396, 3);
            this.groupAnimation.Name = "groupAnimation";
            this.groupAnimation.Size = new System.Drawing.Size(325, 77);
            this.groupAnimation.TabIndex = 4;
            this.groupAnimation.TabStop = false;
            this.groupAnimation.Text = "Animation";
            // 
            // animationProgressBar
            // 
            this.animationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationProgressBar.Location = new System.Drawing.Point(6, 47);
            this.animationProgressBar.MarqueeAnimationSpeed = 10;
            this.animationProgressBar.Maximum = 1000;
            this.animationProgressBar.Name = "animationProgressBar";
            this.animationProgressBar.Size = new System.Drawing.Size(313, 30);
            this.animationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.animationProgressBar.TabIndex = 7;
            // 
            // upDownTimescale
            // 
            this.upDownTimescale.DecimalPlaces = 2;
            this.upDownTimescale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownTimescale.Location = new System.Drawing.Point(81, 19);
            this.upDownTimescale.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownTimescale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upDownTimescale.Name = "upDownTimescale";
            this.upDownTimescale.Size = new System.Drawing.Size(55, 20);
            this.upDownTimescale.TabIndex = 2;
            this.upDownTimescale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioNoAnimation
            // 
            this.radioNoAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioNoAnimation.AutoSize = true;
            this.radioNoAnimation.Location = new System.Drawing.Point(153, 19);
            this.radioNoAnimation.Name = "radioNoAnimation";
            this.radioNoAnimation.Size = new System.Drawing.Size(87, 17);
            this.radioNoAnimation.TabIndex = 0;
            this.radioNoAnimation.TabStop = true;
            this.radioNoAnimation.Text = "No animation";
            this.radioNoAnimation.UseVisualStyleBackColor = true;
            // 
            // radioAnimated
            // 
            this.radioAnimated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioAnimated.AutoSize = true;
            this.radioAnimated.Checked = true;
            this.radioAnimated.Location = new System.Drawing.Point(6, 19);
            this.radioAnimated.Name = "radioAnimated";
            this.radioAnimated.Size = new System.Drawing.Size(76, 17);
            this.radioAnimated.TabIndex = 0;
            this.radioAnimated.TabStop = true;
            this.radioAnimated.Text = "Timescale:";
            this.radioAnimated.UseVisualStyleBackColor = true;
            // 
            // btnPreset
            // 
            this.btnPreset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportPreset,
            this.btnExportPreset});
            this.btnPreset.Name = "btnPreset";
            this.btnPreset.Size = new System.Drawing.Size(51, 20);
            this.btnPreset.Text = "Preset";
            // 
            // btnBackground
            // 
            this.btnBackground.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBrightenImage,
            this.btnImportBackground,
            this.removeBackgroundToolStripMenuItem});
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(83, 20);
            this.btnBackground.Text = "Background";
            // 
            // btnImportPreset
            // 
            this.btnImportPreset.Name = "btnImportPreset";
            this.btnImportPreset.Size = new System.Drawing.Size(180, 22);
            this.btnImportPreset.Text = "Import Preset...";
            // 
            // btnExportPreset
            // 
            this.btnExportPreset.Name = "btnExportPreset";
            this.btnExportPreset.Size = new System.Drawing.Size(180, 22);
            this.btnExportPreset.Text = "Export Preset...";
            // 
            // btnImportBackground
            // 
            this.btnImportBackground.Name = "btnImportBackground";
            this.btnImportBackground.Size = new System.Drawing.Size(186, 22);
            this.btnImportBackground.Text = "Import Background...";
            // 
            // btnBrightenImage
            // 
            this.btnBrightenImage.CheckOnClick = true;
            this.btnBrightenImage.Name = "btnBrightenImage";
            this.btnBrightenImage.Size = new System.Drawing.Size(186, 22);
            this.btnBrightenImage.Text = "Brighten Image";
            // 
            // removeBackgroundToolStripMenuItem
            // 
            this.removeBackgroundToolStripMenuItem.Name = "removeBackgroundToolStripMenuItem";
            this.removeBackgroundToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.removeBackgroundToolStripMenuItem.Text = "Remove Background";
            // 
            // btnExportGraph
            // 
            this.btnExportGraph.Name = "btnExportGraph";
            this.btnExportGraph.Size = new System.Drawing.Size(97, 20);
            this.btnExportGraph.Text = "Export Graph...";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnPlot;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnPause;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 540);
            this.Name = "Form1";
            this.Text = "Projectile Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
            this.groupCurrentValues.ResumeLayout(false);
            this.groupCurrentValues.PerformLayout();
            this.groupAddProjectile.ResumeLayout(false);
            this.groupAddProjectile.PerformLayout();
            this.tabProjectileType.ResumeLayout(false);
            this.tabSpeedAngle.ResumeLayout(false);
            this.tabSpeedAngle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSpeed1)).EndInit();
            this.tabComponents.ResumeLayout(false);
            this.tabComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownVVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHVelocity)).EndInit();
            this.tabEnergy.ResumeLayout(false);
            this.tabEnergy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownG3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInitHeight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAngle3)).EndInit();
            this.groupPlotOptions.ResumeLayout(false);
            this.groupPlotOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownLineWidth)).EndInit();
            this.groupScales.ResumeLayout(false);
            this.groupScales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownHorizontal)).EndInit();
            this.groupAnimation.ResumeLayout(false);
            this.groupAnimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownTimescale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBoxPlot;
        private System.Windows.Forms.GroupBox groupCurrentValues;
        private System.Windows.Forms.TabControl tabSelectProjectile;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeUnits;
        private System.Windows.Forms.GroupBox groupAddProjectile;
        private System.Windows.Forms.Button btnAddProjectile;
        private System.Windows.Forms.ComboBox comboColour;
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.TabControl tabProjectileType;
        private System.Windows.Forms.TabPage tabSpeedAngle;
        private System.Windows.Forms.NumericUpDown upDownG1;
        private System.Windows.Forms.NumericUpDown upDownInitHeight1;
        private System.Windows.Forms.NumericUpDown upDownAngle1;
        private System.Windows.Forms.NumericUpDown upDownSpeed1;
        private System.Windows.Forms.Label lblGUnits;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblHeightUnits;
        private System.Windows.Forms.Label lblInitHeight;
        private System.Windows.Forms.Label lblAngleUnits;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label lblSpeedUnits;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TabPage tabComponents;
        private System.Windows.Forms.NumericUpDown upDownG2;
        private System.Windows.Forms.NumericUpDown upDownInitHeight2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown upDownVVelocity;
        private System.Windows.Forms.NumericUpDown upDownHVelocity;
        private System.Windows.Forms.Label lblVelocityUnits;
        private System.Windows.Forms.Label lblVelCloseBracket;
        private System.Windows.Forms.Label lblVelOpenBracket;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.TabPage tabEnergy;
        private System.Windows.Forms.NumericUpDown upDownG3;
        private System.Windows.Forms.NumericUpDown upDownMass;
        private System.Windows.Forms.NumericUpDown upDownEnergy;
        private System.Windows.Forms.NumericUpDown upDownInitHeight3;
        private System.Windows.Forms.NumericUpDown upDownAngle3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupAnimation;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.NumericUpDown upDownTimescale;
        private System.Windows.Forms.RadioButton radioNoAnimation;
        private System.Windows.Forms.RadioButton radioAnimated;
        private System.Windows.Forms.GroupBox groupScales;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.NumericUpDown upDownHorizontal;
        private System.Windows.Forms.NumericUpDown upDownVertical;
        private System.Windows.Forms.GroupBox groupPlotOptions;
        private System.Windows.Forms.TextBox txtPlotTo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblDurationUnits2;
        private System.Windows.Forms.NumericUpDown upDownLineWidth;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ToolStripMenuItem btnView;
        private System.Windows.Forms.ToolStripMenuItem btnViewComponent;
        private System.Windows.Forms.ToolStripMenuItem btnViewMagnitudeDirection;
        private System.Windows.Forms.ToolStripMenuItem btnViewEnergies;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ProgressBar animationProgressBar;
        private System.Windows.Forms.ToolStripMenuItem btnPreset;
        private System.Windows.Forms.ToolStripMenuItem btnImportPreset;
        private System.Windows.Forms.ToolStripMenuItem btnExportPreset;
        private System.Windows.Forms.ToolStripMenuItem btnBackground;
        private System.Windows.Forms.ToolStripMenuItem btnBrightenImage;
        private System.Windows.Forms.ToolStripMenuItem btnImportBackground;
        private System.Windows.Forms.ToolStripMenuItem removeBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExportGraph;
    }
}

