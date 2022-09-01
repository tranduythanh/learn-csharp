namespace Tetriz
{
    class BlockI : IBlock
    {
        protected override Matrix OriginStructure() => new Matrix() {
            new List<String>() { Const.X },
            new List<String>() { Const.X },
            new List<String>() { Const.X },
            new List<String>() { Const.X },
        };
    }
}