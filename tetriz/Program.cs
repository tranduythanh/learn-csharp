namespace Tetriz
{
    class Program
    {
        static void Main()
        {
            IBlock block;
            block = new BlockT();
            block.Print();
            Console.WriteLine();

            block = new BlockR();
            block.Print();
            Console.WriteLine();

            block = new BlockJ();
            block.Print();
            Console.WriteLine();

            block = new BlockL();
            block.Print();
            Console.WriteLine();

            block = new BlockO();
            block.Print();
            Console.WriteLine();

            block = new BlockZ();
            block.Print();
            Console.WriteLine();

            block = new BlockI();
            block.Print();
            Console.WriteLine();
        }
    }
}
