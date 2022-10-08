namespace ex06
{
    class Complex
    {
        public double Real { get; set; } = 0;
        public double Image { get; set; } = 0;

        public Complex(double r, double i)
        {
            this.Real = r;
            this.Image = i;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Image + b.Image);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Image - b.Image);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(
                a.Real * b.Real - a.Image * b.Image,
                a.Real * b.Image + a.Image * b.Real);
        }

        public double Modul()
        {
            return Math.Sqrt(Math.Pow(this.Real, 2) + Math.Pow(this.Image, 2));
        }

        public Complex Cocomplex()
        {
            return new Complex(this.Real, -this.Image);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            Complex up = (a * b.Cocomplex());
            double down = Math.Pow(b.Modul(), 2);
            return new Complex(up.Real / down, up.Image / down);
        }

        public static explicit operator double(Complex a)
        {
            if (a.Image == 0)
            {
                return a.Real;
            }
            return 0;
        }

        public static implicit operator string(Complex a)
        {
            if (a.Image > 0)
                return String.Format("{0}+{1}i", a.Real, a.Image);
            return String.Format("{0}{1}i", a.Real, a.Image);
        }
    }
}