namespace ex06
{
    class Program
    {
        static void Main()
        {
            // complex ============================
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(-3, 4);
            Console.WriteLine((string)(c1 + c2));
            Console.WriteLine((string)(c1 - c2));
            Console.WriteLine((string)(c1 * c2));
            Console.WriteLine((string)(c1 / c2));

            // matrix  ============================
            Matrix a = new Matrix(
                4,
                new List<List<double>> {
                    new List<double> { 5, 7 , 9, 10},
                    new List<double> { 2, 3,  3, 8},
                    new List<double> { 8, 10, 2, 3},
                    new List<double> { 3, 3,  4, 8},
                }
            );

            Matrix b = new Matrix(
                4,
                new List<List<double>> {
                    new List<double> {  1, 2, 3, 3},
                    new List<double> {  3, 4, 3, 1},
                    new List<double> {  1, 1, 7, 1},
                    new List<double> {  2, 1, 1, 2},
                }
            );

            Matrix c = new Matrix(
                2,
                new List<List<double>> {
                    new List<double> {  1, 2},
                    new List<double> {  3, 4},
                }
            );

            a.Debug();
            Console.WriteLine();
            b.Debug();
            Console.WriteLine();
            b.RemoveRowCol(0, 0).Debug();
            Console.WriteLine();
            Console.WriteLine((double)b);
            Console.WriteLine();
            a.Clone().Debug();
            Console.WriteLine();
            (a + b).Debug();
            Console.WriteLine();
            (a - b).Debug();
            Console.WriteLine();
            (a * b).Debug();
            Console.WriteLine();


            // student ============================
            Student s = new Student("Thanh", 8, 9);
            Console.WriteLine(s[0]);
            Console.WriteLine(s[1]);
            Console.WriteLine(s[2]);
            Console.WriteLine(s[3]);

            Console.WriteLine(s["name"]);
            Console.WriteLine(s["math"]);
            Console.WriteLine(s["info"]);
            Console.WriteLine(s["avg"]);

            s[0] = "Thanh Thanh";
            s[1] = 10;
            s[2] = 9;

            Console.WriteLine(s[0]);
            Console.WriteLine(s[1]);
            Console.WriteLine(s[2]);
            Console.WriteLine(s[3]);

            s["name"] = "Thanh Thanh 3";
            s["math"] = 7;
            s["info"] = 6;

            Console.WriteLine(s["name"]);
            Console.WriteLine(s["math"]);
            Console.WriteLine(s["info"]);
            Console.WriteLine(s["avg"]);
        }
    }

}
