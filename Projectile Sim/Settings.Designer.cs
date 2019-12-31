namespace Projectile_Sim
{
    partial class Settings
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.upDownMarginOffset = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.upDownXScale = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.upDownYScale = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxUseScales = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.upDownFramerate = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.upDownDecimalPlaces = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownXScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownYScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFramerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownDecimalPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(153, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(72, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Margin offset:";
            // 
            // upDownMarginOffset
            // 
            this.upDownMarginOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownMarginOffset.Location = new System.Drawing.Point(118, 12);
            this.upDownMarginOffset.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.upDownMarginOffset.Name = "upDownMarginOffset";
            this.upDownMarginOffset.Size = new System.Drawing.Size(67, 20);
            this.upDownMarginOffset.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Default x scale:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "m";
            // 
            // upDownXScale
            // 
            this.upDownXScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownXScale.Location = new System.Drawing.Point(118, 135);
            this.upDownXScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.upDownXScale.Name = "upDownXScale";
            this.upDownXScale.Size = new System.Drawing.Size(67, 20);
            this.upDownXScale.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "m";
            // 
            // upDownYScale
            // 
            this.upDownYScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownYScale.Location = new System.Drawing.Point(118, 161);
            this.upDownYScale.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.upDownYScale.Name = "upDownYScale";
            this.upDownYScale.Size = new System.Drawing.Size(67, 20);
            this.upDownYScale.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Default y scale:";
            // 
            // checkBoxUseScales
            // 
            this.checkBoxUseScales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUseScales.AutoSize = true;
            this.checkBoxUseScales.Location = new System.Drawing.Point(60, 112);
            this.checkBoxUseScales.Name = "checkBoxUseScales";
            this.checkBoxUseScales.Size = new System.Drawing.Size(113, 17);
            this.checkBoxUseScales.TabIndex = 3;
            this.checkBoxUseScales.Text = "Use default scales";
            this.checkBoxUseScales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxUseScales.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Framerate:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Hz";
            // 
            // upDownFramerate
            // 
            this.upDownFramerate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownFramerate.Location = new System.Drawing.Point(118, 64);
            this.upDownFramerate.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.upDownFramerate.Name = "upDownFramerate";
            this.upDownFramerate.Size = new System.Drawing.Size(67, 20);
            this.upDownFramerate.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Decimal Places:";
            // 
            // upDownDecimalPlaces
            // 
            this.upDownDecimalPlaces.Location = new System.Drawing.Point(118, 38);
            this.upDownDecimalPlaces.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownDecimalPlaces.Name = "upDownDecimalPlaces";
            this.upDownDecimalPlaces.Size = new System.Drawing.Size(67, 20);
            this.upDownDecimalPlaces.TabIndex = 1;
            // 
            // Settings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(240, 233);
            this.Controls.Add(this.checkBoxUseScales);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.upDownYScale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.upDownXScale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.upDownDecimalPlaces);
            this.Controls.Add(this.upDownFramerate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.upDownMarginOffset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upDownMarginOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownXScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownYScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFramerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownDecimalPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown upDownMarginOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown upDownXScale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown upDownYScale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxUseScales;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown upDownFramerate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown upDownDecimalPlaces;
    }
}