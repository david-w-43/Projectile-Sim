using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Projectile_Sim
{
    //public enum SimulationSpeed { Animated, NoAnimation }

    public class Simulation
    {
        /* Variables----------*/
        

        //Stores the projectiles
        public readonly List<Projectile> projectiles = new List<Projectile>();

		//Stores the maximum values
        private double maxHeight, maxRange, maxDuration;
        private int maxY, maxX;
        private double toTime;

        //Stores scales, in pixels per metre
        private double pxPerX = 1;
        private double pxPerY = 1;
        private const int updatesPerPixel = 3;
        private double updateTimeInterval;
        private int hAxisPos, vAxisPos;

        //Defines PictureBox and timer/stopwatch
        private PictureBox canvasContainer;
		private System.Timers.Timer refreshTimer;
        private System.Diagnostics.Stopwatch stopwatch;
        private double prevTime;
        private double timescale;
        private int lineWidth;

        public bool paused;


		/* End variables------------- */

        public void UpdateTabs()
        {
            //Update tabs with current information
        }

        public void DrawAxes()
        {
            //Bitmap canvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            Bitmap canvas;
            if (Object.Equals(canvasContainer.Image, null))
            {
                canvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            }
            else
            {
                canvas = (Bitmap)canvasContainer.Image;
            }

            hAxisPos = canvas.Height - Properties.Settings.Default.margin;
            int marginWidth = Properties.Settings.Default.margin;
            vAxisPos = marginWidth;

            for (int row = 0; row <= hAxisPos + 10; row++) //For each row up to the margin
            {
                canvas.SetPixel(marginWidth, row, Color.Black); //Draw pixel of y axis
            }
            for (int col = vAxisPos - 10; col < canvas.Width; col++)
            {
                canvas.SetPixel(col, hAxisPos, Color.Black);
            }
            canvasContainer.Image = canvas;
            string xLabel = ((canvas.Width - marginWidth) / pxPerX).ToString("G3");
            string yLabel = ((canvas.Height - marginWidth) / pxPerY).ToString("G3");
            canvasContainer.Image = canvas;
        }
        
        public void SetScales(double xScale, double yscale) { pxPerX = xScale; pxPerY = yscale;}
        public void SetLineWidth(int width) { lineWidth = width; }

        public void Pause() { refreshTimer.Stop(); stopwatch.Stop(); paused = true; }
        public void Resume() { refreshTimer.Start(); stopwatch.Start(); paused = false; }

		public void Plot(double timescale = 0, double toTime = 0)
        {

            paused = false;
            this.timescale = timescale;
            //Get the maximum values and update interval
            GetMaxValues();
            updateTimeInterval = maxDuration / (maxX * updatesPerPixel);
            //If no totime specified, plot whole trajectory
            if (toTime == 0) { this.toTime = maxDuration; } else { this.toTime = toTime; }
            

            //Instantiates timer and stopwatch for use, timer defaults to 33 ms (30 Hz)
            refreshTimer = new System.Timers.Timer((int)(1000/30));
            stopwatch = new System.Diagnostics.Stopwatch();

			//Timer triggers canvas refresh, and automatically resets
            //Currently disabled so that it does not run the same code simultaneously
            //refreshTimer.AutoReset = true;

			//Gets the PictureBox from Form1
			this.canvasContainer = (PictureBox)Program.form1.Controls.Find("pictureBoxPlot", true).First();

            DrawAxes();

            //Resets the previous time to 0
            prevTime = 0;

            if (timescale != 0)
            {
                //Use stopwatch to get time while plotting
                //Use timer to trigger updates
                refreshTimer.Elapsed += RealTime;
                refreshTimer.Start();
                stopwatch.Reset();
                stopwatch.Start();
            }
            else
            { 
                //Create canvas with all points plotted
                canvasContainer.Image = RecursivePlot((Bitmap)canvasContainer.Image, 0, this.toTime, updateTimeInterval);
            }
        }

        #region Old plotting algorithm without recursion
        /*
        private Bitmap NoAnimation(double fromTime, double toTime)
        {
			//Defines canvas with required width and height
            Bitmap canvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            //Run on 3 updates per pixel
            double timePerPixel = maxDuration / maxX;
            double timeInterval = timePerPixel / 3;

            double time = fromTime; //Initialise as 0 to plot from start
            while (time < toTime)
            {
                foreach (var projectile in projectiles)
                {
					//Updates time of projectile
                    projectile.Update(time);

					//Calculates x, inverted y for scale
                    int x = (int)((projectile.displacement.horizontal) * pxPerX);
					int y = canvasContainer.Height - (int)((projectile.displacement.vertical) * pxPerY);

					//If valid to plot
					if (x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
                    {
						//Set pixel to colour of projectile
                        canvas.SetPixel(x, y, projectile.colour);
                    }
                }

                time += timeInterval;
            }

			//Sets PictureBox image
            //canvasContainer.Image = canvas;
            return canvas;
        }
        */
        #endregion

        private Bitmap RecursivePlot(Bitmap prevImage, double time, double toTime, double timeInterval)
        {
            if (time < toTime + timeInterval)
            {
                //Building on top of previous image
                Bitmap currentImage = prevImage;
                //Loop through projectiles
                foreach (var projectile in projectiles)
                {
                    //Update time, calculate scaled positions to plot
                    projectile.Update(time);
                    int x = (int)((projectile.displacement.horizontal) * pxPerX) + vAxisPos;
                    int y = hAxisPos - (int)((projectile.displacement.vertical) * pxPerY);

                    //For each pixel surrounding the value to plot, radius = lineWidth
                    for (int i = x - (lineWidth - 1); i <= x + (lineWidth - 1); i++)
                    {
                        for (int j = y - (lineWidth - 1); j <= y + (lineWidth - 1); j++)
                        {
                            //If valid to plot and projectile still in motion
                            if (i >= 0 && i < prevImage.Width && j >= 0 && j < prevImage.Height && time <= projectile.duration)
                            {
                                //Set pixel to colour of projectile
                                currentImage.SetPixel(i, j, projectile.colour);
                            }
                        }
                    }
                }
                //Calls itself
                RecursivePlot(currentImage, time + timeInterval, toTime, timeInterval);
                return currentImage;
            }
            else //Escape clause
            {
                return null;
            }
        }

        private void RealTime(Object source, ElapsedEventArgs e) //Runs every frame
        {
            //Use stopwatch to get time while plotting
            //Convert time to seconds
            double time = ((double)stopwatch.ElapsedMilliseconds / 1000) * timescale;
            Console.WriteLine("Time: " + time.ToString("N3"));
            Program.form1.Invoke(Program.form1.updateTimeDelegate, time);

            //Experimenting with upper bound, due to system variations it is not always consistent with update intervals and whatnot
            if (time < toTime + 2 * updateTimeInterval) 
            {
                if (time > toTime) { time = toTime; } //If overshot the time to plot to, restrict

                //Recursively defined plotting subroutine
                Bitmap currentFrame = (Bitmap)canvasContainer.Image;
                if (Object.Equals(currentFrame, null)) { currentFrame = new Bitmap(canvasContainer.Width, canvasContainer.Height); }

                canvasContainer.Image = RecursivePlot(currentFrame, prevTime, time, updateTimeInterval);
                prevTime = time;
                //Invoke the procedure to update the tabs
                List<Projectile> parameters = projectiles;
                Program.form1.Invoke(Program.form1.updateTabsDelegate, parameters);
            }
            else
            {
                stopwatch.Stop();
                refreshTimer.Stop();

                time = toTime;

                //Depending on system, the 

                //Raise plot complete event
                Program.form1.Invoke(Program.form1.plotCompleteDelegate);
                //Update time with max duration
                Program.form1.Invoke(Program.form1.updateTimeDelegate, toTime);
            }
        }

        public void AddProjectile(Projectile projectile)
        {
            projectiles.Add(projectile);
        }

        public void RemoveProjectile(string name)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].colour.Name == name) { projectiles.RemoveAt(i); }
            }
               
        }

        private void GetMaxValues()
        {
            //initialise variables as 0
            maxDuration = maxHeight = maxRange = maxX = maxY = 0;

            foreach (var projectile in this.projectiles)
            {
                if (projectile.apex.vertical > maxHeight) { maxHeight = projectile.apex.vertical; }
                if (projectile.range > maxRange) { maxRange = projectile.range; }
                if (projectile.duration > maxDuration) { maxDuration = projectile.duration; }

                maxX = (int)(maxRange * pxPerX);
                maxY = (int)(maxHeight * pxPerY);
            }
        }
    }
}