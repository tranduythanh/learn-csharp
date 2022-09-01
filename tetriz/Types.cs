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
        public uint Height()
        {
            return (uint)this.Count();
        }

        public uint Width()
        {
            if (this.Count() <= 0)
            {
                return 0;
            }
            return (uint)this[0].Count();
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
            foreach (List<String> row in this)
            {
                foreach (String item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
    };
}