namespace Tetriz
{
    class BlockL : IBlock
    {
        protected override Matrix OriginStructure() => new Matrix() {
            new List<String>() {Const.X, Const._},
            new List<String>() {Const.X, Const._},
            new List<String>() {Const.X, Const.X},
        };
    }
}