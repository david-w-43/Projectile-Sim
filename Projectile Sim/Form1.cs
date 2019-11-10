using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;



namespace Projectile_Sim
{

    public partial class Form1 : Form
    {
        const int maxProjectiles = 8;


        //public Simulation simulation = new Simulation(); //Empty constructor

        //Simulation.canvasUpdated += new Simulation.UpdatePictureBox(this.UpdatePictureBox);
        public Simulation simulation = new Simulation();

        public ComponentTab[] componentTabs;
        public MagnitudeTab[] magnitudeTabs;

        //private List<Projectile> projectiles = new List<Projectile>();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAddProjectile_Click(object sender, EventArgs e)
        {
            //Get colour from combobox
            String colourName = comboColour.Text;
            Color colour = Color.FromName(colourName);
            comboColour.Items.Remove(colourName);
            comboColour.Text = null;

            //Defines common variables
            double height = 0, g = 0, speed, angle;
            Vector initVelocity = new Vector();
            
            //Depending on the current tab
            switch (tabProjectileType.SelectedTab.Text)
            {
                case "Speed / Angle":
                    //Get variables
                    speed = (double)upDownSpeed1.Value;
                    angle = (double)upDownAngle1.Value * (Math.PI/180);

                    //Create vector for initial velocity
                    initVelocity = new Vector(VectorType.magnitude, speed, angle);

                    //Sets height and g
                    height = (double)upDownInitHeight1.Value;
                    g = (double)upDownG1.Value;
                    break;
                case "Components":
                    double hVelocity = (double)upDownHVelocity.Value;
                    double vVelocity = (double)upDownVVelocity.Value;

                    initVelocity = new Vector(VectorType.component, hVelocity, vVelocity);

                    height = (double)upDownInitHeight2.Value;
                    g = (double)upDownG2.Value;
                    break;
                case "Energy":
                    //Find speed from energy and mass
                    speed = Math.Sqrt((double)(2 * upDownEnergy.Value) / (double)upDownMass.Value);
                    angle = (double)upDownAngle1.Value * (Math.PI / 180);

                    initVelocity = new Vector(VectorType.magnitude, speed, angle);

                    height = (double)upDownInitHeight3.Value;
                    g = (double)upDownG3.Value;
                    break;
            }

            //Adds projectile
            simulation.projectiles.Add(new Projectile(ProjectileType.component, colour, initVelocity, height, g));


            TabPage newTab = new TabPage();
            int index = tabSelectProjectile.TabCount;
            //if vector display style is component
            componentTabs = new ComponentTab[maxProjectiles]; //Initialise array
            //New control in array, docked to fill
            componentTabs[index] = new ComponentTab() { Dock = DockStyle.Fill };
            //Add control to the tab
            newTab.Controls.Add(componentTabs[index]);
            
            //Set tab text and name to the colour
            newTab.Text = colourName;
            newTab.Name = colourName;
            tabSelectProjectile.TabPages.Add(newTab);
            tabSelectProjectile.SelectedIndex = index;


            //Get control by "name"
            Control txtDuration = componentTabs[index].Controls.Find("txtDuration", true).First();
            txtDuration.Text = simulation.projectiles[index].duration.ToString("G5");

            Control txtRange = componentTabs[index].Controls.Find("txtRange", true).First();
            txtRange.Text = simulation.projectiles[index].range.ToString("G5");

            Control txtHApex = componentTabs[index].Controls.Find("txtHApex", true).First();
            txtHApex.Text = simulation.projectiles[index].apex.horizontal.ToString("G5");

            Control txtVApex = componentTabs[index].Controls.Find("txtVApex", true).First();
            txtVApex.Text = simulation.projectiles[index].apex.vertical.ToString("G5");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabSelectProjectile.TabPages.Clear();
            CalculateScales(null, null);
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {

            //Clear picturebox
            pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);

            double hScale = (double)upDownHorizontalScale.Value;
            double vScale = (double)upDownVerticalScale.Value;
            double timescale = 0;

            //Calls to start animation with specified timescale
            if (radioAnimated.Checked)
            {
                //simulation.StartAnimation(SimulationSpeed.Animated, (double)upDownTimescale.Value);
                
                timescale = (double)upDownTimescale.Value;
            }
            else if (radioNoAnimation.Checked)
            {
                //simulation.StartAnimation(SimulationSpeed.NoAnimation);
                timescale = 0;
            }
            
            simulation.Plot(timescale);
        }
        
        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (simulation.paused)
            {
                btnPause.Text = "II";
                simulation.Resume();
            }
            else
            {
                btnPause.Text = "▶";
                simulation.Pause();
            }
        }

        private void CalculateScales(object sender, EventArgs e)
        {
            //Called by picture box resizing or up/down values changing
            //Calculate scales in metres
            // (px) / (px/m) = m 
            txtWidth.Text = ((pictureBoxPlot.Width - Properties.Settings.Default.margin) / upDownHorizontalScale.Value).ToString("G5");
            txtHeight.Text = ((pictureBoxPlot.Height - Properties.Settings.Default.margin) / upDownVerticalScale.Value).ToString("G5");
            
            

            //Set the scale of the simulation
            simulation.SetScales((double)upDownHorizontalScale.Value, (double)upDownVerticalScale.Value);
        }
    }
}