

namespace Tetriz
{

    abstract class IBlock
    {
        public abstract BlockData Data();

        public void Print()
        {
            BlockData bData = this.Data();
            foreach (List<String> row in bData.Matrix)
            {
                foreach (String item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Offset: [{0}, {1}]", bData.Offset.X, bData.Offset.Y);
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