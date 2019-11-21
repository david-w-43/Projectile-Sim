using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectile_Sim
{
    public partial class TabContents : UserControl
    {
        public TabDisplayType displayType;

        public TabContents(TabDisplayType type)
        {
            InitializeComponent();
            ChangeType(type);
        }

        public void ChangeType(TabDisplayType type)
        {
            displayType = type;
            string tag = "";

            //Set the search tag as appropriate
            switch (displayType)
            {
                case TabDisplayType.Component:
                    tag = "Component";
                    break;
                case TabDisplayType.Magnitude:
                    tag = "Magnitude";
                    break;
                case TabDisplayType.Energy:
                    tag = "Energy";
                    break;
            }

            //Loop through controls, setting visible property
            for (int i = 0; i < Controls.Count; i++)
            {
                if ((string)Controls[i].Tag == tag)
                {
                    Controls[i].Visible = true;
                }
                else if ((string)Controls[i].Tag != "Common")
                {
                    Controls[i].Visible = false;
                }
            }
        }


    }
}
