namespace Tetriz
{
    class BlockO : IBlock
    {
        public override Matrix OriginStructure() => new Matrix() {
            new List<String>() {Const.X, Const.X},
            new List<String>() {Const.X, Const.X},
        };
    }
}