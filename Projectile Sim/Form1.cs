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

        #region Variables

        //Delegates and events
        public delegate void HandlePlotComplete();
        public HandlePlotComplete plotCompleteDelegate;

        public delegate void HandleUpdateTime(double time);
        public HandleUpdateTime updateTimeDelegate;

        public delegate void HandleUpdateTabs(ref List<Projectile> projectiles);
        public HandleUpdateTabs updateTabsDelegate;

        //Container for the custom background
        private Bitmap customBackground = null;

        //Stores the type of tab to be displayed
        private TabDisplayType displayType = 0; //Default to component

        //Instantiates simulation class
        public Simulation simulation = new Simulation();

        //Stores the tab pages
        private TabContents[] projectileTabs;

        #endregion

        public Form1()
        {
            InitializeComponent();
            plotCompleteDelegate = new HandlePlotComplete(MethodPlotComplete);
            updateTabsDelegate = new HandleUpdateTabs(MethodUpdateTabs);
            updateTimeDelegate = new HandleUpdateTime(MethodUpdateTime);
            projectileTabs = new TabContents[maxProjectiles];
        }

        private void MethodUpdateTime(double time)
        {
            //Update time textbox
            txtTime.Text = time.ToString("F" + Properties.Settings.Default.decimalPlaces);

            //Update progress bar
            int value = (int)((time / simulation.maxDuration) * animationProgressBar.Maximum);
            
            //Constrain to max
            if (value > 1000) { value = animationProgressBar.Maximum; }
            UpdateProgressBarWorkaround(value);
        }

        private void MethodUpdateTabs(ref List<Projectile> projectiles)
        {
            foreach (var projectile in projectiles)
            {
                //Gets the tab with the same name as the projectile
                TabPage tab = tabSelectProjectile.TabPages[tabSelectProjectile.TabPages.IndexOfKey(projectile.colour.Name)];

                //Gets the control collection of the current tab
                Control.ControlCollection controlCollection = ((TabContents)tab.Controls[0]).Controls;

                string formatString = "F" + Properties.Settings.Default.decimalPlaces.ToString();

                Vector displacement = projectile.GetDisplacement();
                Vector velocity = projectile.GetVelocity();
                double KE = projectile.GetKineticEnergy();
                double GPE = projectile.GetGPEnergy();

                switch (((TabContents)tab.Controls[0]).displayType)
                {
                    case TabDisplayType.Component:
                        //Get the textbox
                        TextBox txtHPos = (TextBox)tab.Controls.Find("txtHPos", true).First(); //Horizontal position
                        //Set the text
                        txtHPos.Text = displacement.horizontal.ToString(formatString);

                        TextBox txtVPos = (TextBox)tab.Controls.Find("txtVPos", true).First(); //Vertical position
                        txtVPos.Text = displacement.vertical.ToString(formatString);

                        TextBox txtHVel = (TextBox)tab.Controls.Find("txtHVel", true).First(); //Vertical position
                        txtHVel.Text = velocity.horizontal.ToString(formatString);

                        TextBox txtVVel = (TextBox)tab.Controls.Find("txtVVel", true).First(); //Vertical position
                        txtVVel.Text = velocity.vertical.ToString(formatString);
                        break;
                    case TabDisplayType.Magnitude:
                        TextBox txtMagPos = (TextBox)tab.Controls.Find("txtMagPos", true).First(); //Mag of position
                        txtMagPos.Text = displacement.magnitude.ToString(formatString);

                        TextBox txtAnglePos = (TextBox)tab.Controls.Find("txtAnglePos", true).First(); //Direction of position
                        txtAnglePos.Text = (displacement.direction * (180 / Math.PI)).ToString(formatString);

                        TextBox txtMagVel = (TextBox)tab.Controls.Find("txtMagVel", true).First(); //Mag of velocity
                        txtMagVel.Text = velocity.magnitude.ToString(formatString);

                        TextBox txtAngleVel = (TextBox)tab.Controls.Find("txtAngleVel", true).First(); //Direction of velocity
                        txtAngleVel.Text = (velocity.direction * (180 / Math.PI)).ToString(formatString);
                        break;
                    case TabDisplayType.Energy:
                        //Set the values for energy

                        TextBox txtKineticEnergy = (TextBox)tab.Controls.Find("txtKineticEnergy", true).First(); //Mag of position
                        txtKineticEnergy.Text = KE.ToString(formatString);

                        TextBox txtGPE = (TextBox)tab.Controls.Find("txtGPE", true).First(); //Mag of position
                        txtGPE.Text = GPE.ToString(formatString);

                        TextBox txtTotalEnergy = (TextBox)tab.Controls.Find("txtTotalEnergy", true).First(); //Mag of position
                        txtTotalEnergy.Text = (KE + GPE).ToString(formatString);

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
            tsiView.Enabled = true;
            btnDelete.Enabled = true;
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

        private void BtnAddProjectile_Click(object sender, EventArgs e)
        {
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
            double height = (double)upDownInitHeight.Value;
            double g = (double)upDownG.Value, speed, angle;
            double mass = (double)upDownMass.Value;

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
                    break;
                case "Components":
                    double hVelocity = (double)upDownHVelocity.Value;
                    double vVelocity = (double)upDownVVelocity.Value;

                    initVelocity = new Vector(VectorType.component, hVelocity, vVelocity);
                    break;
                case "Energy":
                    //Find speed from energy and mass
                    speed = Math.Sqrt((double)(2 * upDownEnergy.Value) / (double)upDownMass.Value);
                    angle = (double)upDownAngle3.Value * (Math.PI / 180);

                    initVelocity = new Vector(VectorType.magnitude, speed, angle);
                    break;
            }

            Vector initDisplacement = new Vector(VectorType.component, 0, height);
            Vector initAcceleration = new Vector(VectorType.component, 0, -g);

            //Adds projectile
            simulation.projectiles.Add(new Projectile(ProjectileType.component, colour, initVelocity, initDisplacement, initAcceleration, mass));

            //Add a tab
            AddTab();
        }

        private void AddTab()
        {
            TabPage newTab = new TabPage();
            int index = tabSelectProjectile.TabCount;
            Control.ControlCollection controlCollection;

            string formatString = "F" + Properties.Settings.Default.decimalPlaces.ToString();

            //Define new tab contents control with selected type
            projectileTabs[index] = new TabContents(displayType) { Dock = DockStyle.Fill };
            //Add the control to the tab
            newTab.Controls.Add(projectileTabs[index]);
            controlCollection = projectileTabs[index].Controls;

            //Set tab text and name to the colour
            newTab.Text = simulation.projectiles[index].colour.Name;
            newTab.Name = newTab.Text;
            tabSelectProjectile.TabPages.Add(newTab);
            tabSelectProjectile.SelectedIndex = index;

            //Common controls
            //Get control by "name"
            Control txtDuration = controlCollection.Find("txtDuration", true).First();
            txtDuration.Text = simulation.projectiles[index].duration.ToString(formatString);

            Control txtRange = controlCollection.Find("txtRange", true).First();
            txtRange.Text = simulation.projectiles[index].range.ToString(formatString);

            Control txtHApex = controlCollection.Find("txtHApex", true).First();
            txtHApex.Text = simulation.projectiles[index].apex.horizontal.ToString(formatString);

            Control txtVApex = controlCollection.Find("txtVApex", true).First();
            txtVApex.Text = simulation.projectiles[index].apex.vertical.ToString(formatString);

            Control txtMass = controlCollection.Find("txtMass", true).First();
            txtMass.Text = simulation.projectiles[index].mass.ToString(formatString);


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

            //Sets all upDown boxes to the correct number of decimal places
            List<NumericUpDown> upDownList = new List<NumericUpDown>();
            upDownList.AddRange(groupAddProjectile.Controls.OfType<NumericUpDown>());
            upDownList.AddRange(tabSpeedAngle.Controls.OfType<NumericUpDown>());
            upDownList.AddRange(tabComponents.Controls.OfType<NumericUpDown>());
            upDownList.AddRange(tabEnergy.Controls.OfType<NumericUpDown>());
            foreach (NumericUpDown upDown in upDownList)
            {
                upDown.DecimalPlaces = Properties.Settings.Default.decimalPlaces;
            }

        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            //Enable buttons as appropriate
            btnPause.Enabled = true;
            btnPlot.Enabled = false;
            btnDelete.Enabled = false;
            tsiView.Enabled = false;

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
                tsiView.Enabled = false;
            }
            else
            {
                btnPause.Text = "▶";
                simulation.Pause();
                tsiView.Enabled = true;
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

        private void tsiExportGraph_Click(object sender, EventArgs e)
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

        private void tsiExportPreset_Click(object sender, EventArgs e)
        {
            //Export a preset to an XML file, https://csharp.net-tutorials.com/xml/writing-xml-with-the-xmlwriter-class/

            //Get path to save to
            SaveFileDialog dialog = new SaveFileDialog(); //Define dialog
            dialog.Filter = "Projectile File (*.projectile)|*.projectile"; //Set filter
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
                    string velocity, acceleration, displacement, mass;
                    velocity = projectile.initVelocity.horizontal.ToString() + "," + projectile.initVelocity.vertical.ToString();
                    acceleration = projectile.initAcceleration.horizontal.ToString() + "," + projectile.initAcceleration.vertical.ToString();
                    displacement = projectile.initDisplacement.horizontal.ToString() + "," + projectile.initDisplacement.vertical.ToString();
                    mass = projectile.mass.ToString();

                    writer.WriteAttributeString("velocity", velocity);
                    writer.WriteAttributeString("acceleration", acceleration);
                    writer.WriteAttributeString("displacement", displacement);
                    writer.WriteAttributeString("mass", mass);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        private void tsiImportBackground_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //Define dialog
            dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to save to
            string extension = filepath.Split("."[0]).Last().ToLower();
            
            //if (!(extension == ".png" || extension == ".jpg" || extension == ".bmp"))
            //{
            //    //Show error message
            //    MessageBox.Show("Invalid file type! Only JPEG, PNG and BMP types are supported",
            //        "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
                customBackground = new Bitmap(new Bitmap(filepath), pictureBoxPlot.Size); //Create a new bitmap from the file,scaled to picturebox
                if (filepath != "") //If the filepath is not blank
                {
                    if (tsiBrightenImage.Checked) //Only if the user wants to brighten their image
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
            //}
        }

        private void tsiRemoveBackground_Click(object sender, EventArgs e)
        {
            //Remove the custom background
            customBackground = null;
            pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);
        }

        private void tsiImportPreset_Click(object sender, EventArgs e)
        {
            //Import preset from XML file
            OpenFileDialog dialog = new OpenFileDialog(); //Define dialog
            dialog.Filter = "Projectile File (*.projectile)|*.projectile"; //Set filter
            dialog.ShowDialog(); //Show the dialog
            string filepath = dialog.FileName; //Get the filepath to open

            
            if (filepath != "") //If the filepath is not blank
            {
                System.Xml.XmlReader reader = System.Xml.XmlReader.Create(filepath); //Open XML document for reading
                try
                {
                    while (reader.Read())
                    {
                        //If the current element is a projectile
                        if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "projectile")
                        {
                            //If there are attributes to read
                            if (reader.HasAttributes)
                            {
                                //Read projectile attributes from file

                                //Parse attributes from XML document
                                Color colour = Color.FromName(reader.GetAttribute("colour"));
                                string[] velocityComponents = reader.GetAttribute("velocity").Split(","[0]);
                                string[] accelerationComponents = reader.GetAttribute("acceleration").Split(","[0]);
                                string[] displacementComponents = reader.GetAttribute("displacement").Split(","[0]);
                                string mass = reader.GetAttribute("mass");

                                //Create vectors from components
                                Vector initVelocity = new Vector(VectorType.component, Double.Parse(velocityComponents[0]), Double.Parse(velocityComponents[1]));
                                Vector initDisplacement = new Vector(VectorType.component, Double.Parse(displacementComponents[0]), Double.Parse(displacementComponents[1]));
                                Vector initAcceleration = new Vector(VectorType.component, Double.Parse(accelerationComponents[0]), Double.Parse(accelerationComponents[1]));

                                //Define projectile to add
                                Projectile toAdd = new Projectile(ProjectileType.component, colour, initVelocity, initDisplacement, initAcceleration, Double.Parse(mass));

                                //Remove projectile with same name
                                tabSelectProjectile.TabPages.RemoveByKey(colour.Name);
                                simulation.RemoveProjectile(colour.Name);
                                comboColour.Items.Remove(colour.Name);

                                //Add the projectile to the simulation and add a tab for it
                                simulation.AddProjectile(toAdd);
                                AddTab();
                            }
                        }
                    }

                    reader.Dispose();

                    if (comboColour.Items.Count != 0) //If there are still colours left
                    {
                        comboColour.SelectedItem = comboColour.Items[0]; //Go to next colour in list
                    }
                    else
                    {
                        btnAddProjectile.Enabled = false; //Disable add projectile button
                    }

                    HandleTabsChanged();
                }
                catch (Exception)
                {
                    //Show error message detailing correct format
                    MessageBox.Show("Invalid preset file! Check presence of colour, velocity (x, y), acceleration (x, y), displacement (x, y), and mass.",
                        "Invalid Preset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Dispose();
                }
            }
        }

        private void HandleTabsChanged()
        {
            //Runs when a tab is added or removed, sets buttons accordingly
            if (tabSelectProjectile.TabPages.Count == 0)
            {
                btnPlot.Enabled = false; btnDelete.Enabled = false;
            }
            else
            {
                btnPlot.Enabled = true; btnDelete.Enabled = true;
            }
        }

        private void tsiSettings_Click(object sender, EventArgs e)
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

            if (btn.Equals(tsiViewComponent))
            {
                //Set the other items to unchecked
                tsiViewMagnitudeDirection.Checked = tsiViewEnergies.Checked = false;
                //Set the displayType var
                displayType = TabDisplayType.Component;
            }
            if (btn.Equals(tsiViewMagnitudeDirection))
            {
                tsiViewComponent.Checked = tsiViewEnergies.Checked = false;
                displayType = TabDisplayType.Magnitude;
            }
            if (btn.Equals(tsiViewEnergies))
            {
                tsiViewComponent.Checked = tsiViewMagnitudeDirection.Checked = false;
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