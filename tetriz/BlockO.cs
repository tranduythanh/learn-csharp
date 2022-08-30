namespace Tetriz
{
    class BlockO : IBlock
    {
        public override List<List<String>> Data()
        {
            return new List<List<String>>() {
                new List<String>() {AtomBlock.x, AtomBlock.x},
                new List<String>() {AtomBlock.x, AtomBlock.x},
            };
        }
    }
}