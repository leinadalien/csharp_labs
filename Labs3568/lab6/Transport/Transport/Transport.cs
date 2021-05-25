using System;

namespace Transport
{
    class Transport: IComparable
    {
        protected int SerialNumber;
        private static int ForSerialNumber = 0;
        public enum KindsOfTransport
        {
            Water, Air, Terrestrial, Underground, Space, OwnAssembly, NotDetermined
        }
        protected bool Broken = false;
        private Random Rand = new Random();
        protected double FuelConsumption = 5;
        protected double MaxSpeed;
        protected double Fuel = 0;
        private double Mileage = 0;
        protected double MaxFuel = 80;
        protected int SeatsCount;
        protected double Weight;
        protected string Country;
        protected int Year = 2000;
        private KindsOfTransport Kind;
        private ConsoleColor Color = ConsoleColor.Black;
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
        public Transport(KindsOfTransport Kind)
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
            this.Kind = Kind;
        }
        public Transport(KindsOfTransport Kind, ConsoleColor Color)
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
            this.Kind = Kind;
            this.Color = Color;
        }
        public Transport(KindsOfTransport Kind, string Country)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.MaxFuel = 190;
            this.FuelConsumption = 160;
            this.Fuel = 190;
            this.Weight = 32;
            this.MaxSpeed = 55;
            this.SeatsCount = 5;
            this.Country = Country;
            this.Year = 1944;
            this.Kind = Kind;
        }
        public Transport(KindsOfTransport Kind, string Country, ConsoleColor Color)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.MaxFuel = 190;
            this.FuelConsumption = 160;
            this.Fuel = 190;
            this.Weight = 32;
            this.MaxSpeed = 55;
            this.SeatsCount = 5;
            this.Country = Country;
            this.Year = 1944;
            this.Kind = Kind;
            this.Color = Color;
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
        public Transport(double Weight, double MaxSpeed, int SeatsCount, KindsOfTransport Kind)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = "USSR";
            this.Kind = Kind;
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
        public Transport(double Weight, double MaxSpeed, int SeatsCount, string Country , ConsoleColor Color)
        {
            ForSerialNumber++;
            this.SerialNumber = ForSerialNumber;
            this.SeatsCount = SeatsCount;
            this.Weight = Weight;
            this.MaxSpeed = MaxSpeed;
            this.Country = Country;
            this.Kind = KindsOfTransport.NotDetermined;
            this.Color = Color;
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
                Console.WriteLine(TransportInfo + "(" + SerialNumber + ") Successfully refueled");
            }
            else
            {
                Console.WriteLine(TransportInfo + "(" + SerialNumber + ") is already filled");
            }
        }
        public void Refuel(double Fuel)
        {
            if (Fuel > 0)
            {
                if (this.Fuel < MaxFuel)
                {
                    if (this.Fuel + Fuel < MaxFuel)
                    {
                        this.Fuel += Fuel;
                    }
                    else
                    {
                        this.Fuel = MaxFuel;
                    }
                    Console.WriteLine(TransportInfo + "(" + SerialNumber + ") successfully refueled");
                }
                else
                {
                    Console.WriteLine(TransportInfo + "(" + SerialNumber + ") is already filled");
                }
            }
        }

        public void Repair()
        {
            Broken = true;
        }
        private double PreFuel;
        protected string TransportInfo = "Transport";
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
                    Console.WriteLine(TransportInfo + "(" + SerialNumber + ") covered a distance of " + ((PreFuel - Fuel) / FuelConsumption * 100) + " km.");
                    if (Broken)
                    {
                        Console.WriteLine(TransportInfo + "(" + SerialNumber + ") just broke.");
                    }
                } else
                {
                    Console.WriteLine(TransportInfo + "(" + SerialNumber + ") does not have fuel");
                }
            }
            else
            {
                Console.WriteLine(TransportInfo + "(" + SerialNumber + ") is broken");
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
                    Console.WriteLine(TransportInfo + "(" + SerialNumber + ") covered a distance of " + (fuel / FuelConsumption * 100) + " km.");
                    if (Broken)
                    {
                        Console.WriteLine(TransportInfo + "(" + SerialNumber + ") just broke.");
                    }
                }
                else
                {
                    Console.WriteLine(TransportInfo + "(" + SerialNumber + ") does not have enough fuel");
                }
            }
            else
            {
                Console.WriteLine(TransportInfo + "(" + SerialNumber + ") is broken");
            }
        }
        protected virtual void PrintAppearance()
        {
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Count of seats: " + SeatsCount);
        }
        protected virtual void PrintTransportInfo()
        {
            Console.Write("Kind of transport: ");
            switch (Kind)
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
            Console.WriteLine("Serial Number: " + SerialNumber);
            if (Country != "")
            {
                Console.WriteLine("Made in " + Country);
            }
            else
            {
                Console.WriteLine("Country undefined");
            }
            Console.WriteLine("Year: " + Year);
        }
        protected virtual void PrintHiddenInfo()
        {
            Console.WriteLine("Weight: " + Weight + " t");
            Console.WriteLine("Mileage: " + Mileage + " km");
            Console.WriteLine("Maximal speed: " + MaxSpeed + " km/h");
            Console.WriteLine("Maximal fuel: " + MaxFuel + " liters");
            Console.WriteLine("Fuel Consumption: " + FuelConsumption + " liters per 100 km");
            Console.WriteLine("Fuel: " + Fuel + " liters");
        }
        public void PrintInfo()
        {
            PrintTransportInfo();
            PrintAppearance();
            PrintHiddenInfo();
            if (Broken)
            {
                Console.WriteLine("Transport is broken");
            }
            else
            {
                Console.WriteLine("Transport in working order");
            }
        }
        //Getters
        public KindsOfTransport GetKindOfTransport()
        {
            return Kind;
        }
        public int GetSerialNumber()
        {
            return SerialNumber;
        }
        public int GetYear()
        {
            return Year;
        }
        public bool IsBroken()
        {
            return Broken;
        }
        public double GetFuel()
        {
            return Fuel;
        }
        public double GetMileage()
        {
            return Mileage;
        }
        public string GetCountry()
        {
            return Country;
        }
        public ConsoleColor GetColor()
        {
            return Color;
        }
        //Setters
        public void SetColor(ConsoleColor Color)
        {
            this.Color = Color;
        }

        public int CompareTo(object obj)
        {
            Transport transport = obj as Transport;
            if (transport != null)
            {
                return this.Country.CompareTo(transport.Country);
            }
            else throw new Exception("Error of comparing");
        }
    }
}
