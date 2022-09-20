namespace ex04
{
    class MyDate
    {
        private int _d = 1;
        private int _m = 1;
        private int _y = 2022;

        //                            1   2  3   4   5   6   7   8   9   10  11  12
        private static int[] dom = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public MyDate(int d, int m, int y)
        {
            if (m > 12 || m < 1)
            {
                throw new ArgumentException("invalid month");
            }
            if (d > DaysOfMonth(m, y))
            {
                throw new ArgumentException("invalid date of month");
            }
            this._d = d;
            this._m = m;
            this._y = y;
        }

        public bool IsLeapYear()
        {
            return IsLeapYear(this._y);
        }

        public int DaysOfMonth()
        {
            return DaysOfMonth(this._m, this._y);
        }

        public MyDate Next()
        {
            return Next(this._d, this._m, this._y);
        }

        override public string ToString()
        {
            return string.Format("{0,2:00}-{1,2:00}-{2,4:0000}", this._d, this._m, this._y);
        }

        static bool IsLeapYear(int y)
        {
            return y % 4 == 0;
        }

        static int DaysOfMonth(int m, int y)
        {
            if ((m == 2) && IsLeapYear(y))
            {
                return dom[m - 1] + 1;
            }
            return dom[m - 1];
        }

        static MyDate Next(int d, int m, int y)
        {
            MyDate date = new MyDate(d, m, y);
            if (d >= DaysOfMonth(m, y))
            {
                date._d = 1;
                date._m = date._m + 1;
                if (date._m > 12)
                {
                    date._m = 1;
                    date._y = date._y + 1;
                }
            }
            else
            {
                date._d = date._d + 1;
            }
            return date;
        }
    }
}