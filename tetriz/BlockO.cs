namespace Tetriz
{
    class BlockO : IBlock
    {
        public override Matrix Structure() => new Matrix() {
            new List<String>() {Const.X, Const.X},
            new List<String>() {Const.X, Const.X},
        };
    }
}