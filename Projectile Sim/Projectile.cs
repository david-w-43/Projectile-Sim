using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Projectile_Sim
{

    public enum ProjectileType { speed, component, energy }

    public class Projectile
    {
        public  Vector displacement, velocity, acceleration = new Vector(VectorType.component);
        private Vector initDisplacement, initVelocity = new Vector(VectorType.component);
        public  double range, duration;
        public  Vector apex = new Vector(VectorType.component);
        public  Color colour;

        public Projectile(ProjectileType type, Color colour, double parm1, double parm2, double parm3, double parm4)
        {

            //3 = initial height
            //4 = g

            initDisplacement = new Vector(VectorType.component, 0, parm3);

            //Only implementing vertical acceleration for now
            acceleration = new Vector(VectorType.component, 0, -parm4);

            this.colour = colour;

            switch (type)
            {
                case ProjectileType.speed:
                    initVelocity = new Vector(VectorType.magnitude, parm1, parm2);
                    break;
                case ProjectileType.component:
                    initVelocity = new Vector(VectorType.component, parm1, parm2);
                    break;
                case ProjectileType.energy:
                    //placeholder
                    break;
            }

            //Set current values (may not be required)
            displacement = initDisplacement;
            velocity = initVelocity;

            //Apex is when vertical velocity = 0
            // u + at = 0, t = -u/a
            double tempTime = (-initVelocity.vertical / acceleration.vertical);
            this.apex = GetDisplacement(tempTime);

            //Projectile stops when vertical displacement from origin = 0
            // 0 = s0 + ut + 0.5at^2, 0.5at^2 + ut + s0
            tempTime = (-initVelocity.vertical - (Math.Sqrt((initVelocity.vertical * initVelocity.vertical) - (2 * acceleration.vertical * initDisplacement.vertical)))) / acceleration.vertical;

            duration = tempTime;
            range = GetDisplacement(tempTime).horizontal;

        }

        private Vector GetDisplacement(double time)
        {
            // s = ut + 1/2 a t^2
            Vector toReturn = new Vector(VectorType.component)
            {
                //Horizontal component
                horizontal = initDisplacement.horizontal + (initVelocity.horizontal * time +
                ((acceleration.horizontal * time * time) / 2)),

                //Vertical component
                vertical = initDisplacement.vertical + (initVelocity.vertical * time +
                ((acceleration.vertical * time * time) / 2))
            };


            this.displacement = toReturn;
            return toReturn;
        }

        private Vector UpdateVelocity(double time)
        {
            //v = u + at
            Vector toReturn = new Vector(VectorType.component)
            {

                //Horizontal component
                horizontal = initVelocity.horizontal + acceleration.horizontal * time,

                //Vertical component
                vertical = initVelocity.vertical + acceleration.vertical * time
            };

            this.velocity = toReturn;
            return toReturn;
        }

        public void Update(double time)
        {
            GetDisplacement(time);
            UpdateVelocity(time);
        }

    }
}
