namespace Tetriz
{
    class BlockL : IBlock
    {
        public override List<List<String>> Data()
        {
            return new List<List<String>>() {
                new List<String>() {AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock._},
                new List<String>() {AtomBlock.x, AtomBlock.x},
            };
        }
    }
}