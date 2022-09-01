namespace Tetriz
{
    class BlockL : IBlock
    {
        public override Matrix Structure() => new Matrix() {
            new List<String>() {Const.X, Const._},
            new List<String>() {Const.X, Const._},
            new List<String>() {Const.X, Const.X},
        };
    }
}