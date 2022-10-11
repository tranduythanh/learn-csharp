namespace ex05
{
    class Program
    {
        static void Main()
        {
            Triangle t = new Triangle(3, 4, 5);
            Console.WriteLine(t.Perimeter);
            Console.WriteLine(t.Area());
            Console.WriteLine(t.Type());

            Cylinder c = new Cylinder(2, 1);
            Console.WriteLine(c.BottomArea);
            Console.WriteLine(c.SurroundArea);
            Console.WriteLine(c.Volume);
        }
    }
}