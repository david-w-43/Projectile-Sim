using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace Projectile_Sim
{
    public class Simulation
    {
        /* Variables----------*/


        //Stores the projectiles
        public readonly List<Projectile> projectiles = new List<Projectile>();

        //Stores the maximum values
        private double maxHeight, maxRange;
        public double maxDuration;
        private int maxX;
        private double toTime;

        //Stores scales, in pixels per metre
        private double pxPerX = 1;
        private double pxPerY = 1;
        private const int updatesPerPixel = 3;
        private double frameInterval;
        private double updateTimeInterval;

        //Stores the margin widths
        private int hAxisPos, vAxisPos;

        //Defines PictureBox and timer/stopwatch
        private PictureBox canvasContainer;
        private System.Timers.Timer refreshTimer;
        private System.Diagnostics.Stopwatch stopwatch;


        private double fromTime;
        private double timescale;
        private int lineWidth;

        public bool paused;


        /* End variables------------- */

        private void DrawAxes()
        {
            // Used for drawing the axes
            
            // Create image using current canvas
            Bitmap canvas;
            if (Object.Equals(canvasContainer.Image, null))
            {
                canvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            }
            else
            {
                canvas = (Bitmap)canvasContainer.Image;
            }

            // Shorthand for settings value
            int marginWidth = Properties.Settings.Default.margin;

            // Calculate the positions of the margins, with the top left being (0, 0)
            hAxisPos = canvas.Height - marginWidth;
            vAxisPos = marginWidth;

            // Draw the axes as two black lines
            if (marginWidth != 0) //If the margin width is not 0
            {
                for (int row = 0; row <= hAxisPos + 10; row++) // For each row up to the margin
                {
                    if (row < canvas.Height && row >= 0)
                    {
                        canvas.SetPixel(marginWidth, row, Color.Black); // Draw pixel of y axis
                    }
                }
                for (int col = vAxisPos - 10; col < canvas.Width; col++) // For each column to the end of the image
                {
                    if (col < canvas.Width && col >= 0)
                    {
                        canvas.SetPixel(col, hAxisPos, Color.Black); // Draw a black pixel
                    }
                }
            }

            // Set the image displayed to the new one, with axes added
            canvasContainer.Image = canvas;

            // Calculate width and height of the canvas, convert to string
            string xLabel = ((canvas.Width - marginWidth) / pxPerX).ToString("G5");
            string yLabel = ((canvas.Height - marginWidth) / pxPerY).ToString("G5");

            // Creates an array of three controls
            Label[] axesLabels = new Label[3];

            // Define the three labels, set to the correct positions
            axesLabels[0] = new Label() { BackColor = Color.Transparent, Text = "0", Anchor = (AnchorStyles.Left | AnchorStyles.Bottom), Left = 3, Top = canvasContainer.Height - marginWidth };
            axesLabels[1] = new Label() { BackColor = Color.Transparent, Text = xLabel, Anchor = (AnchorStyles.Right | AnchorStyles.Bottom), Left = canvasContainer.Width - (2 * marginWidth), Top = canvasContainer.Height - marginWidth };
            axesLabels[2] = new Label() { BackColor = Color.Transparent, Text = yLabel, Anchor = (AnchorStyles.Left | AnchorStyles.Top), Left = marginWidth, Top = marginWidth };
            
            // Remove existing labels, add new ones
            canvasContainer.Controls.Clear();
            canvasContainer.Controls.AddRange(axesLabels);
        }

        public void SetScales(double xScale, double yscale) { pxPerX = xScale; pxPerY = yscale; } // Sets the scales used
        public void SetLineWidth(int width) { lineWidth = width; } // Sets the drawing pencil width

        public void Pause() { refreshTimer.Stop(); stopwatch.Stop(); paused = true; } // Pauses the animation
        public void Resume() { refreshTimer.Start(); stopwatch.Start(); paused = false; } // Resumes the animation

        public void Plot(double timescale = 0, double toTime = 0) // Includes default values
        {
            // Used to plot the trajectories

            paused = false; 
            this.timescale = timescale;
            // Get the maximum values and update interval
            GetMaxValues();
            updateTimeInterval = maxDuration / (maxX * updatesPerPixel);
            
            // If no totime specified, plot whole trajectory
            if (toTime == 0) { this.toTime = maxDuration; } else { this.toTime = toTime; }

            // Calculates time interval between frames
            frameInterval = (1d / Properties.Settings.Default.framerate); //Seconds

            // Instantiates timer and stopwatch for use
            refreshTimer = new System.Timers.Timer((int)(1000 * frameInterval)); //Milliseconds
            stopwatch = new System.Diagnostics.Stopwatch();

            // Timer triggers canvas refresh, and automatically resets

            // Gets the PictureBox from Form1
            this.canvasContainer = (PictureBox)Program.form1.Controls.Find("pictureBoxPlot", true).First();

            // Draw axes on the canvas
            DrawAxes();

            // Resets the previous time to 0
            fromTime = 0;

            if (timescale != 0) // If animated plot is wanted
            {
                // Use stopwatch to get time while plotting
                // Use timer to trigger updates
                refreshTimer.Elapsed += RealTime;
                refreshTimer.Start();
                stopwatch.Reset();
                stopwatch.Start();
            }
            else
            {
                // Create canvas with all points plotted
                canvasContainer.Image = RecursivePlot((Bitmap)canvasContainer.Image, 0, this.toTime, updateTimeInterval);
                // Raise plot complete event
                Program.form1.Invoke(Program.form1.plotCompleteDelegate);
                // Update time with max duration
                Program.form1.Invoke(Program.form1.updateTimeDelegate, toTime);
            }
        }

        // --------------------------------------
        // --------- RECURSIVE FUNCTION ---------
        // --------------------------------------
        private Bitmap RecursivePlot(Bitmap prevImage, double time, double toTime, double timeInterval)
        {
            // If the current time is not greater than the maximum time to plot to, plus one frame interval
            if (time < toTime + timeInterval)
            {
                // Building on top of previous image
                Bitmap currentImage = prevImage;
                // Loop through projectiles
                foreach (var projectile in projectiles)
                {
                    // Update all values for projectile, and get the displacement
                    projectile.Update(time); 
                    Vector currentDisplacement = projectile.GetDisplacement();

                    // Convert the displacement to image x and y coordinates
                    int x = (int)((currentDisplacement.horizontal) * pxPerX) + vAxisPos;
                    int y = hAxisPos - (int)((currentDisplacement.vertical) * pxPerY);

                    // For each pixel surrounding the value to plot, radius = lineWidth
                    for (int i = x - (lineWidth - 1); i <= x + (lineWidth - 1); i++)
                    {
                        for (int j = y - (lineWidth - 1); j <= y + (lineWidth - 1); j++)
                        {
                            // If valid to plot and projectile still in motion
                            if (i >= 0 && i < prevImage.Width && j >= 0 && j < prevImage.Height && time <= projectile.duration)
                            {
                                // Set pixel to colour of projectile
                                currentImage.SetPixel(i, j, projectile.colour);
                            }
                        }
                    }
                }
                
                //Calls itself again
                RecursivePlot(currentImage, time + timeInterval, toTime, timeInterval);

                // Return the image with amendments made
                return currentImage;
            }
            else // Escape clause
            {
                // Return null as all code paths must return a value
                return null;
            }
        }

        private void RealTime(Object source, ElapsedEventArgs e) //Runs every frame
        {
            // Handles plotting in real time

            // Use stopwatch to get time while plotting
            double time = ((double)stopwatch.ElapsedMilliseconds / 1000) * timescale; //Convert time to seconds

            // Convert time to string and display it
            Console.WriteLine("Time: " + time.ToString("N3"));
            Program.form1.Invoke(Program.form1.updateTimeDelegate, time);

            // If the time is within the greatest time of flight + one scaled frame interval
            if (time < toTime + (frameInterval * timescale))
            {
                if (time > toTime) { time = toTime; } // If overshot the time to plot to, restrict

                // Use the current image on the canvas, create one if it is not present
                Bitmap currentFrame = (Bitmap)canvasContainer.Image;
                if (Object.Equals(currentFrame, null)) { currentFrame = new Bitmap(canvasContainer.Width, canvasContainer.Height); }
                
                // Use the recursively defined plotting subroutine to plot the trajectories between the previous time and the current one
                canvasContainer.Image = RecursivePlot(currentFrame, fromTime, time, updateTimeInterval);
                
                // Set the previous time to the current time
                fromTime = time;

                // Invoke the procedure to update the tabs
                List<Projectile> parameters = projectiles;
                Program.form1.Invoke(Program.form1.updateTabsDelegate, parameters);
            }
            else
            {
                // If animation has finished

                // Stop the timer and stopwatch
                stopwatch.Stop();
                refreshTimer.Stop();

                // Set current time to the end time
                time = toTime;

                // Now actually calculate the correct values for the end time, you dingus
                foreach (Projectile projectile in projectiles)
                {
                    projectile.Update(time);
                }

                // Update tabs
                List<Projectile> parameters = projectiles;
                Program.form1.Invoke(Program.form1.updateTabsDelegate, parameters);

                // Raise plot complete event
                Program.form1.Invoke(Program.form1.plotCompleteDelegate);
                // Update time with max duration
                Program.form1.Invoke(Program.form1.updateTimeDelegate, time);
            }
        }

        public void AddProjectile(Projectile projectile)
        {
            projectiles.Add(projectile); // Adds a projectile to the list
        }

        public void RemoveProjectile(string name)
        {
            // Linear search for the correct projectile in the list to remove
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].colour.Name == name) { projectiles.RemoveAt(i); }
            }
        }

        private void GetMaxValues()
        {
            // Initialise variables as 0
            maxDuration = maxRange = maxX = 0;

            // Cycle through projectiles, updating maximum values
            foreach (var projectile in this.projectiles)
            {
                if (projectile.apex.vertical > maxHeight) { maxHeight = projectile.apex.vertical; }
                if (projectile.range > maxRange) { maxRange = projectile.range; }
                if (projectile.duration > maxDuration) { maxDuration = projectile.duration; }

                maxX = (int)(maxRange * pxPerX);
            }
        }
    }
}