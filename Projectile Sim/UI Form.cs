﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Projectile_Sim
{
    public enum TabDisplayType { Component, Magnitude, Energy }; // Enumerator for display styles

    public partial class UIForm : Form
    {
        // Sets the maximum number of projectiles
        const int maxProjectiles = 7;

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

        public UIForm()
        {
            InitializeComponent();

            // Initialises delegates so that events can be handled
            plotCompleteDelegate = new HandlePlotComplete(MethodPlotComplete);
            updateTabsDelegate = new HandleUpdateTabs(MethodUpdateTabs);
            updateTimeDelegate = new HandleUpdateTime(MethodUpdateTime);
            projectileTabs = new TabContents[maxProjectiles];
        }

        private void MethodUpdateTime(double time)
        {
            // Updates the time textbox, called by event

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
            // Handles updating the tabs, called by event

            foreach (var projectile in projectiles)
            {
                // Gets the tab with the same name as the projectile
                TabPage tab = tabSelectProjectile.TabPages[tabSelectProjectile.TabPages.IndexOfKey(projectile.colour.Name)];

                // Gets the control collection of the current tab
                Control.ControlCollection controlCollection = ((TabContents)tab.Controls[0]).Controls;

                // Defines formatting string so that all controls use the same number of decimal places
                string formatString = "F" + Properties.Settings.Default.decimalPlaces.ToString();

                // Initialises variables with values
                Vector displacement = projectile.GetDisplacement();
                Vector velocity = projectile.GetVelocity();
                double KE = projectile.GetKineticEnergy();
                double GPE = projectile.GetGPEnergy();

                // Depending on the tab display type, update the relevant controls
                switch (((TabContents)tab.Controls[0]).displayType)
                {
                    case TabDisplayType.Component:

                        // Get the textbox
                        TextBox txtHPos = (TextBox)tab.Controls.Find("txtHPos", true).First(); // Horizontal position
                        // Set the text
                        txtHPos.Text = displacement.horizontal.ToString(formatString);

                        TextBox txtVPos = (TextBox)tab.Controls.Find("txtVPos", true).First(); // Vertical position
                        txtVPos.Text = displacement.vertical.ToString(formatString);

                        TextBox txtHVel = (TextBox)tab.Controls.Find("txtHVel", true).First(); // Horizontal velocity
                        txtHVel.Text = velocity.horizontal.ToString(formatString);

                        TextBox txtVVel = (TextBox)tab.Controls.Find("txtVVel", true).First(); // Vertical Velocity
                        txtVVel.Text = velocity.vertical.ToString(formatString);
                        break;
                    case TabDisplayType.Magnitude:
                        TextBox txtMagPos = (TextBox)tab.Controls.Find("txtMagPos", true).First(); // Mag of position
                        txtMagPos.Text = displacement.magnitude.ToString(formatString);

                        TextBox txtAnglePos = (TextBox)tab.Controls.Find("txtAnglePos", true).First(); // Direction of position
                        txtAnglePos.Text = (displacement.direction * (180 / Math.PI)).ToString(formatString);

                        TextBox txtMagVel = (TextBox)tab.Controls.Find("txtMagVel", true).First(); // Mag of velocity
                        txtMagVel.Text = velocity.magnitude.ToString(formatString);

                        TextBox txtAngleVel = (TextBox)tab.Controls.Find("txtAngleVel", true).First(); // Direction of velocity
                        txtAngleVel.Text = (velocity.direction * (180 / Math.PI)).ToString(formatString);
                        break;
                    case TabDisplayType.Energy:
                        TextBox txtKineticEnergy = (TextBox)tab.Controls.Find("txtKineticEnergy", true).First(); // Kinetic energy
                        txtKineticEnergy.Text = KE.ToString(formatString);

                        TextBox txtGPE = (TextBox)tab.Controls.Find("txtGPE", true).First(); // Potential energy
                        txtGPE.Text = GPE.ToString(formatString);

                        TextBox txtTotalEnergy = (TextBox)tab.Controls.Find("txtTotalEnergy", true).First(); //Total energy
                        txtTotalEnergy.Text = (KE + GPE).ToString(formatString);

                        break;
                }
            }
        }

        private void MethodPlotComplete()
        {
            // Handles the plot being completed

            // Allow the window to be resized again
            Program.form1.FormBorderStyle = FormBorderStyle.Sizable;

            // Re-enable controls
            groupAddProjectile.Enabled = true;
            groupPlotOptions.Enabled = true;
            groupScales.Enabled = true;
            groupAnimation.Enabled = true;

            // Set buttons as appropriate
            btnPause.Enabled = false;
            btnPause.Text = "II";
            btnPlot.Enabled = true;
            tsiView.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void UpdateProgressBarWorkaround(int value)
        {
            // Workaround for updating the progress bar

            // Set it to the required value +1
            if (value < animationProgressBar.Maximum)
            {
                // Set one above correct value
                animationProgressBar.Value = value + 1;
            }
            else
            {
                // Special case, set the value to max
                value = animationProgressBar.Maximum;
            }

            // Immediately set it to the required value, == previous value - 1
            animationProgressBar.Value = value;
        }

        private void BtnAddProjectile_Click(object sender, EventArgs e)
        {
            // Get colour from combobox
            String colourName = comboColour.Text;
            Color colour = Color.FromName(colourName);

            // Remove colour form combobox
            comboColour.Items.Remove(colourName);
            if (comboColour.Items.Count != 0) // If there are still colours left
            {
                comboColour.SelectedItem = comboColour.Items[0]; // Go to next colour in list
            }
            else
            {
                btnAddProjectile.Enabled = false; // Disable add projectile button
            }


            // Defines common variables
            double height = (double)upDownInitHeight.Value;
            double g = (double)upDownG.Value, speed, angle;
            double mass = (double)upDownMass.Value;

            Vector initVelocity = new Vector();

            // Depending on the current tab
            switch (tabProjectileType.SelectedTab.Text)
            {
                case "Speed / Angle":
                    // Get variables
                    speed = (double)upDownSpeed1.Value;
                    angle = (double)upDownAngle1.Value * (Math.PI / 180); // Converts to radians

                    // Create vector for initial velocity
                    initVelocity = new Vector(VectorType.magnitude, speed, angle);
                    break;
                case "Components":
                    double hVelocity = (double)upDownHVelocity.Value;
                    double vVelocity = (double)upDownVVelocity.Value;

                    initVelocity = new Vector(VectorType.component, hVelocity, vVelocity);
                    break;
                case "Energy":
                    // Find speed from energy and mass
                    speed = Math.Sqrt((double)(2 * upDownEnergy.Value) / (double)upDownMass.Value);
                    angle = (double)upDownAngle3.Value * (Math.PI / 180);

                    initVelocity = new Vector(VectorType.magnitude, speed, angle);
                    break;
            }

            Vector initDisplacement = new Vector(VectorType.component, 0, height);
            Vector initAcceleration = new Vector(VectorType.component, 0, -g);

            // Adds projectile
            simulation.projectiles.Add(new Projectile(ProjectileType.component, colour, initVelocity, initDisplacement, initAcceleration, mass));

            // Add a tab
            AddTab();
        }

        private void AddTab()
        {
            // Adds a tab to the tab control

            TabPage newTab = new TabPage();
            int index = tabSelectProjectile.TabCount;
            Control.ControlCollection controlCollection;

            string formatString = "F" + Properties.Settings.Default.decimalPlaces.ToString();

            // Define new tab contents control with selected type
            projectileTabs[index] = new TabContents(displayType) { Dock = DockStyle.Fill, AutoScroll = true };
            // Add the control to the tab
            newTab.Controls.Add(projectileTabs[index]);
            controlCollection = projectileTabs[index].Controls;

            // Set tab text and name to the colour
            newTab.Text = simulation.projectiles[index].colour.Name;
            newTab.Name = newTab.Text;
            tabSelectProjectile.TabPages.Add(newTab);
            tabSelectProjectile.SelectedIndex = index;

            // Common controls
            // Get control by "name"
            Control txtDuration = controlCollection.Find("txtDuration", true).First();
            double duration = simulation.projectiles[index].duration;
            txtDuration.Text = duration.ToString(formatString);

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
            // Runs when the form opens

            // Set controls to their default states
            tabSelectProjectile.TabPages.Clear();
            comboColour.SelectedItem = comboColour.Items[0];

            // If default a scale is being used, use it
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

            // Creates a list of numeric up/down boxes
            List<NumericUpDown> upDownList = new List<NumericUpDown>();
            upDownList.AddRange(groupAddProjectile.Controls.OfType<NumericUpDown>());
            upDownList.AddRange(tabSpeedAngle.Controls.OfType<NumericUpDown>());
            upDownList.AddRange(tabComponents.Controls.OfType<NumericUpDown>());
            upDownList.AddRange(tabEnergy.Controls.OfType<NumericUpDown>());
            numPlotTo.DecimalPlaces = Properties.Settings.Default.decimalPlaces;
            // Sets them to use the correct number of decimal places
            foreach (NumericUpDown upDown in upDownList)
            {
                upDown.DecimalPlaces = Properties.Settings.Default.decimalPlaces;
            }

            HandleTabsChanged();
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            // Runs when plot button is clicked

            // Enable buttons as appropriate
            btnPause.Enabled = true;
            btnPlot.Enabled = false;
            btnDelete.Enabled = false;
            tsiView.Enabled = false;

            // Disable groups
            groupAddProjectile.Enabled = false;
            groupPlotOptions.Enabled = false;
            groupScales.Enabled = false;
            groupAnimation.Enabled = false;

            // Stop the window from being resized
            Program.form1.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Clear picturebox
            if (Object.Equals(customBackground, null))
            {
                pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);
            }
            else
            {
                pictureBoxPlot.Image = new Bitmap(customBackground);
            }

            // Calculates and sets scales in pixels per metre
            double hScale = (double)((pictureBoxPlot.Width - Properties.Settings.Default.margin) / upDownHorizontal.Value);
            double vScale = (double)((pictureBoxPlot.Height - Properties.Settings.Default.margin) / upDownVertical.Value);
            simulation.SetScales(hScale, vScale);
            simulation.SetLineWidth((int)upDownLineWidth.Value);

            // Initialises timescale to 0
            double timescale = 0;

            // Calls to start animation with specified timescale
            if (radioAnimated.Checked)
            {
                timescale = (double)upDownTimescale.Value;
            }
            else if (radioNoAnimation.Checked)
            {
                timescale = 0;
            }

            // Starts the simulation with the correct timescale and time to plot to
            simulation.Plot(timescale, (double)numPlotTo.Value);
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            // Runs when pause button is clicked

            // Toggles between pause and play icons and sets the animation running
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
            // Runs when delete button clicked

            // Gets currently selected tab
            TabPage tab = tabSelectProjectile.SelectedTab;

            // Removes projectile from simulation
            simulation.RemoveProjectile(tab.Text);
            comboColour.Items.Add(tab.Text);

            // Re-enables add projectile button if not already
            btnAddProjectile.Enabled = true;

            // Removes tab from control
            tabSelectProjectile.TabPages.Remove(tab);

            // Calls method to handle the change of tabs
            HandleTabsChanged();
        }

        private void tsiExportGraph_Click(object sender, EventArgs e)
        {
            // Code to save the image displayed
            DialogResult result = MessageBox.Show("Use a transparent background?", "Background", MessageBoxButtons.YesNo);
            bool transparency;
            if (result == DialogResult.Yes) { transparency = true; } else { transparency = false; }

            // Define file save dialog
            SaveFileDialog dialog = new SaveFileDialog(); 
            dialog.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp"; // Set filter
            dialog.ShowDialog(); // Show the dialog

            // Get the filepath to save to
            string filepath = dialog.FileName; 

            if (filepath != "") // If filepath not blank
            {
                string extension = filepath.Split("."[0]).Last().ToUpper(); // Parse the file extension

                Bitmap image = new Bitmap(pictureBoxPlot.Image);

                if (!transparency) // If user does not want transparency
                {
                    // Create white bitmap
                    Bitmap white = new Bitmap(image.Width, image.Height);
                    using (Graphics graph = Graphics.FromImage(white))
                    {
                        Rectangle ImageSize = new Rectangle(0, 0, image.Width, image.Height);
                        graph.FillRectangle(Brushes.White, ImageSize);
                    }

                    // Scale to size of canvas
                    white = new Bitmap(white, image.Size);

                    Bitmap img = new Bitmap(image.Width, image.Height);
                    using (Graphics gr = Graphics.FromImage(img))
                    {
                        gr.DrawImage(white, new Point(0, 0));
                        gr.DrawImage(image, new Point(0, 0));
                    }

                    // Stores result in image variable
                    image = new Bitmap(img);
                }



                switch (extension) // Save with the appropriate format
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
                        // Show an error message if the user attempts to save to an unsupported format
                        MessageBox.Show("Invalid file type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        break;
                }
            }
        }

        private void tsiExportPreset_Click(object sender, EventArgs e)
        {
            // Export a preset to an XML file

            // Get path to save to
            SaveFileDialog dialog = new SaveFileDialog(); // Define dialog
            dialog.Filter = "Projectile File (*.projectile)|*.projectile"; // Set filter
            dialog.ShowDialog(); // Show the dialog
            string filepath = dialog.FileName; // Get the filepath to save to

            if (filepath != "") // If the filepath is not blank
            {
                // Create XMLWriter object, using the specified file
                System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(filepath);

                // Write the start of the document
                writer.WriteStartDocument();

                // Write the opening tag of the projectiles element
                writer.WriteStartElement("projectiles");

                // For each projectile in the simulation
                foreach (var projectile in simulation.projectiles)
                {
                    // Write a new element
                    writer.WriteStartElement("projectile");
                    
                    // With a colour attribute
                    writer.WriteAttributeString("colour", projectile.colour.Name);

                    string velocity, acceleration, displacement, mass;
                    
                    // Convert vector components to strings "(x,y)"
                    velocity = projectile.initVelocity.horizontal.ToString() + "," + projectile.initVelocity.vertical.ToString();
                    acceleration = projectile.initAcceleration.horizontal.ToString() + "," + projectile.initAcceleration.vertical.ToString();
                    displacement = projectile.initDisplacement.horizontal.ToString() + "," + projectile.initDisplacement.vertical.ToString();
                    mass = projectile.mass.ToString();

                    // Write the elements to file
                    writer.WriteAttributeString("velocity", velocity);
                    writer.WriteAttributeString("acceleration", acceleration);
                    writer.WriteAttributeString("displacement", displacement);
                    writer.WriteAttributeString("mass", mass);

                    // Write end of projectile element
                    writer.WriteEndElement();
                }

                // Finalise document and close it
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        private void tsiImportBackground_Click(object sender, EventArgs e)
        {
            // Runs when user clicks 'Import Background"

            OpenFileDialog dialog = new OpenFileDialog(); // Define dialog
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG"; // Set filter
            dialog.ShowDialog(); // Show the dialog
            string filepath = dialog.FileName; // Get the filepath to save to
            string extension = filepath.Split("."[0]).Last().ToLower(); // Gets the file extension

            if (!(extension == "png" || extension == "jpg" || extension == "bmp"))
            {
                // If the extension is unsupported, show error message
                MessageBox.Show("Invalid file type! Only JPEG, PNG and BMP types are supported",
                    "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    customBackground = new Bitmap(new Bitmap(filepath), pictureBoxPlot.Size); // Create a new bitmap from the file,scaled to picturebox
                    if (filepath != "") // If the filepath is not blank
                    {
                        if (tsiBrightenImage.Checked) // Only if the user wants to brighten their image
                        {
                            for (int i = 0; i < customBackground.Width; i++)
                            {
                                for (int j = 0; j < customBackground.Height; j++)
                                {
                                    // Get the colour of the pixel
                                    Color fromImage = customBackground.GetPixel(i, j);

                                    int R, G, B;
                                    decimal factor = 1.5M;

                                    // Increase the RGB values for the pixel, limited to 255 max
                                    R = (int)(fromImage.R * factor); if (R > 255) { R = 255; }
                                    G = (int)(fromImage.G * factor); if (G > 255) { G = 255; }
                                    B = (int)(fromImage.B * factor); if (B > 255) { B = 255; }

                                    // Set the new colour
                                    Color result = Color.FromArgb(fromImage.A, R, G, B);
                                    customBackground.SetPixel(i, j, result);
                                }
                            }
                        }

                        // Set the current image in the picturebox
                        pictureBoxPlot.Image = customBackground;
                    }
                }
                catch (Exception) // If the background fails to import
                {
                    // Show an error message
                    MessageBox.Show("Image unable to be imported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsiRemoveBackground_Click(object sender, EventArgs e)
        {
            // Remove the background
            customBackground = null;
            pictureBoxPlot.Image = new Bitmap(pictureBoxPlot.Width, pictureBoxPlot.Height);
        }

        private void tsiImportPreset_Click(object sender, EventArgs e)
        {
            // Import preset from XML file
            OpenFileDialog dialog = new OpenFileDialog(); // Define dialog
            dialog.Filter = "Projectile File (*.projectile)|*.projectile"; // Set filter
            dialog.ShowDialog(); // Show the dialog
            string filepath = dialog.FileName; // Get the filepath to open


            if (filepath != "") // If the filepath is not blank
            {
                System.Xml.XmlReader reader = System.Xml.XmlReader.Create(filepath); // Open XML document for reading
                try
                {
                    while (reader.Read()) // While there are elements to read
                    {
                        // If the current element is a projectile
                        if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.Name == "projectile")
                        {
                            // If there are attributes to read
                            if (reader.HasAttributes)
                            {
                                // Read projectile attributes from file

                                // Parse attributes from XML document
                                Color colour = Color.FromName(reader.GetAttribute("colour"));
                                string[] velocityComponents = reader.GetAttribute("velocity").Split(","[0]);
                                string[] accelerationComponents = reader.GetAttribute("acceleration").Split(","[0]);
                                string[] displacementComponents = reader.GetAttribute("displacement").Split(","[0]);
                                string mass = reader.GetAttribute("mass");

                                // Create vectors from components
                                Vector initVelocity = new Vector(VectorType.component, Double.Parse(velocityComponents[0]), Double.Parse(velocityComponents[1]));
                                Vector initDisplacement = new Vector(VectorType.component, Double.Parse(displacementComponents[0]), Double.Parse(displacementComponents[1]));
                                Vector initAcceleration = new Vector(VectorType.component, Double.Parse(accelerationComponents[0]), Double.Parse(accelerationComponents[1]));

                                // Define projectile to add
                                Projectile toAdd = new Projectile(ProjectileType.component, colour, initVelocity, initDisplacement, initAcceleration, Double.Parse(mass));

                                // Remove projectile with same name
                                tabSelectProjectile.TabPages.RemoveByKey(colour.Name);
                                simulation.RemoveProjectile(colour.Name);
                                comboColour.Items.Remove(colour.Name);

                                // Add the projectile to the simulation and add a tab for it
                                simulation.AddProjectile(toAdd);
                                AddTab();
                            }
                        }
                    }

                    // Dispose of the reader object
                    reader.Dispose();

                    if (comboColour.Items.Count != 0) // If there are still colours left
                    {
                        comboColour.SelectedItem = comboColour.Items[0]; // Go to next colour in list
                    }
                    else
                    {
                        btnAddProjectile.Enabled = false; // Disable add projectile button
                    }

                    HandleTabsChanged();
                }
                catch (Exception)
                {
                    // Show error message detailing correct format
                    MessageBox.Show("Invalid preset file! Check presence of colour, velocity (x, y), acceleration (x, y), displacement (x, y), and mass.",
                        "Invalid Preset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Dispose();
                }
            }
        }

        private void HandleTabsChanged()
        {
            // Runs when a tab is added or removed, sets buttons accordingly
            if (tabSelectProjectile.TabPages.Count == 0)
            {
                btnPlot.Enabled = false; btnDelete.Enabled = false; tsiExportPreset.Enabled = false;
            }
            else
            {
                btnPlot.Enabled = true; btnDelete.Enabled = true; tsiExportPreset.Enabled = true;
            }

            // Get highets duration
            double highestDuration = 0;
            foreach (TabPage page in tabSelectProjectile.TabPages)
            {
                TextBox txtDuration = (TextBox)page.Controls.Find("txtDuration", true).First();
                double duration = Convert.ToDouble(txtDuration.Text);
                if (duration > highestDuration) { highestDuration = duration; }
            }

            // Sets the maximum value of the 'Plot to' control to the largest duration of motion
            numPlotTo.Maximum = (decimal)highestDuration;
        }

        private void tsiSettings_Click(object sender, EventArgs e)
        {
            // Runs when settings button is clicked

            Settings settings = new Settings(); // Defines settings form
            settings.ShowDialog(); // Show as a dialog box
            settings.Dispose(); // Dispose of resources used
        }

        private void HandleTabStyleChange(object sender, EventArgs e)
        {
            // Runs when the tab style is changed

            // Get the button that called this method
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;

            // Always check the item clicked
            btn.Checked = true;

            // Depending on the button that called this
            if (btn.Equals(tsiViewComponent)) // If the user selected to view components
            {
                // Set the other items to unchecked
                tsiViewMagnitudeDirection.Checked = tsiViewEnergies.Checked = false;
                // Set the displayType var
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

            // For each tab
            foreach (TabPage tab in tabSelectProjectile.TabPages)
            {
                // Change the type of the control
                ((TabContents)tab.Controls[0]).ChangeType(displayType);
            }

        }
    }
}