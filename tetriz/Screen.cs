namespace Tetriz
{
    class Screen
    {
        private int _score;
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

            IBlock newBlock = this._blockList.ElementAt(blockIndex);
            int rotateCount = rnd.Next(0, 4);
            for (int i = 0; i < rotateCount; i++)
            {
                newBlock.RotateRight();
            }
            return newBlock;
        }

        public Screen(int width, int height)
        {
            this._score = 0;
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
                Console.Beep();
            }
        }

        private void _HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    this._currentBlock.MoveLeft();
                    if (
                        this._background.IsOutOfMarginLeft(this._currentBlock) ||
                        this._background.HasCollision(this._currentBlock))
                    {
                        this._currentBlock.MoveRight();
                    }
                    Draw();
                    break;

                case ConsoleKey.RightArrow:
                    this._currentBlock.MoveRight();
                    if (
                        this._background.IsOutOfMarginRight(this._currentBlock) ||
                        this._background.HasCollision(this._currentBlock))
                    {
                        this._currentBlock.MoveLeft();
                    }
                    Draw();
                    break;

                case ConsoleKey.UpArrow:
                    this._currentBlock.RotateRight();
                    if (
                        this._background.IsOutOfMargin(this._currentBlock) ||
                        this._background.HasCollision(this._currentBlock))
                    {
                        this._currentBlock.RotateLeft();
                    }

                    Draw();
                    break;

                case ConsoleKey.DownArrow:
                    if (this._background.CanMoveDown(this._currentBlock))
                    {
                        this._currentBlock.MoveDown();
                    }
                    else
                    {
                        PrepareForNextTurn();
                    }
                    Draw();
                    break;

                case ConsoleKey.Spacebar:
                    while (true)
                    {
                        if (this._background.CanMoveDown(this._currentBlock))
                        {
                            this._currentBlock.MoveDown();
                        }
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

            // Info panel
            Console.WriteLine("Next block:");
            int padSize = 4 - this._nextBlock.Structure.Height();
            for (int i = 0; i < padSize; i++)
            {
                Console.WriteLine();
            }
            this._nextBlock.Print();
            // Console.WriteLine("Latest Key Pressed {0}", this._keyPressed.ToString());
            Console.WriteLine();
            Console.WriteLine("Score {0}", this._score);
            Console.WriteLine();

            // Game panel
            Matrix frame = this._background.TryToMergeBlock(this._currentBlock);
            frame.Print();
            Console.WriteLine();

            Console.WriteLine(Const.TextGuide);
            Console.WriteLine();
        }

        private void PrepareForNextTurn()
        {
            lock (this)
            {
                this._background.MergeBlock(this._currentBlock);
                Scoring();
                this._currentBlock = this._nextBlock.Clone();
                this._nextBlock = _randomBlock();
                this._currentBlock.ToCenterX(this._width);
                this._currentBlock.ToHighestPosition();

                if (!this._background.CanMoveDown(this._currentBlock))
                {
                    GameOver();
                }
            }
        }

        private void Scoring()
        {
            int delta = this._background.CountFilledRows();
            if (delta > 0)
            {
                this._score += delta;
                this._background.EraseFilledRows();
                Console.Beep();
            }
        }

        private void GameOver()
        {
            Draw();
            Console.WriteLine(Const.TextGameOver);
            Console.CursorVisible = true;
            System.Environment.Exit(0);
        }


        public Boolean MoveDownAndCheck()
        {
            if (this._background.CanMoveDown(this._currentBlock))
            {
                this._currentBlock.MoveDown();
                if (!this._background.CanMoveDown(this._currentBlock))
                {
                    PrepareForNextTurn();
                }
            }
            else
            {
                PrepareForNextTurn();
                return false;
            }
            return true;
        }

        public void Run()
        {
            Console.CursorVisible = false;
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