namespace Tetriz
{
    class Screen
    {
        private ScoreBoard _scoreBoard;
        private Background _background;
        private IBlock _currentBlock;
        private IBlock _nextBlock;

        private ConsoleKey _keyPressed;

        private int _width;
        private int _height;

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

        public Screen(int width, int height)
        {
            this._scoreBoard = new ScoreBoard();
            this._background = new Background(
                Const.DefaultScreenWidth,
                Const.DefaultScreenHeight);
            this._currentBlock = this._randomBlock();
            this._nextBlock = this._randomBlock();
            this._width = width;
            this._height = height;

            // set init position to block
            this._currentBlock.ToCenterX(this._width);
            this._currentBlock.ToHighestPosition();
        }

        public void HandleKey(ConsoleKey key)
        {
            lock (this)
            {
                _HandleKey(key);
            }
        }

        private void _HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    this._currentBlock.MoveLeft();
                    if (this._background.IsOutOfMarginLeft(this._currentBlock))
                        this._currentBlock.MoveRight();
                    Draw();
                    break;

                case ConsoleKey.RightArrow:
                    this._currentBlock.MoveRight();
                    if (this._background.IsOutOfMarginRight(this._currentBlock))
                        this._currentBlock.MoveLeft();
                    Draw();
                    break;

                case ConsoleKey.UpArrow:
                    this._currentBlock.Rotate90();
                    if (this._background.IsOutOfMarginLeft(this._currentBlock))
                        this._currentBlock.MoveRight();
                    if (this._background.IsOutOfMarginRight(this._currentBlock))
                        this._currentBlock.MoveLeft();
                    if (this._background.IsOutOfMarginBottom(this._currentBlock))
                        this._currentBlock.MoveUp();
                    Draw();
                    break;

                case ConsoleKey.Spacebar:
                case ConsoleKey.DownArrow:
                    while (true)
                    {
                        if (this._background.CanMoveDown(this._currentBlock))
                            this._currentBlock.MoveDown();
                        else
                        {
                            PrepareForNextTurn();
                            break;
                        }
                    }
                    Draw();
                    break;

                default:
                    break;
            }
            this._keyPressed = key;
        }

        private void Draw()
        {
            Console.Clear();
            Matrix frame = this._background.TryToMergeBlock(this._currentBlock);
            frame.Print();
            Console.WriteLine();
            this._currentBlock.Print();
            Console.WriteLine("Key {0}", this._keyPressed.ToString());
            Console.WriteLine();
        }

        private void PrepareForNextTurn()
        {
            this._background.MergeBlock(this._currentBlock);
            this._currentBlock = this._nextBlock;
            this._currentBlock.ToCenterX(this._width);
            this._currentBlock.ToHighestPosition();
            this._nextBlock = _randomBlock();
        }

        public void Run()
        {
            Draw();
            while (true)
            {
                System.Threading.Thread.Sleep(Const.FrameDelay);
                lock (this)
                {
                    if (this._background.CanMoveDown(this._currentBlock))
                    {
                        this._currentBlock.MoveDown();
                    }
                    else
                    {
                        PrepareForNextTurn();
                    }
                    Draw();
                }
            }
        }
    }
}