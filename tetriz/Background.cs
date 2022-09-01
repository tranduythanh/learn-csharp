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
            Matrix bMatrix = block.Structure;
            for (int row = 0; row < bMatrix.Height(); row++)
            {
                for (int col = 0; col < bMatrix.Width(); col++)
                {
                    if (bMatrix[row][col] != Const.X)
                    {
                        continue;
                    }
                    int pRow = (int)(block.OffsetY + row);
                    int pCol = (int)(block.OffsetX + col);
                    if (IsValidPixel(pRow, pCol))
                    {
                        frame[pRow][pCol] = Const.X;
                    }
                }
            }
            return frame;
        }

        private Boolean IsValidPixel(int row, int col)
        {
            return
                row >= 0 &&
                col >= 0 &&
                row < this._matrix.Height() &&
                col < this._matrix.Width();
        }

        public void MergeBlock(IBlock block)
        {
            Matrix newMatrix = TryToMergeBlock(block);
            this._matrix = newMatrix;
        }

        public Boolean CanMoveDown(IBlock block)
        {
            block.MoveDown();
            if (IsOutOfMarginBottom(block) || HasCollision(block))
            {
                block.MoveUp();
                return false;
            };
            block.MoveUp();
            return true;
        }

        public Boolean IsOutOfMargin(IBlock block)
        {
            return
                IsOutOfMarginBottom(block) ||
                IsOutOfMarginLeft(block) ||
                IsOutOfMarginRight(block);
        }

        public Boolean IsOutOfMarginLeft(IBlock block)
        {
            return block.OffsetX < 0;
        }

        public Boolean IsOutOfMarginRight(IBlock block)
        {
            long maxRight = block.OffsetX + block.Structure.Width();
            return maxRight > this._matrix.Width();
        }

        public Boolean IsOutOfMarginBottom(IBlock block)
        {
            long maxBottom = block.OffsetY + block.Structure.Height();
            return maxBottom > this._matrix.Height();
        }

        public Boolean HasCollision(IBlock block)
        {
            Matrix bMatrix = block.Structure;
            for (int row = 0; row < bMatrix.Height(); row++)
            {
                for (int col = 0; col < bMatrix.Width(); col++)
                {
                    if (bMatrix[row][col] != Const.X)
                    {
                        continue;
                    }
                    int pRow = (int)(block.OffsetY + row);
                    int pCol = (int)(block.OffsetX + col);
                    if (IsValidPixel(pRow, pCol))
                    {
                        if (this._matrix[pRow][pCol] == Const.X)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Show()
        {
            this._matrix.Print();
        }
    }
}