namespace Tetriz
{
    class BlockT : IBlock
    {
        public override Matrix Structure() => new Matrix() {
            new List<String>() {Const._, Const.X, Const._},
            new List<String>() {Const.X, Const.X, Const.X},
        };
    }
}