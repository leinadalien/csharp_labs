using System;
namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            Audi a = new Audi();
            
            a.Refuel(5);
            a.SetRegistrationNumber("7856 IM-1");
            a.PrintInfo();
            Console.WriteLine();
            Transport b = new Mercedes();
            b.PrintInfo();
        }
    }
}
