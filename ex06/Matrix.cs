namespace ex06
{
    class Matrix
    {
        public int n { get; private set; } = 1;
        public List<List<double>> Body { get; set; }

        public Matrix(int n, List<List<double>> body)
        {
            this.n = n;
            this.Body = body;
            if (
                this.Body.Count != this.n ||
                (this.n > 0 && this.Body[0].Count != this.n)
            )
                throw new Exception("invalid matrix body");
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.n != b.n)
                throw new Exception("matrix size mismatch");

            Matrix c = a.Clone();
            for (int i = 0; i < a.n; i++)
                for (int k = 0; k < a.n; k++)
                    c.Body[i][k] = a.Body[i][k] + b.Body[i][k];

            return c;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.n != b.n)
                throw new Exception("matrix size mismatch");
            Matrix c = a.Clone();
            for (int i = 0; i < a.n; i++)
                for (int k = 0; k < a.n; k++)
                    c.Body[i][k] = a.Body[i][k] - b.Body[i][k];

            return c;
        }

        private static double multiplyVector(List<double> a, List<double> b)
        {
            double ret = 0;
            for (int i = 0; i < a.Count; i++)
                ret += a[i] * b[i];
            return ret;
        }

        public Matrix Clone()
        {
            List<List<double>> body = new List<List<double>>();
            for (int i = 0; i < this.n; i++)
            {
                List<double> row = new List<double>();
                for (int k = 0; k < this.n; k++)
                {
                    row.Add(this.Body[i][k]);
                }
                body.Add(row);
            }
            return new Matrix(this.n, body);
        }

        public Matrix RemoveRowCol(int rowIndex, int colIndex)
        {
            Matrix a = this.Clone();
            for (int i = 0; i < a.n; i++)
                a.Body[i].RemoveAt(colIndex);
            a.Body.RemoveAt(rowIndex);
            a.n -= 1;
            return a;
        }

        public List<double> Col(int colIndex)
        {
            List<double> col = new List<double>();
            for (int i = 0; i < this.n; i++)
                col.Add(this.Body[i][colIndex]);
            return col;
        }

        public double Det()
        {
            if (this.n == 1)
            {
                return this.Body[0][0];
            }
            double det = 0;
            for (int i = 0; i < this.n; i++)
            {
                Matrix subMatrix = this.RemoveRowCol(0, i);
                det += Math.Pow(-1, i) * this.Body[0][i] * subMatrix.Det();
            }
            return det;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.n != b.n)
                throw new Exception("matrix size mismatch");

            Matrix c = a.Clone();

            for (int i = 0; i < a.n; i++)
                for (int k = 0; k < a.n; k++)
                    c.Body[i][k] = multiplyVector(a.Body[i], b.Col(k));

            return c;
        }


        public static explicit operator double(Matrix a)
        {
            return a.Det();
        }

        public void Debug()
        {
            if (this.n <= 0)
                return;

            for (int i = 0; i < this.n; i++)
            {
                for (int k = 0; k < this.n; k++)
                    Console.Write(String.Format("\t{0}", this.Body[i][k]));
                Console.WriteLine();
            }
        }
    }
}