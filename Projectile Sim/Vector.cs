using System;

namespace Projectile_Sim
{
    public enum VectorType { component, magnitude } // Enumerator for vector formats

    public class Vector
    {
        // Readonly variables cannot be changed outside the constructor
        public readonly double horizontal, vertical, magnitude, direction;
        public readonly VectorType type;

        public Vector() => this.type = VectorType.component; // Default vector type, unused

        public Vector(VectorType type) => this.type = type;

        public Vector(VectorType type, double parm1, double parm2)
        {
            // Constructor

            this.type = type;

            // Convert and store vector in the alternative format
            if (type == VectorType.component)
            {
                horizontal = parm1;
                vertical = parm2;
                magnitude = Math.Sqrt(horizontal * horizontal + vertical * vertical);
                if (horizontal != 0) { direction = Math.Atan(vertical / horizontal); }
                else if (vertical > 0) { direction = Math.PI / 2; }
                else if (vertical < 0) { direction = -Math.PI / 2; }
            }
            else if (type == VectorType.magnitude)
            {
                magnitude = parm1;
                direction = parm2;
                horizontal = Math.Cos(direction) * magnitude;
                vertical = Math.Sin(direction) * magnitude;
            }
        }

    }
}
