namespace Tetriz
{
    class BlockR : IBlock
    {
        public override Matrix Structure() => new Matrix() {
            new List<String>() {Const._, Const.X, Const.X},
            new List<String>() {Const.X, Const.X, Const._},
        };
    }
}
