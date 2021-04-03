using System;

namespace DataDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string Format1 = DateTime.Now.ToString("f");
            string Format2 = DateTime.Now.ToString("g");
            int[] Digits = new int[10];
            int Digit;
            for (int i = 0; i < Format2.Length; i++)
            {
                Digit = (int)Format2[i];
                if (Digit >= 48 && Digit <= 57)
                {
                    Digits[Digit - 48]++;
                }
            }
            Console.WriteLine("Дата в первом формате: " + Format1);
            Console.WriteLine("\nДата во втором формате: " + Format2);
            Console.Write("\n| ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " | ");
            }
            Console.Write("\n| ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(Digits[i] + " | ");
            }
            Console.ReadKey(true);
        }
    }
}
