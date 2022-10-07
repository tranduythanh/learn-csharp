using System;

namespace ex05
{
    class Cylinder
    {
        public double H { get; private set; } = 0;
        public double R { get; private set; } = 0;

        public double BottomArea
        {
            get
            {
                return Math.PI * Math.Pow(this.R, 2);
            }
        }
        public double SurroundArea
        {
            get
            {
                return 2 * Math.PI * this.R * this.H;
            }
        }
        public double Volume
        {
            get
            {
                return this.BottomArea * this.H;
            }
        }


        public Cylinder(double h, double r)
        {
            this.H = h;
            this.R = r;
        }
    }
}