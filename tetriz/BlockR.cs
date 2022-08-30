namespace Tetriz
{
    class BlockR : IBlock
    {
        public override List<List<String>> Data()
        {
            return new List<List<String>>() {
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock._},
            };
        }
    }
}