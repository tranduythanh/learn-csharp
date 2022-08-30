namespace Tetriz
{
    class BlockT : IBlock
    {
        public override List<List<String>> Data()
        {
            return new List<List<String>>() {
                new List<String>() {AtomBlock.x},
                new List<String>() {AtomBlock.x},
                new List<String>() {AtomBlock.x},
                new List<String>() {AtomBlock.x},
            };
        }
    }
}