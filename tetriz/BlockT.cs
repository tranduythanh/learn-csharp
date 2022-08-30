namespace Tetriz
{
    class BlockT : IBlock
    {
        private List<List<String>> _data;

        public BlockT()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock.x},
            };
        }

        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}