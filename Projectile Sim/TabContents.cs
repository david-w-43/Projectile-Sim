using System.Windows.Forms;

namespace Projectile_Sim
{
    public partial class TabContents : UserControl
    {
        // Public variable to store the current display style
        public TabDisplayType displayType;

        public TabContents(TabDisplayType type)
        {
            // Constructor, also set display type
            InitializeComponent();
            ChangeType(type);
        }

        public void ChangeType(TabDisplayType type)
        {
            displayType = type;

            // Initialises tag to search for
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
                    // If the tag matches, make it visible
                    Controls[i].Visible = true;
                }
                else if ((string)Controls[i].Tag != "Common")
                {
                    // Doesn't match, nor is it common, set to invisible
                    Controls[i].Visible = false;
                }
            }
        }
    }
}
