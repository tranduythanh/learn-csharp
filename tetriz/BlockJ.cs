namespace Tetriz
{
    class BlockJ : IBlock
    {
        private List<List<String>> _data;

        public BlockJ()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock._, AtomBlock.x},
                new List<String>() {AtomBlock._, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x},
            };
        }


        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}