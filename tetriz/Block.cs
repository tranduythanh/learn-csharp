

namespace Tetriz
{

    abstract class IBlock
    {
        public abstract Matrix Structure();
        public uint OffsetX { get; } = 0;
        public uint OffsetY { get; } = 0;

        public void Print()
        {
            Matrix matrix = this.Structure();
            matrix.Print();
            Console.WriteLine("Offset: [{0}, {1}]", this.OffsetX, this.OffsetY);
        }

        public void MoveDown()
        {

        }

        protected int[] Rotate90()
        {
            return new int[] { 1, 2 };
        }

        protected int[] Rotate180()
        {
            return new int[] { 1, 2 };
        }

        protected int[] Rotate270()
        {
            return new int[] { 1, 2 };
        }

        private BlockData Transpose(BlockData bData)
        {
            return new BlockData();
        }
    }
}