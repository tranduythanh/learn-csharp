namespace Tetriz
{
    class BlockI : IBlock
    {

        private BlockData _data;

        public BlockI()
        {
            Matrix matrix = new Matrix() {
                new List<String>() { AtomBlock.x },
                new List<String>() { AtomBlock.x },
                new List<String>() { AtomBlock.x },
                new List<String>() { AtomBlock.x },
            };

            Position pos = new Position(0, 0);

            _data = new BlockData(matrix, pos);
        }

        public override BlockData Data()
        {
            return this._data;
        }
    }
}