using System;

namespace FractionalNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            FractionalNumber a = new FractionalNumber();
            FractionalNumber b = new FractionalNumber(2);
            FractionalNumber c = new FractionalNumber(3, 4);
            FractionalNumber d = new FractionalNumber(c);
            d.Reverse();
            Console.WriteLine(a);
            Console.WriteLine(b.ToString("D"));
            Console.WriteLine(c.ToString("WP"));
            Console.WriteLine(d.ToString("WPF"));
            Console.WriteLine();
            a = c + d;
            Console.WriteLine(a.ToString("WP"));

            FractionalNumber e;
            FractionalNumber.TryParse("5/45", out e);
            Console.WriteLine(e.ToString("WPF"));
        }
    }
}
