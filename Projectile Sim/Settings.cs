using System;
using System.Windows.Forms;

namespace Projectile_Sim
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            var properties = Properties.Settings.Default;

            //Load current settings into controls
            upDownMarginOffset.Value = properties.margin;
            upDownDecimalPlaces.Value = properties.decimalPlaces;
            upDownFramerate.Value = properties.framerate;
            upDownXScale.Value = (decimal)properties.defaultXScale;
            upDownYScale.Value = (decimal)properties.defaultYScale;
            checkBoxUseScales.Checked = properties.useScales;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Check if values are valid or not
            bool valid = true;
            if (upDownMarginOffset.Value < 0) { valid = false; }
            if (upDownDecimalPlaces.Value < 0) { valid = false; }
            if (upDownFramerate.Value <= 0) { valid = false; }
            if (upDownXScale.Value <= 0 && checkBoxUseScales.Checked) { valid = false; }
            if (upDownYScale.Value <= 0 && checkBoxUseScales.Checked) { valid = false; }
            //If all is still valid, set properties as appropriate
            if (valid)
            {
                var properties = Properties.Settings.Default;

                properties.margin = (int)upDownMarginOffset.Value;
                properties.decimalPlaces = (int)upDownDecimalPlaces.Value;
                properties.framerate = (int)upDownFramerate.Value;
                properties.useScales = checkBoxUseScales.Checked;
                properties.defaultXScale = (double)upDownXScale.Value;
                properties.defaultYScale = (double)upDownYScale.Value;
            }

            Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
