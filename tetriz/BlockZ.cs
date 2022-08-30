namespace Tetriz
{
    class BlockZ : IBlock
    {
        private List<List<String>> _data;

        public BlockZ()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock.x},
            };
        }

        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}