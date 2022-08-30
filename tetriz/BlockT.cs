namespace Tetriz
{
    class BlockT : IBlock
    {
        public override List<List<String>> Data()
        {
            return new List<List<String>>() {
                new List<String>() {AtomBlock._, AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock.x, AtomBlock.x},
            };
        }
    }
}