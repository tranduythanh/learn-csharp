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
}