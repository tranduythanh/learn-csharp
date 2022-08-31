namespace Tetriz
{
    class BlockR : IBlock
    {
        private BlockData _data;

        public BlockR()
        {
            Matrix matrix = new Matrix() {
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock._},
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
