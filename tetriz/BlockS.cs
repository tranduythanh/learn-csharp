namespace Tetriz
{
    class BlockS : IBlock
    {
        protected override Matrix OriginStructure() => new Matrix() {
            new List<String>() {Const._, Const.X, Const.X},
            new List<String>() {Const.X, Const.X, Const._},
        };
    }
}
