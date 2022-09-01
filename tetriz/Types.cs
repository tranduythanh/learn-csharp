namespace Tetriz
{
    struct Position
    {
        internal uint X;
        internal uint Y;

        public Position(uint x, uint y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    struct BlockData
    {
        internal Matrix Matrix;
        internal Position Offset;

        public BlockData(Matrix matrix, Position offset)
        {
            this.Matrix = matrix;
            this.Offset = offset;
        }
    }

    internal class Matrix : List<List<String>>
    {
        public int Height()
        {
            return this.Count();
        }

        public int Width()
        {
            if (this.Count() <= 0)
            {
                return 0;
            }
            return this[0].Count();
        }

        public void Empty(int width, int height)
        {
            this.Clear();
            for (int k = 0; k < height; k++)
            {
                List<String> newRow = new List<string>();
                for (int i = 0; i < width; i++)
                {
                    newRow.Add("");
                }
                this.Add(newRow);
            }
        }

        public Matrix Clone()
        {
            Matrix newMatrix = new Matrix();
            foreach (List<String> row in this)
            {
                List<String> newRow = new List<string>();
                foreach (String item in row)
                {
                    newRow.Add(item);
                }
                newMatrix.Add(newRow);
            }
            return newMatrix;
        }

        public void Print()
        {
            int i = 0;
            foreach (List<String> row in this)
            {
                Console.Write("{0,2} ", i);
                foreach (String item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                i++;
            }
        }
    };
}