namespace Tetriz
{
    class BlockO : IBlock
    {
        private BlockData _data;

        public BlockO()
        {
            Matrix matrix = new Matrix() {
                new List<String>() {AtomBlock.x, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x},
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