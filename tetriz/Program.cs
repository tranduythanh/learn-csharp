
namespace Tetriz
{
    class Program
    {
        private static Screen screen;

        private static void InitKeyReading()
        {
            Thread keyReading = new Thread(ReadKeysThread);
            keyReading.IsBackground = true;
            keyReading.Start();
        }

        private static void ReadKeysThread()
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

        static void Main()
        {
            InitKeyReading();
            screen = new Screen(
                Const.DefaultScreenWidth,
                Const.DefaultScreenHeight);
            screen.Run();
        }
    }
}
