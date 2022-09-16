
namespace Tetriz
{
    class Program
    {
        private static Screen screen;

        private static void _readKeysThread()
        {
            Boolean loop = true;
            while (loop)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                switch (keyPressed)
                {
                    case ConsoleKey.Escape:
                        loop = false;
                        break;
                    default:
                        screen.HandleKey(keyPressed);
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine(Const.TextGameOver);
            System.Environment.Exit(0);
        }

        private static void _initKeyReading()
        {
            Thread keyReading = new Thread(_readKeysThread);
            keyReading.IsBackground = true;
            keyReading.Start();
        }


        static void Main()
        {
            _initKeyReading();
            screen = new Screen(
                Const.DefaultScreenWidth,
                Const.DefaultScreenHeight);
            screen.Run();
        }
    }
}
