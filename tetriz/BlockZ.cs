namespace Tetriz
{
    class BlockZ : IBlock
    {
        public override Matrix Structure() => new Matrix() {
            new List<String>() {Const.X, Const.X, Const._},
            new List<String>() {Const._, Const.X, Const.X},
        };
    }
}