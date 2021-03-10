using System;

namespace Word_Reverser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи строку");
            string Line = Console.ReadLine();
            String[] Words = Line.Split(new char[] { ' ' });
            for(int i = 0; i < Words.Length/2; i++)
            {
                Line = Words[i];
                Words[i] = Words[Words.Length - i - 1];
                Words[Words.Length - i - 1] = Line;
            }
            Line = String.Join(" ", Words);
            Console.WriteLine(Line);
        }
    }
}
