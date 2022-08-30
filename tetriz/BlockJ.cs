namespace Tetriz
{
    class BlockJ : IBlock
    {
        public override List<List<String>> Data()
        {
            return new List<List<String>>() {
                new List<String>() {AtomBlock._, AtomBlock.x},
                new List<String>() {AtomBlock._, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x},
            };
        }
    }
}