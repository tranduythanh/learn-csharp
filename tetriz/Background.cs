namespace Tetriz
{
    class Background
    {
        private Matrix _matrix;

        public Background(uint width, uint height)
        {
            this._matrix = Init_matrix(width, height);
        }

        private Matrix Init_matrix(uint width, uint height)
        {
            Matrix _matrix = new Matrix();
            for (int r = 0; r < height; r++)
            {
                List<String> row = new List<String>();
                for (int i = 0; i < width; i++)
                {
                    row.Add(Const.Dot);
                }
                _matrix.Add(row);
            }
            return _matrix;
        }

        public Matrix TryToMergeBlock(IBlock block)
        {
            Matrix frame = this._matrix.Clone();
            Matrix bMatrix = block.Structure();
            for (int row = 0; row < bMatrix.Height(); row++)
            {
                for (int col = 0; col < bMatrix.Width(); col++)
                {
                    int pixelX = (int)(block.OffsetX + row);
                    int pixelY = (int)(block.OffsetY + col);
                    if (bMatrix[row][col] != Const.X)
                    {
                        continue;
                    }
                    frame[pixelX][pixelY] = Const.X;
                }
            }
            return frame;
        }

        public void Show()
        {
            this._matrix.Print();
        }
    }
}