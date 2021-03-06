﻿using System;
using System.Drawing;

namespace Projectile_Sim
{
    public enum ProjectileType { speed, component, energy }

    public class Projectile
    {
        // Define variables that will change after constructor
        private Vector displacement, velocity, acceleration = new Vector(VectorType.component);
        private double kineticEnergy, gpEnergy;

        // Define readonly variables
        public readonly Vector initDisplacement, initVelocity, initAcceleration = new Vector(VectorType.component);
        public readonly double range, duration;
        public readonly Vector apex = new Vector(VectorType.component);
        public readonly Color colour;
        public readonly ProjectileType projectileType;
        public readonly double mass;

        public Projectile(ProjectileType type, Color colour, Vector initVelocity, Vector initDisplacement, Vector initAcceleration, double mass)
        {
            // Constructor

            // Set local variables from parameters
            this.projectileType = type;
            this.initVelocity = initVelocity;
            this.initDisplacement = initDisplacement;
            this.mass = mass;

            // Only implementing vertical acceleration for now
            this.initAcceleration = initAcceleration;
            //Constant acceleration
            acceleration = initAcceleration;

            // Set the colour
            this.colour = colour;

            // Calculate current values for time = 0
            Update(0);

            // Projectile stops when vertical displacement from origin = 0
            // 0 = s0 + ut + 0.5at^2, 0.5at^2 + ut + s0
            duration = (-initVelocity.vertical - (Math.Sqrt((initVelocity.vertical * initVelocity.vertical) - (2 * acceleration.vertical * initDisplacement.vertical)))) / acceleration.vertical;
            range = GetDisplacement(duration).horizontal;

            // Apex is when vertical velocity = 0
            // u + at = 0, t = -u/a
            double apexTime = (-initVelocity.vertical / acceleration.vertical);
            this.apex = GetDisplacement(apexTime);
        }

        public Vector GetDisplacement() { return displacement; }

        public Vector GetVelocity() { return velocity; }

        public Vector GetDisplacement(double time)
        {
            // s = ut + 1/2 a t^2

            // Horizontal component
            double horizontal = initDisplacement.horizontal + (initVelocity.horizontal * time +
            ((acceleration.horizontal * time * time) / 2));

            // Vertical component
            double vertical = initDisplacement.vertical + (initVelocity.vertical * time +
            ((acceleration.vertical * time * time) / 2));

            Vector toReturn = new Vector(VectorType.component, horizontal, vertical);

            // If reached end of motion, set displacement as appropriate
            if (time > duration) { return GetDisplacement(duration); }

            this.displacement = toReturn;
            return toReturn;
        }

        public Vector GetVelocity(double time)
        {
            // v = u + at
            // Horizontal component
            double horizontal = initVelocity.horizontal + acceleration.horizontal * time;

            // Vertical component
            double vertical = initVelocity.vertical + acceleration.vertical * time;

            Vector toReturn = new Vector(VectorType.component, horizontal, vertical);

            // If reached end of motion, set velocity as appropriate
            if (time > duration) { return GetVelocity(duration); }

            this.velocity = toReturn;
            return toReturn;
        }

        public void Update(double time)
        {
            // Single call to get all the variables
            GetDisplacement(time);
            GetVelocity(time);
            GetKineticEnergy(time);
            GetGPEnergy(time);
        }

        public double GetKineticEnergy(double time)
        {
            // Calculate the kinetic energy
            this.kineticEnergy = 0.5 * mass * velocity.magnitude * velocity.magnitude;
            return this.kineticEnergy;
        }

        public double GetGPEnergy(double time)
        {
            //Calculate potential energy using acceleration due to gravity as g
            this.gpEnergy = mass * Math.Abs(initAcceleration.vertical) * displacement.vertical;
            return this.gpEnergy;
        }

        public double GetKineticEnergy() { return kineticEnergy; }

        public double GetGPEnergy() { return gpEnergy; }
    }
}
