namespace Tetriz
{
    class BlockJ : IBlock
    {
        public override Matrix OriginStructure() => new Matrix() {
            new List<String>() {Const._, Const.X},
            new List<String>() {Const._, Const.X},
            new List<String>() {Const.X, Const.X},
        };
    }
}