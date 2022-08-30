namespace Tetriz
{
    abstract class IBlock
    {
        public abstract List<List<String>> Data();

        public void Print()
        {
            foreach (List<String> row in this.Data())
            {
                foreach (String item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Zzz");
        }
    }
}