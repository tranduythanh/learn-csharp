namespace Tetriz
{
    class BlockO : IBlock
    {
        protected override Matrix OriginStructure() => new Matrix() {
            new List<String>() {Const.X, Const.X},
            new List<String>() {Const.X, Const.X},
        };
    }
}