using System;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Audi a = new Audi();
            a.SetRegistrationNumber("5726 XW-5");
            a.AudiNotify += DisplayMessage;
            a.SetRegistrationNumber("4235 KM-4");
            a.Use();
            a.Refuel();
            a.Notify += DisplayMessage;
            a.Use();
            a.Beep();
            Car.MakePolice(a);
            a.Beep();
        }
        private static void DisplayMessage(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}
