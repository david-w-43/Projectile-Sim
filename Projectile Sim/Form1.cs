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
    public enum TabDisplayType { Component, Magnitude, Energy };

    public partial class Form1 : Form
    {
        const int maxProjectiles = 8;

        private Bitmap customBackground = null;

        public delegate void HandlePlotComplete();
        public HandlePlotComplete plotCompleteDelegate;

        public delegate void HandleUpdateTime(double time);
        public HandleUpdateTime updateTimeDelegate;

        public delegate void HandleUpdateTabs(ref List<Projectile> projectiles);
        public HandleUpdateTabs updateTabsDelegate;

        //public Simulation simulation = new Simulation(); //Empty constructor

        
        private TabDisplayType displayType = 0; //Default to component

        //Simulation.canvasUpdated += new Simulation.UpdatePictureBox(this.UpdatePictureBox);

        public Simulation simulation = new Simulation();

        public TabContents[] ProjectileTabs;

        //private List<Projectile> projectiles = new List<Projectile>();

        public Form1()
        {
            InitializeComponent();
            plotCompleteDelegate = new HandlePlotComplete(MethodPlotComplete);
            updateTabsDelegate = new HandleUpdateTabs(MethodUpdateTabs);
            updateTimeDelegate = new HandleUpdateTime(MethodUpdateTime);
            ProjectileTabs = new TabContents[maxProjectiles];
        }

        private void MethodUpdateTime(double time)
        {
            //Update time textbox
            txtTime.Text = time.ToString("F3");

            //Update progress bar
            int value = (int)((time / simulation.maxDuration) * animationProgressBar.Maximum);
            
            //Constrain to max
            if (value > 1000) { value = animationProgressBar.Maximum; }
            UpdateProgressBarWorkaround(value);
        }

        private void UpdateProgressBarWorkaround(int value)
        {
            //Works stop animation by decrementing value
            if (value < animationProgressBar.Maximum)
            {
                //Set one above correct value
                animationProgressBar.Value = value + 1;
            }
            else
            {
                //Special case, set the value to max
                value = animationProgressBar.Maximum;
            }
            //Immediately set it to the correct value, == previous value - 1
            animationProgressBar.Value = value;
        }

        private void MethodUpdateTabs(ref List<Projectile> projectiles)
        {
            foreach (var projectile in projectiles)
            {
                //Gets the tab with the same name as the projectile
                TabPage tab = tabSelectProjectile.TabPages[tabSelectProjectile.TabPages.IndexOfKey(projectile.colour.Name)];

                //Gets the control collection of the current tab
                Control.ControlCollection controlCollection = ((TabContents)tab.Controls[0]).Controls;

                switch (((TabContents)tab.Controls[0]).displayType)
                {
                    case TabDisplayType.Component:
                        //Get the textbox
                        TextBox txtHPos = (TextBox)tab.Controls.Find("txtHPos", true).First(); //Horizontal position
                        //Set the text
                        txtHPos.Text = projectile.displacement.horizontal.ToString("F3");

                        TextBox txtVPos = (TextBox)tab.Controls.Find("txtVPos", true).First(); //Vertical position
                        txtVPos.Text = projectile.displacement.vertical.ToString("F3");

                        TextBox txtHVel = (TextBox)tab.Controls.Find("txtHVel", true).First(); //Vertical position
                        txtHVel.Text = projectile.velocity.horizontal.ToString("F3");

                        TextBox txtVVel = (TextBox)tab.Controls.Find("txtVVel", true).First(); //Vertical position
                        txtVVel.Text = projectile.velocity.vertical.ToString("F3");
                        break;
                    case TabDisplayType.Magnitude:
                        TextBox txtMagPos = (TextBox)tab.Controls.Find("txtMagPos", true).First(); //Mag of position
                        txtMagPos.Text = projectile.displacement.magnitude.ToString("F3");

                        TextBox txtAnglePos = (TextBox)tab.Controls.Find("txtAnglePos", true).First(); //Direction of position
                        txtAnglePos.Text = (projectile.displacement.direction * (180 / Math.PI)).ToString("F3");

                        TextBox txtMagVel = (TextBox)tab.Controls.Find("txtMagVel", true).First(); //Mag of velocity
                        txtMagVel.Text = projectile.velocity.magnitude.ToString("F3");

                        TextBox txtAngleVel = (TextBox)tab.Controls.Find("txtAngleVel", true).First(); //Direction of velocity
                        txtAngleVel.Text = (projectile.velocity.direction * (180 / Math.PI)).ToString("F3");
                        break;
                    case TabDisplayType.Energy:
                        //Set the values for energy
                        break;
                }
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
            viewToolStripMenuItem.Enabled = true;
        }

        private void BtnAddProjectile_Click(object sender, EventArgs e)
        {
            ////Enable plot and delete buttons
            //btnPlot.Enabled = true;
            //btnDelete.Enabled = true;

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
            simulation.projectiles.Add(new Projectile(ProjectileType.component, colour, initVelocity, height, -g));

            //Add a tab
            AddTab();
        }

        private void AddTab()
        {
            TabPage newTab = new TabPage();
            int index = tabSelectProjectile.TabCount;
            Control.ControlCollection controlCollection;

            //Define new tab contents control with selected type
            ProjectileTabs[index] = new TabContents(displayType) { Dock = DockStyle.Fill };
            //Add the control to the tab
            newTab.Controls.Add(ProjectileTabs[index]);
            controlCollection = ProjectileTabs[index].Controls;

            //Set tab text and name to the colour
            newTab.Text = simulation.projectiles[index].colour.Name;
            newTab.Name = newTab.Text;
            tabSelectProjectile.TabPages.Add(newTab);
            tabSelectProjectile.SelectedIndex = index;

            //Common controls
            //Get control by "name"
            Control txtDuration = controlCollection.Find("txtDuration", true).First();
            txtDuration.Text = simulation.projectiles[index].duration.ToString("F3");

            Control txtRange = controlCollection.Find("txtRange", true).First();
            txtRange.Text = simulation.projectiles[index].range.ToString("F3");

            Control txtHApex = controlCollection.Find("txtHApex", true).First();
            txtHApex.Text = simulation.projectiles[index].apex.horizontal.ToString("F3");

            Control txtVApex = controlCollection.Find("txtVApex", true).First();
            txtVApex.Text = simulation.projectiles[index].apex.vertical.ToString("F3");


            HandleTabsChanged();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabSelectProjectile.TabPages.Clear();
            comboColour.SelectedItem = comboColour.Items[0];

            if (Properties.Settings.Default.useScales)
            {
                upDownHorizontal.Value = (decimal)Properties.Settings.Default.defaultXScale;
                upDownVertical.Value = (decimal)Properties.Settings.Default.defaultYScale;
            }
            else
            {
                upDownHorizontal.Value = pictureBoxPlot.Width;
                upDownVertical.Value = pictureBoxPlot.Height;
            }
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            //Enable buttons as appropriate
            btnPause.Enabled = true;
            btnPlot.Enabled = false;
            btnDelete.Enabled = false;
            viewToolStripMenuItem.Enabled = false;

            //Disable groups
            groupAddProjectile.Enabled = false;
            groupPlotOptions.Enabled = false;
            groupScales.Enabled = false;
            groupAnimation.Enabled = false;

            //Stop the window from being resized
            Program.form1.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Clear picturebox
            if (Object.Equals(customBackground, null))
            {
                pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);
            }
            else
            {
                pictureBoxPlot.Image = new Bitmap(customBackground);
            }

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
                viewToolStripMenuItem.Enabled = false;
            }
            else
            {
                btnPause.Text = "▶";
                simulation.Pause();
                viewToolStripMenuItem.Enabled = true;
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

            HandleTabsChanged();
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

            SaveFileDialog dialog = new SaveFileDialog(); //Define dialog
            dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to save to
            if (filepath != "") //If filepath not blank
            {
                string extension = filepath.Split("."[0]).Last().ToUpper(); //Parse the file extension

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

        private void btnExportPreset_Click(object sender, EventArgs e)
        {
            //Export a preset to an XML file, https://csharp.net-tutorials.com/xml/writing-xml-with-the-xmlwriter-class/

            //Get path to save to
            SaveFileDialog dialog = new SaveFileDialog(); //Define dialog
            dialog.Filter = "XML File (*.xml)|*.xml"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to save to

            if (filepath != "") //If the filepath is not blank
            {

                System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(filepath);

                writer.WriteStartDocument();
                writer.WriteStartElement("projectiles");

                foreach (var projectile in simulation.projectiles)
                {
                    writer.WriteStartElement("projectile");
                    writer.WriteAttributeString("colour", projectile.colour.Name);
                    string velocity, acceleration, displacement;
                    velocity = projectile.initVelocity.horizontal.ToString() + "," + projectile.initVelocity.vertical.ToString();
                    acceleration = projectile.initAcceleration.horizontal.ToString() + "," + projectile.initAcceleration.vertical.ToString();
                    displacement = projectile.initDisplacement.horizontal.ToString() + "," + projectile.initDisplacement.vertical.ToString();

                    writer.WriteAttributeString("velocity", velocity);
                    writer.WriteAttributeString("acceleration", acceleration);
                    writer.WriteAttributeString("displacement", displacement);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        private void btnImportBackground_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //Define dialog
            dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to save to

            customBackground = new Bitmap(filepath); //Create a new bitmap from the file
            if (filepath != "") //If the filepath is not blank
            {
                if (btnBrightenImage.Checked) //Only if the user wants to brighten their image
                {
                    for (int i = 0; i < customBackground.Width; i++)
                    {
                        for (int j = 0; j < customBackground.Height; j++)
                        {
                            //Get the colour of the pixel
                            Color fromImage = customBackground.GetPixel(i, j);

                            int R, G, B;
                            decimal factor = 1.5M;

                            //Increase the RGB values for the pixel, limited to 255 max
                            R = (int)(fromImage.R * factor); if (R > 255) { R = 255; }
                            G = (int)(fromImage.G * factor); if (G > 255) { G = 255; }
                            B = (int)(fromImage.B * factor); if (B > 255) { B = 255; }

                            //Set the new colour
                            Color result = Color.FromArgb(fromImage.A, R, G, B);
                            customBackground.SetPixel(i, j, result);
                        }
                    }
                }

                //Set the current image in the picturebox
                pictureBoxPlot.Image = customBackground;
            }
        }

        private void removeBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Remove the custom background
            customBackground = null;
            pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);
        }

        private void btnImportPreset_Click(object sender, EventArgs e)
        {
            //Import preset from XML file
            OpenFileDialog dialog = new OpenFileDialog(); //Define dialog
            dialog.Filter = "XML File (*.xml)|*.xml"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to open to

            if (filepath != "") //If the filepath is not blank
            {
                System.Xml.XmlReader reader = System.Xml.XmlReader.Create(filepath); //Open XML document for reading

                while (reader.Read())
                {
                    //If the current element is a projectile
                    if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "projectile")
                    {
                        //If there are attributes to read
                        if (reader.HasAttributes)
                        {
                            //Parse attributes from XML document
                            Color colour = Color.FromName(reader.GetAttribute("colour"));
                            string[] velocityComponents = reader.GetAttribute("velocity").Split(","[0]);
                            string[] accelerationComponents = reader.GetAttribute("acceleration").Split(","[0]);
                            string[] displacementComponents = reader.GetAttribute("displacement").Split(","[0]);

                            //Create vectors from components
                            Vector initVelocity = new Vector(VectorType.component, Double.Parse(velocityComponents[0]), Double.Parse(velocityComponents[1]));
                            Vector initDisplacement = new Vector(VectorType.component, Double.Parse(displacementComponents[0]), Double.Parse(displacementComponents[1]));
                            Vector initAcceleration = new Vector(VectorType.component, Double.Parse(accelerationComponents[0]), Double.Parse(accelerationComponents[1]));

                            //Define projectile to add
                            Projectile toAdd = new Projectile(ProjectileType.component, colour, initVelocity, initDisplacement.vertical, initAcceleration.vertical);

                            //Add the projectile to the simulation and add a tab for it
                            simulation.AddProjectile(toAdd);
                            AddTab();
                        }
                    }
                }
                HandleTabsChanged();
                reader.Dispose();
            }
        }

        private void HandleTabsChanged()
        //Runs when a tab is added or removed, sets buttons accordingly
        {
            if (tabSelectProjectile.TabPages.Count == 0)
            {
                btnPlot.Enabled = false; btnDelete.Enabled = false;
            }
            else
            {
                btnPlot.Enabled = true; btnDelete.Enabled = true;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(); //Defines settings form
            settings.ShowDialog(); //Show as a dialog box
            settings.Dispose(); //Dispose of resources used
        }

        private void HandleTabStyleChange(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            
            //Always check the item clicked
            btn.Checked = true;

            if (btn.Equals(btnViewComponent))
            {
                //Set the other items to unchecked
                btnViewMagnitudeDirection.Checked = btnViewEnergies.Checked = false;
                //Set the displayType var
                displayType = TabDisplayType.Component;
            }
            if (btn.Equals(btnViewMagnitudeDirection))
            {
                btnViewComponent.Checked = btnViewEnergies.Checked = false;
                displayType = TabDisplayType.Magnitude;
            }
            if (btn.Equals(btnViewEnergies))
            {
                btnViewComponent.Checked = btnViewMagnitudeDirection.Checked = false;
                displayType = TabDisplayType.Energy;
            }

            //For each tab
            foreach (TabPage tab in tabSelectProjectile.TabPages)
            {
                //Change the type of the control
                ((TabContents)tab.Controls[0]).ChangeType(displayType);
            }

        }
    }
}