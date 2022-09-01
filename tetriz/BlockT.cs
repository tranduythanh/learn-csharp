namespace Tetriz
{
    class BlockT : IBlock
    {
        protected override Matrix OriginStructure() => new Matrix() {
            new List<String>() {Const._, Const.X, Const._},
            new List<String>() {Const.X, Const.X, Const.X},
        };
    }
}