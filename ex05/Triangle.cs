using System;

namespace ex05
{
    class Triangle
    {
        public double[] Edges { get; private set; } = { 0, 0, 0 };


        public Triangle(double a, double b, double c)
        {
            this.Edges[0] = a;
            this.Edges[1] = b;
            this.Edges[2] = c;

            if (a + b <= c || b + c <= a || c + a <= b)
            {
                throw new ArgumentException("Invalid triangle edges");
            }
        }


        public double Perimeter
        {
            get
            {
                double ret = 0;
                foreach (var edge in this.Edges)
                {
                    ret = ret + edge;
                }
                return ret;
            }
        }


        public double Area()
        {
            double p = this.Perimeter / 2;
            double heron = Math.Sqrt(
                p * (p - this.Edges[0]) * (p - this.Edges[1]) * (p - this.Edges[2])
            );
            return heron;
        }

        public bool IsSquare()
        {
            double a2 = Math.Pow(this.Edges[0], 2);
            double b2 = Math.Pow(this.Edges[1], 2);
            double c2 = Math.Pow(this.Edges[2], 2);
            double err = Math.Pow(10, -5);

            return
                a2 + b2 - c2 < err ||
                b2 + c2 - a2 < err ||
                c2 + a2 - b2 < err;
        }

        public string Type()
        {
            double a = this.Edges[0];
            double b = this.Edges[1];
            double c = this.Edges[2];


            if (a == b && b == c)
            {
                return "Tam giác đều";
            }

            bool square = this.IsSquare();
            bool balance = false;
            if (a == b || b == c || c == a)
            {
                balance = true;
            }

            if (balance && square)
            {
                return "Tam giác vuông cân";
            }

            if (balance)
            {
                return "Tam giác cân";
            }

            if (square)
            {
                return "Tam giác vuông";
            }

            return "Tam giác thường";
        }
    }
}