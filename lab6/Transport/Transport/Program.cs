using System;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            Audi a = new Audi();
            Mercedes b = new Mercedes(Mercedes.MercedesModel.SLS, ConsoleColor.Cyan);
            Volkswagen c = new Volkswagen(ConsoleColor.DarkGray);
            b.Facing();
            b.Facing();
            c.Facing();
            a.Facing();
            Car d = new Car(1834, "Belarus");
            Car e = new Car("Iran");
            Car[] cars = new Car[] { a, b, c, d, e };
            Array.Sort(cars);
            foreach(Car car in cars)
            {
                Console.WriteLine(car.GetCountry());
            }
        }
    }
}
