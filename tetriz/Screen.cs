namespace Tetriz
{
    class Screen
    {
        private ScoreBoard _scoreBoard;
        private Background _background;
        private IBlock _currentBlock;
        private IBlock _nextBlock;

        private uint _width;
        private uint _height;

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
            int blockIndex = rnd.Next(0, this._blockList.Count);
            Console.WriteLine("{0} / {1}", blockIndex, this._blockList.Count);
            return this._blockList.ElementAt(blockIndex);
        }

        public Screen(uint width, uint height)
        {
            this._scoreBoard = new ScoreBoard();
            this._background = new Background(
                Const.DefaultScreenWidth,
                Const.DefaultScreenHeight);
            this._currentBlock = this._randomBlock();
            this._nextBlock = this._randomBlock();
            this._width = width;
            this._height = height;
        }

        public void HandleKey(ConsoleKey key)
        {
            Console.WriteLine(key);
        }

        public void Run()
        {
            this._currentBlock.Print();
            this._nextBlock.Print();
            Matrix frame = this._background.TryToMergeBlock(this._currentBlock);
            frame.Print();
            while (true)
            {
                System.Threading.Thread.Sleep(Const.FrameDelay);
            }
        }
    }
}