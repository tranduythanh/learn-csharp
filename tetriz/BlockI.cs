namespace Tetriz
{
    class BlockI : IBlock
    {
        public override Matrix Structure() => new Matrix() {
            new List<String>() { Const.X },
            new List<String>() { Const.X },
            new List<String>() { Const.X },
            new List<String>() { Const.X },
        };
    }
}