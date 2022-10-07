using System;

namespace ex05
{
    class Frac
    {
        private int tu, mau;

        public Frac(int tu, int mau)
        {
            this.tu = tu;
            this.mau = mau;
        }

        public Frac(int tu)
        {
            this.tu = tu;
            this.mau = 1;
        }

        public Frac()
        {
            this.tu = 0;
            this.mau = 1;
        }
    }
}