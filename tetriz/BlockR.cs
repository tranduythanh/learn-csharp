namespace Tetriz
{
    class BlockR : IBlock
    {
        private List<List<String>> _data;

        public BlockR()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock._},
            };
        }

        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}