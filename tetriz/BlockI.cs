namespace Tetriz
{
    class BlockI : IBlock
    {

        private List<List<String>> _data;

        public BlockI()
        {
            _data = new List<List<String>>() {
                new List<String>() {AtomBlock.x},
                new List<String>() {AtomBlock.x},
                new List<String>() {AtomBlock.x},
                new List<String>() {AtomBlock.x},
            };
        }


        public override List<List<String>> Data()
        {
            return this._data;
        }
    }
}