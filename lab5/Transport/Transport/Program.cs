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
            a.Use();
            Volkswagen b = new Volkswagen();
            b.Refuel(10);
            b.AddModelInfo("b5");
            b.SetRegistrationNumber("8234 IX-1");
            b.PrintInfo();
            b.Use();
            Mercedes c = new Mercedes();
            c.Refuel();
            c.PrintInfo();
        }
    }
}
