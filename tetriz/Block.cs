

namespace Tetriz
{

    abstract class IBlock
    {
        protected abstract Matrix OriginStructure();
        public Matrix Structure { get; private set; }
        public int OffsetX { get; private set; } = 0;
        public int OffsetY { get; private set; } = 0;

        protected IBlock()
        {
            if (this.Structure == null)
            {
                this.Structure = this.OriginStructure();
            }
        }


        public void Print()
        {
            Matrix matrix = this.Structure;
            matrix.Print();
            // Console.WriteLine("Offset: [{0,2}, {1,2}]", this.OffsetX, this.OffsetY);
            // Console.WriteLine("Width:  {0,2}", this.Structure.Width());
            // Console.WriteLine("Height: {0,2}", this.Structure.Height());
        }

        public void ToHighestPosition()
        {
            lock (this)
            {
                this.OffsetY = -this.Structure.Height();
            }
        }

        public void ToCenterX(int width)
        {
            lock (this)
            {
                this.OffsetX = width / 2 - 1 - (int)this.Structure.Width() / 2;
            }
        }

        public void MoveDown()
        {
            lock (this)
            {
                this.OffsetY += 1;
            }
        }

        public void MoveUp()
        {
            lock (this)
            {
                this.OffsetY -= 1;
            }
        }

        public void MoveLeft()
        {
            lock (this)
            {
                this.OffsetX -= 1;
            }
        }

        public void MoveRight()
        {
            lock (this)
            {
                this.OffsetX += 1;
            }
        }

        public void RotateRight()
        {
            lock (this)
            {
                Transpose();
                Mirror();
            }
        }

        public void RotateLeft()
        {
            RotateRight();
            RotateRight();
            RotateRight();
        }

        private void Transpose()
        {
            Matrix newStructure = new Matrix();
            newStructure.Empty(
                this.Structure.Height(),
                this.Structure.Width());

            for (int row = 0; row < this.Structure.Height(); row++)
            {
                for (int col = 0; col < this.Structure.Width(); col++)
                {
                    newStructure[col][row] = this.Structure[row][col];
                }
            }
            this.Structure = newStructure;
        }
        private void Mirror()
        {
            Matrix newStructure = new Matrix();
            newStructure.Empty(
                this.Structure.Width(),
                this.Structure.Height());

            for (int row = 0; row < this.Structure.Height(); row++)
            {
                for (int col = 0; col < this.Structure.Width(); col++)
                {
                    int newCol = this.Structure.Width() - col - 1;
                    newStructure[row][newCol] = this.Structure[row][col];
                }
            }
            this.Structure = newStructure;
        }

        // Note!!!: Cannot clone method OriginStructure
        public IBlock Clone()
        {
            IBlock newBlock = new BlockT();
            newBlock.Structure = this.Structure;
            newBlock.OffsetX = this.OffsetX;
            newBlock.OffsetY = this.OffsetY;
            return newBlock;
        }
    }
}