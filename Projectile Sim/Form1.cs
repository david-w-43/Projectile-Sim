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

        

        public Simulation simulation = new Simulation(); //Empty constructor

        //Simulation.canvasUpdated += new Simulation.UpdatePictureBox(this.UpdatePictureBox);

        public ComponentTab[] componentTabs;
        public MagnitudeTab[] magnitudeTabs;

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdatePictureBox(ref Bitmap bitmap)
        {
            try
            {
                Program.form1.pictureBoxPlot.Image = bitmap;
            }
            catch (Exception)
            {
                //do nothing
                //Fails because object is currently in use - updates are too frequent
            }
        }

        private void BtnAddProjectile_Click(object sender, EventArgs e)
        {
            //Get colour from combobox
            String colourName = comboColour.Text;
            Color colour = Color.FromName(colourName);
            comboColour.Items.Remove(colourName);
            comboColour.Text = null;
            
            //Depending on the current tab
            switch (tabProjectileType.SelectedTab.Text)
            {
                case "Speed / Angle":
                    double speed = (double)upDownSpeed.Value;
                    double angle = (double)upDownAngle.Value * (Math.PI/180);
                    double height = (double)upDownInitHeight.Value;
                    double g = (double)upDownG.Value;

                    Projectile toAdd = new Projectile(ProjectileType.speed, colour, speed, angle, height, g);


                    simulation.AddProjectile(new Projectile(ProjectileType.speed, colour, speed, angle, height, g));

                    break;
                case "Components":
                    break;
                case "Energy":
                    break;
            }
            
            
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
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            if (radioRealTime.Checked) { simulation.StartAnimation(ref pictureBoxPlot, SimulationSpeed.RealTime); }
            else if (radioNoAnimation.Checked) { simulation.StartAnimation(ref pictureBoxPlot, SimulationSpeed.NoAnimation); }
            else if (radioRefreshRate.Checked) { simulation.StartAnimation(ref pictureBoxPlot, SimulationSpeed.Custom, (double)upDownRefreshRate.Value); }
        }
    }
}