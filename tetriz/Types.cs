namespace Tetriz
{
    struct Position
    {
        internal int X;
        internal int Y;

        public Position(int x, int y)
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

    internal class Matrix : List<List<String>> { };
}