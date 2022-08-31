namespace Tetriz
{
    class BlockT : IBlock
    {
        private BlockData _data;

        public BlockT()
        {
            Matrix matrix = new Matrix() {
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock.x},
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