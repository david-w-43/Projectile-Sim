using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Load current settings into controls
            upDownMarginOffset.Value = Properties.Settings.Default.margin;
            upDownXScale.Value = (decimal)Properties.Settings.Default.defaultXScale;
            upDownYScale.Value = (decimal)Properties.Settings.Default.defaultYScale;

            //If not using scales, disable inputs
            checkBoxUseScales.Checked = Properties.Settings.Default.useScales;
            if (checkBoxUseScales.Checked)
            {
                upDownXScale.Enabled = upDownYScale.Enabled = true;
            }
            else
            {
                upDownXScale.Enabled = upDownYScale.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Check if values are valid or not
            bool valid = true;
            if (upDownMarginOffset.Value < 0) { valid = false; }
            if (upDownXScale.Value <= 0 && checkBoxUseScales.Checked) { valid = false; }
            if (upDownYScale.Value <= 0 && checkBoxUseScales.Checked) { valid = false; }
            //If all is still valid, set properties as appropriate
            if (valid)
            {
                var properties = Properties.Settings.Default;

                properties.margin = (int)upDownMarginOffset.Value;
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
