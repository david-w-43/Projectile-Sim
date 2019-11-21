﻿using System;
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
        public Vector displacement, velocity, acceleration = new Vector(VectorType.component);
        public readonly Vector initDisplacement, initVelocity, initAcceleration = new Vector(VectorType.component);
        public readonly double range, duration;
        public readonly Vector apex = new Vector(VectorType.component);
        public readonly Color colour;
        public readonly ProjectileType projectileType;

        public Projectile(ProjectileType type, Color colour, Vector initVelocity, double initialHeight, double g)
        {
            this.projectileType = type;
            this.initVelocity = initVelocity;
            this.initDisplacement = new Vector(VectorType.component, 0, initialHeight);

            //Only implementing vertical acceleration for now
            acceleration = new Vector(VectorType.component, 0, g);
            this.initAcceleration = acceleration;

            this.colour = colour;

            //Set current values (may not be required)
            displacement = initDisplacement;
            velocity = initVelocity;
            
            //Projectile stops when vertical displacement from origin = 0
            // 0 = s0 + ut + 0.5at^2, 0.5at^2 + ut + s0
            duration = (-initVelocity.vertical - (Math.Sqrt((initVelocity.vertical * initVelocity.vertical) - (2 * acceleration.vertical * initDisplacement.vertical)))) / acceleration.vertical;
            range = GetDisplacement(duration).horizontal;
            
            //Apex is when vertical velocity = 0
            // u + at = 0, t = -u/a
            double apexTime = (-initVelocity.vertical / acceleration.vertical);
            this.apex = GetDisplacement(apexTime);    
        }

        private Vector GetDisplacement(double time)
        {
            // s = ut + 1/2 a t^2

            //Horizontal component
            double horizontal = initDisplacement.horizontal + (initVelocity.horizontal * time +
            ((acceleration.horizontal * time * time) / 2));

            //Vertical component
            double vertical = initDisplacement.vertical + (initVelocity.vertical * time +
            ((acceleration.vertical * time * time) / 2));

            Vector toReturn = new Vector(VectorType.component, horizontal, vertical);

            //If reached end of motion, set displacement as appropriate
            if (time > duration) { return GetDisplacement(duration); }

            this.displacement = toReturn;
            return toReturn;
        }

        private Vector GetVelocity(double time)
        {
            //v = u + at
            //Horizontal component
            double horizontal = initVelocity.horizontal + acceleration.horizontal * time;

            //Vertical component
            double vertical = initVelocity.vertical + acceleration.vertical * time;

            Vector toReturn = new Vector(VectorType.component, horizontal, vertical);

            //If reached end of motion, set velocity as appropriate
            if (time > duration) { return GetVelocity(duration); }

            this.velocity = toReturn;
            return toReturn;
        }

        public void Update(double time)
        {
            GetDisplacement(time);
            GetVelocity(time);
        }

    }
}
