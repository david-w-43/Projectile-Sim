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
    
    struct PointInformation {
        public Vector position;
        public Color colour;
    }

    public class Simulation
    {

        //public readonly Projectile[] arrayProjectile = new Projectile[];
        public readonly List<Projectile> projectiles = new List<Projectile>();
        public Queue<Bitmap> frameQueue = new Queue<Bitmap>();
        public double time;
        public readonly double timescale;
        public Bitmap canvas;
        private System.Timers.Timer refreshTimer;
        private double refreshTime = Math.Round((double)(1000 / 60));
        private Queue<PointInformation> points = new Queue<PointInformation>();
        //public double interval = 0.01;
        private SimulationSpeed simulationSpeed;

        private double maxHeight, maxRange, maxDuration;

        private double CalculateInterval()
        {
            //Use x scale to calculate update interval
            double interval = /* xscale * */ 0.01;

            return interval;
        }

        private void PopulateFrameQueue()
        {
            frameQueue.Clear();

            Bitmap newCanvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            if (points.Count != 0) //If there are still point to plot
            {
                for (int i = 0; i < projectiles.Count; i++) //For each projectile
                {
                    PointInformation toPlot = points.Dequeue(); //Set and dequeue point

                    //Get positions from point as integer
                    int horizontal = (int)toPlot.position.horizontal;
                    int vertical = (int)(canvas.Height - 1 - toPlot.position.vertical); //Invert y axis as coords start from top left

                    //If it is within bounds of canvas
                    if (horizontal >= 0 && horizontal <= canvas.Width && vertical >= 0 && vertical <= canvas.Height)
                    {
                        //Set the canvas
                        canvas.SetPixel(horizontal, vertical, toPlot.colour);
                    }
                }
            }
        }
        
        private void PopulateQueue()
        {
            time = 0; //Set time to 0 so it can start plotting from the beginning
            double interval = CalculateInterval();
            points.Clear();
            double timePerX = maxDuration / maxRange;
            //interval = timePerX;
            
            while (time < maxDuration)
            {
                foreach (var projectile in projectiles)
                {
                    PointInformation toPlot;
                    toPlot.colour = projectile.colour;
                    projectile.Update(time);
                    toPlot.position = projectile.displacement;
                    points.Enqueue(toPlot);
                }
                //Increment time
                time += interval;
            }
        }

        public void AddProjectile(Projectile projectile)
        {
            projectiles.Add(projectile);
        }

        public void StartAnimation()
        {
            switch (simulationSpeed)
            {
                case SimulationSpeed.RealTime:
                    refreshTime = Math.Round((double)(1000 / 60)); //Refresh 60 times a second
                    //Plot with timer
                    break;
                case SimulationSpeed.NoAnimation:
                    //Plot points all at once
                    break;
                case SimulationSpeed.Custom:
                    Console.WriteLine("Custom speed called without parameter");
                    break;
                default:
                    break;
            }

            refreshTimer = new System.Timers.Timer(refreshTime);
            refreshTimer.Elapsed += RefreshCanvas;
            refreshTimer.AutoReset = true;
            refreshTimer.Enabled = true;

        }

        public void StartAnimation(ref PictureBox canvasContainer, SimulationSpeed speed)
        {

            simulationSpeed = speed;
            GetMaxValues();
            switch (simulationSpeed)
            {
                case SimulationSpeed.RealTime:
                    refreshTime = Math.Round((double)(1000 / 60)); //Refresh 60 times a second

                    //Plot with timer
                    break;
                case SimulationSpeed.NoAnimation:
                    //Plot points all at once
                    break;
            }
            PopulateQueue();
            canvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            refreshTimer = new System.Timers.Timer(refreshTime);
            refreshTimer.Elapsed += RefreshCanvas;
            refreshTimer.AutoReset = true;
            refreshTimer.Enabled = true;
        }

        public void StartAnimation(ref PictureBox canvasContainer, SimulationSpeed speed, double refreshRate)
        {
            GetMaxValues();

            PopulateQueue();
            simulationSpeed = speed;
            canvas = new Bitmap(canvasContainer.Width, canvasContainer.Height);
            refreshTime = Math.Round(1000 / refreshRate);

            refreshTimer = new System.Timers.Timer(refreshTime);
            refreshTimer.Elapsed += RefreshCanvas;
            refreshTimer.AutoReset = true;
            refreshTimer.Enabled = true;
        }

        public void GetMaxValues()
        {
            foreach (var projectile in this.projectiles)
            {
                if (projectile.apex.vertical > maxHeight) { maxHeight = projectile.apex.vertical; }
                if (projectile.range > maxRange) { maxRange = projectile.range; }
                if (projectile.duration > maxDuration) { maxDuration = projectile.duration; }
            }
        }
        
        private void RefreshCanvas(Object source, ElapsedEventArgs e)
        {
            if (points.Count != 0) //If there are still point to plot
            {
                for (int i = 0; i < projectiles.Count; i++) //For each projectile
                {
                    try
                    {
                        PointInformation toPlot = points.Dequeue(); //Set and dequeue point
                        
                        //Get positions from point as integer
                        int horizontal = (int)toPlot.position.horizontal; 
                        int vertical = (int)(canvas.Height - 1 - toPlot.position.vertical); //Invert y axis as coords start from top left

                        //If it is within bounds of canvas
                        if (horizontal >= 0 && horizontal <= canvas.Width && vertical >= 0 && vertical <= canvas.Height)
                        {
                            //Set the canvas
                            canvas.SetPixel(horizontal, vertical, toPlot.colour);
                        }
                        
                    }
                    catch (Exception)
                    {
                        //do nothing hehe
                       // Console.WriteLine(exception.Message);
                        
                    }


                }


                Program.form1.UpdatePictureBox(ref canvas); //Update picture box with new points
            }
            else
            {
                refreshTimer.Enabled = false;
            }
        }


    }
}
