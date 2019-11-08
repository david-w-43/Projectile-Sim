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

    public enum SimulationSpeed { RealTime, Custom, NoAnimation}
    
    //struct PointInformation {
    //    public Vector position;
    //    public Color colour;
    //}

    public class Simulation
    {
        /* Variables----------*/

        //Stores the projectiles
        public readonly List<Projectile> projectiles = new List<Projectile>();

		//Stores the maximum values
        private double maxHeight, maxRange, maxDuration;
        private int maxY, maxX;

        //Stores scales, in pixels per metre
        private readonly double pxPerX = 1;
        private readonly double pxPerY = 1;
        private const int updatesPerPixel = 3;
        private double updateTimeInterval;

        //Defines PictureBox and timer/stopwatch
        private PictureBox canvasContainer;
		private System.Timers.Timer refreshTimer;
        private System.Diagnostics.Stopwatch stopwatch;
        private double prevTime;

		/* End variables------------- */

		public void StartAnimation(SimulationSpeed simulationSpeed)
        {
            //Get the maximum values and update interval
            GetMaxValues();
            updateTimeInterval = maxDuration / (maxX * updatesPerPixel);

            //Instantiates timer and stopwatch for use, timer defaults to 16 ms (60 Hz)
            refreshTimer = new System.Timers.Timer((int)(1000/60));
            stopwatch = new System.Diagnostics.Stopwatch();

			//Timer triggers canvas refresh, and automatically resets
            //Currently disabled so that it does not run the same code simultaneously
            //refreshTimer.AutoReset = true;

			//Gets the PictureBox from Form1
			this.canvasContainer = (PictureBox)Program.form1.Controls.Find("pictureBoxPlot", true).First();

            //Resets the previous time to 0
            prevTime = 0;

            switch (simulationSpeed)
            {
                case SimulationSpeed.RealTime:
                    //Use stopwatch to get time while plotting
                    //Use timer to trigger updates
                    refreshTimer.Elapsed += RealTime;
                    refreshTimer.Start();
                    stopwatch.Reset();
                    stopwatch.Start();
                    break;
                case SimulationSpeed.Custom:
                    //Experimental, recursive plot
                    canvasContainer.Image = RecursivePlot(new Bitmap(canvasContainer.Width, canvasContainer.Height), 0, maxDuration, updateTimeInterval);
                    break;
                case SimulationSpeed.NoAnimation:
                    //Create canvas with all points plotted
                    canvasContainer.Image = RecursivePlot(new Bitmap(canvasContainer.Width, canvasContainer.Height), 0, maxDuration, updateTimeInterval);
                    break;
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
            if (time < toTime)
            {
                //Building on top of previous image
                Bitmap currentImage = prevImage;
                //Loop through projectiles
                foreach (var projectile in projectiles)
                {
                    //Update time, calculate scaled positions to plot
                    projectile.Update(time);
                    int x = (int)((projectile.displacement.horizontal) * pxPerX);
                    int y = canvasContainer.Height - (int)((projectile.displacement.vertical) * pxPerY);

                    //If valid to plot
                    if (x >= 0 && x < prevImage.Width && y >= 0 && y < prevImage.Height)
                    {
                        //Set pixel to colour of projectile
                        currentImage.SetPixel(x, y, projectile.colour);
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

        private void RealTime(Object source, ElapsedEventArgs e)
        {
            //Use stopwatch to get time while plotting
            //Convert time to seconds
            double time = stopwatch.ElapsedMilliseconds / 1000;

            if (time < maxDuration)
            {
                //Recursively defined plotting subroutine
                Bitmap currentFrame = (Bitmap)canvasContainer.Image;
                if (Object.Equals(currentFrame, null)) { currentFrame = new Bitmap(canvasContainer.Width, canvasContainer.Height); }
                canvasContainer.Image = RecursivePlot(currentFrame, prevTime, time, updateTimeInterval);
                prevTime = time;

                //Start timer again
                refreshTimer.Start();
            }
            else
            {
                stopwatch.Stop();
                refreshTimer.Stop();
            }

            
        }

        public void AddProjectile(Projectile projectile)
        {
            projectiles.Add(projectile);
        }

        private void GetMaxValues()
        {
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
