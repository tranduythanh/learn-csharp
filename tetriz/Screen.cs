namespace Tetriz
{


    class Screen
    {
        private ScoreBoard _scoreBoard;
        private Background _background;
        private IBlock _currentBlock;
        private IBlock _nextBlock;

        private List<IBlock> _blockList = new List<IBlock>()
        {
            new BlockI(),
            new BlockJ(),
            new BlockL(),
            new BlockO(),
            new BlockR(),
            new BlockT(),
            new BlockZ(),
        };

        private IBlock _randomBlock()
        {
            Random rnd = new Random();
            int blockIndex = rnd.Next(0, this._blockList.Capacity);
            return this._blockList.ElementAt(blockIndex);
        }

        public Screen()
        {
            this._scoreBoard = new ScoreBoard();
            this._background = new Background();
            this._currentBlock = this._randomBlock();
            this._nextBlock = this._randomBlock();
        }

        public void Run()
        {
            this._currentBlock.Print();
            this._nextBlock.Print();
        }
    }
}