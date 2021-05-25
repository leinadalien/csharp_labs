using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    class Transport
    {
        public int SerialNumber;
        private static int ForSerialNumber = 0;
        public enum KindsOfTransport
        {
            Water, Air, Terrestrial, Underground, Space, OwnAssembly, NotDetermined
        }
        bool Broken = false;
        Random Rand = new Random();
        double FuelConsumption = 5;
        double MaxSpeed;
        double Fuel = 0;
        double Mileage = 0;
        double MaxFuel = 80;
        int SeatsCount;
        double Weight;
        string Country;
        int Year = 2000;
        KindsOfTransport Kind;
        public Transport()
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.MaxFuel = 190;
            this.FuelConsumption = 160;
            this.Fuel = 190;
            this.Weight = 32;
            this.MaxSpeed = 55;
            this.SeatsCount = 5;
            this.Country = "USSR";
            this.Year = 1944;
            this.Kind = KindsOfTransport.OwnAssembly;
        }
        public Transport(double Weight, double MaxSpeed, int SeatsCount)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = "USSR";
            this.Kind = KindsOfTransport.OwnAssembly;
        }
        public Transport(double Weight, double MaxSpeed, int SeatsCount, string Country)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = Country;
            this.Kind = KindsOfTransport.NotDetermined;
        }
        public Transport(double Weight, double MaxSpeed, int SeatsCount, string Country, int Year)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = Country;
            this.Year = Year;
            this.Kind = KindsOfTransport.NotDetermined;
        }
        public Transport(double Weight, double MaxSpeed, int SeatsCount, string Country, int Year, KindsOfTransport Kind)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = Country;
            this.Year = Year;
            this.Kind = Kind;
        }
        public Transport(double Weight, double MaxSpeed, int SeatsCount, string Country, int Year, KindsOfTransport Kind, double MaxFuel)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = Country;
            this.Year = Year;
            this.Kind = Kind;
            this.MaxFuel = MaxFuel;
        }
        public void Refuel()
        {
            if (Fuel < MaxFuel)
            {
                Fuel = MaxFuel;
                Console.WriteLine("Successfully refueled");
            }
            else
            {
                Console.WriteLine("The tank is already filled");
            }
        }
        
        public void Repair()
        {
            Broken = true;
        }
        private double PreFuel;
        public void Use()
        {
            if (!Broken)
            {
                if (Fuel > 0)
                {
                    if (Rand.Next(5) == 1)
                    {
                        Broken = true;
                    }
                    PreFuel = Fuel;
                    Fuel = Rand.NextDouble() * Fuel;
                    Mileage += (PreFuel - Fuel) / FuelConsumption * 100;
                    Console.WriteLine("you covered a distance of " + ((PreFuel - Fuel) / FuelConsumption * 100) + " km.");
                    if (Broken) {
                        Console.WriteLine("Transport broke.");
                            }
                } else
                {
                    Console.WriteLine("No fuel");
                }
            }
            else
            {
                Console.WriteLine("Transport is broken");
            }
        }
        public void Use(double fuel)
        {
            if (!Broken)
            {
                if (fuel <= Fuel)
                {
                    if (Rand.Next(5) == 1)
                    {
                        Broken = true;
                    }
                    PreFuel = Fuel;
                    Fuel -= fuel;
                    Mileage += fuel / FuelConsumption * 100;
                    Console.WriteLine("you covered a distance of " + (fuel / FuelConsumption * 100) + " km.");
                    if (Broken)
                    {
                        Console.WriteLine("Transport broke.");
                    }
                }
                else
                {
                    Console.WriteLine("Not enough fuel");
                }
            }
            else
            {
                Console.WriteLine("Transport is broken");
            }
        }
        public void PrintInfo()
        {
            Console.WriteLine("Serial Number: " + SerialNumber);
            Console.Write("Kind of transport: ");
            switch(Kind)
            {
                case KindsOfTransport.NotDetermined:
                    Console.WriteLine("Not Determined");
                    break;
                case KindsOfTransport.OwnAssembly:
                    Console.WriteLine("Own Assembly");
                    break;
                case KindsOfTransport.Water:
                    Console.WriteLine("Water");
                    break;
                case KindsOfTransport.Space:
                    Console.WriteLine("Space");
                    break;
                case KindsOfTransport.Terrestrial:
                    Console.WriteLine("Terrestrial");
                    break;
                case KindsOfTransport.Underground:
                    Console.WriteLine("Underground");
                    break;
                default:
                    Console.WriteLine("Error of Loading");
                    break;
            }
            Console.WriteLine("Made in " + Country);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Weight: " + Weight + " t");
            Console.WriteLine("Mileage: " + Mileage + " km");
            Console.WriteLine("Maximal speed: " + MaxSpeed + " km/h");
            Console.WriteLine("Maximal fuel: " + MaxFuel + " l");
            Console.WriteLine("Fuel Consumption: " + FuelConsumption + " liters per 100 km");
            Console.WriteLine("Fuel: " + Fuel + " liters");
            Console.WriteLine("Count of seats: " + SeatsCount);
            if (Broken)
            {
                Console.WriteLine("Transport is broken");
            }
            else
            {
                Console.WriteLine("Transport in working order");
            }
        }
    }
}
