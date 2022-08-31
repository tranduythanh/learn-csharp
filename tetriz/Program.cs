
namespace Tetriz
{
    class Program
    {
        private static void InitKeyReading()
        {
            Thread keyReading = new Thread(ReadKeysThread);
            keyReading.IsBackground = true;
            keyReading.Start();
        }

        private static void ReadKeysThread()
        {
            while (true)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                Console.WriteLine(keyPressed);
                // currentScreen.HandleKey(keyPressed);
            }
        }

        static void Main()
        {
            InitKeyReading();

            Screen screen = new Screen();
            screen.Run();
            System.Threading.Thread.Sleep(10000);
        }
    }
}
