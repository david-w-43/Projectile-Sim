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

        public delegate void HandlePlotComplete();
        public HandlePlotComplete plotCompleteDelegate;

        public delegate void HandleUpdateTime(double time);
        public HandleUpdateTime updateTimeDelegate;

        public delegate void HandleUpdateTabs(ref List<Projectile> projectiles);
        public HandleUpdateTabs updateTabsDelegate;

        //public Simulation simulation = new Simulation(); //Empty constructor

        //Simulation.canvasUpdated += new Simulation.UpdatePictureBox(this.UpdatePictureBox);
        public Simulation simulation = new Simulation();

        public ComponentTab[] componentTabs;
        public MagnitudeTab[] magnitudeTabs;

        //private List<Projectile> projectiles = new List<Projectile>();

        public Form1()
        {
            InitializeComponent();
            plotCompleteDelegate = new HandlePlotComplete(MethodPlotComplete);
            updateTabsDelegate = new HandleUpdateTabs(MethodUpdateTabs);
            updateTimeDelegate = new HandleUpdateTime(MethodUpdateTime);
        }

        private void MethodUpdateTime(double time)
        {
            txtTime.Text = time.ToString("F3");
        }

        private void MethodUpdateTabs(ref List<Projectile> projectiles)
        {
            foreach (var projectile in projectiles)
            {
                //If it is a component-style tab
                TabPage tab = tabSelectProjectile.TabPages[tabSelectProjectile.TabPages.IndexOfKey(projectile.colour.Name)];

                TextBox txtHPos = (TextBox)tab.Controls.Find("txtHPos", true).First(); //Horizontal position
                txtHPos.Text = projectile.displacement.horizontal.ToString("F3");

                TextBox txtVPos = (TextBox)tab.Controls.Find("txtVPos", true).First(); //Vertical position
                txtVPos.Text = projectile.displacement.vertical.ToString("F3");

                TextBox txtHVel = (TextBox)tab.Controls.Find("txtHVel", true).First(); //Vertical position
                txtHVel.Text = projectile.velocity.horizontal.ToString("F3");

                TextBox txtVVel = (TextBox)tab.Controls.Find("txtVVel", true).First(); //Vertical position
                txtVVel.Text = projectile.velocity.vertical.ToString("F3");
            }
        }

        private void MethodPlotComplete()
        {
            //Allow the window to be resized
            Program.form1.FormBorderStyle = FormBorderStyle.Sizable;
            
            //Re-enable controls
            groupAddProjectile.Enabled = true;
            groupPlotOptions.Enabled = true;
            groupScales.Enabled = true;
            groupAnimation.Enabled = true;

            //Set buttons as appropriate
            btnPause.Enabled = false;
            btnPause.Text = "II";
            btnPlot.Enabled = true;
        }

        private void BtnAddProjectile_Click(object sender, EventArgs e)
        {
            //Enable plot and delete buttons
            btnPlot.Enabled = true;
            btnDelete.Enabled = true;

            //Get colour from combobox
            String colourName = comboColour.Text;
            Color colour = Color.FromName(colourName);
            //Remove colour
            comboColour.Items.Remove(colourName);
            if (comboColour.Items.Count != 0) //If there are still colours left
            {
                comboColour.SelectedItem = comboColour.Items[0]; //Go to next colour in list
            } else
            {
                btnAddProjectile.Enabled = false; //Disable add projectile button
            }


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
                    angle = (double)upDownAngle3.Value * (Math.PI / 180);

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
            txtDuration.Text = simulation.projectiles[index].duration.ToString("F3");

            Control txtRange = componentTabs[index].Controls.Find("txtRange", true).First();
            txtRange.Text = simulation.projectiles[index].range.ToString("F3");

            Control txtHApex = componentTabs[index].Controls.Find("txtHApex", true).First();
            txtHApex.Text = simulation.projectiles[index].apex.horizontal.ToString("F3");

            Control txtVApex = componentTabs[index].Controls.Find("txtVApex", true).First();
            txtVApex.Text = simulation.projectiles[index].apex.vertical.ToString("F3");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabSelectProjectile.TabPages.Clear();
            upDownHorizontal.Value = pictureBoxPlot.Width;
            upDownVertical.Value = pictureBoxPlot.Height;
            comboColour.SelectedItem = comboColour.Items[0];
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            //Enable buttons as appropriate
            btnPause.Enabled = true;
            btnPlot.Enabled = false;

            //Disable groups
            groupAddProjectile.Enabled = false;
            groupPlotOptions.Enabled = false;
            groupScales.Enabled = false;
            groupAnimation.Enabled = false;

            //Stop the window from being resized
            Program.form1.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Clear picturebox
            pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);

            //Calculates and sets scales in pixels per metre
            double hScale = (double)((pictureBoxPlot.Width - Properties.Settings.Default.margin)/ upDownHorizontal.Value);
            double vScale = (double)((pictureBoxPlot.Height - Properties.Settings.Default.margin) / upDownVertical.Value);
            simulation.SetScales(hScale, vScale);
            simulation.SetLineWidth((int)upDownLineWidth.Value);

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

            if (double.TryParse(txtPlotTo.Text, out double toTime))
            {
                simulation.Plot(timescale, toTime);
            }
            else
            {
                simulation.Plot(timescale);
            }

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
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TabPage tab = tabSelectProjectile.SelectedTab;
            //Removes projectile from simulation
            simulation.RemoveProjectile(tab.Text);
            comboColour.Items.Add(tab.Text);

            //Re-enables add projectile button if not already
            btnAddProjectile.Enabled = true;

            //Removes tab from control
            tabSelectProjectile.TabPages.Remove(tab);
            if (tabSelectProjectile.TabPages.Count == 0) { btnPlot.Enabled = false; btnDelete.Enabled = false; }
        }

        private void txtPlotToValidate (object sender, EventArgs e)
        {
            //If it is empty, set text to complete
            if (txtPlotTo.Text == "") { txtPlotTo.Text = "End"; }
        }

        private void btnExportGraph_Click(object sender, EventArgs e)
        {
            //Code to save the image displayed
            DialogResult result = MessageBox.Show("Use a transparent background?", "Background", MessageBoxButtons.YesNo);
            bool transparency = false;
            if (result == DialogResult.Yes) { transparency = true; } else { transparency = false; }

            Bitmap image = (Bitmap)pictureBoxPlot.Image;
            image.MakeTransparent(Color.FromArgb(0, 0, 0, 0)); //Make blank pixels transparent
            if (!transparency) //If user does not want transparency
            {
                //Cycle through colours
                for (int row = 0; row < image.Height; row++)
                {
                    for (int col = 0; col < image.Width; col++)
                    {
                        if (image.GetPixel(col, row) == Color.Transparent) //If the pixel is blank
                        {
                            image.SetPixel(col, row, Color.White); //Set it to white
                        }
                    }
                }
            }


            SaveFileDialog dialog = new SaveFileDialog(); //Define dialog
            dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to save to
            string extension = filepath.Split("."[0]).Last().ToUpper(); //Parse the file extension
            switch (extension) //Save with the appropriate format
            {
                case "BMP":
                    image.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case "JPG":
                    image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case "PNG":
                    image.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                default:
                    MessageBox.Show("Invalid file type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
            }
        }
    }
}