using System;
class PassingByVal
{
    static void Swap(int a, int b)
    {
        int Temp = a;
        a = b;
        b = Temp;
        Console.WriteLine("Trong phuong thuc Swap: a = {0}, b = {1}", a, b);
    }

    static void Swap2(ref int a, ref int b)
    {
        int Temp = a;
        a = b;
        b = Temp;
        Console.WriteLine("Trong phuong thuc Swap: a = {0}, b = {1}", a, b);
    }

    static void Main(string[] args)
    {
        int x = 3, y = 4;
        Console.WriteLine("Truoc khi goi phuong thuc Swap: x = {0}, y = {1}", x, y);
        Swap(x, y);
        Console.WriteLine("Sau khi goi phuong thuc Swap: x= {0},y={1}", x, y);

        Console.WriteLine("Truoc khi goi phuong thuc Swap2: x = {0}, y = {1}", x, y);
        Swap2(ref x, ref y);
        Console.WriteLine("Sau khi goi phuong thuc Swap2: x= {0},y={1}", x, y);
        Console.ReadLine();
    }
}