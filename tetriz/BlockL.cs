namespace Tetriz
{
    class BlockL : IBlock
    {
        private List<List<String>> _data;

        public BlockL()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock.x},
            };
        }

        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}