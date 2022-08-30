namespace Tetriz
{
    class BlockO : IBlock
    {

        private List<List<String>> _data;

        public BlockO()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock.x, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x},
            };
        }

        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}