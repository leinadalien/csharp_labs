using System;
using System.Collections;

namespace Transport
{
    class Car : Transport
    {
        public enum BodyType
        {
            Sedan, Hatchback, StationWagon, SUV, Cabriolet, Pickup, Minivan, Limousine, Targa
        }
        private int WheelsCount;
        private int DoorCount = 4;
        protected int CountOfDesignActions = 0;
        protected string DesignInfo = "Hierarchy of design actions:";
        private BodyType BType;
        protected string RegistrationNumber = "";
        public enum EngineType
        {
            Petrol, Diesel, Gas, GasDiesel, RotaryPiston
        }
        public enum TransmissionType
        {
            mechanical, automatic
        }
        TransmissionType TType = TransmissionType.mechanical;
        private EngineType EType;

        public Car() : base(KindsOfTransport.Terrestrial)
        {
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            TransportInfo = "Car";
        }
        public Car(int DoorCount) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            this.DoorCount = DoorCount;
            
        }
        public string GetDesignInfo()
        {
            if (DesignInfo != "Hierarchy of design actions:")
            {
                return DesignInfo;
            }
            else
            {
                return "There is not design actions yet";
            }
        }
        public Car(string Country) : base(KindsOfTransport.Terrestrial, Country)
        {
            TransportInfo = "Car";
            Year = 2003;
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            DoorCount = 4;
        }
        public Car(BodyType BType) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            WheelsCount = 4;
            this.BType = BType;
            EType = EngineType.Petrol;
        }
        public Car(EngineType EType) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            this.EType = EType;
        }
        public Car(double Weight) : base(Weight, 240, 4, KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            this.Weight = Weight;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
        }
        public Car(EngineType EType, BodyType BType) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            this.BType = BType;
            this.EType = EType;
        }
        public Car(EngineType EType, BodyType BType, double Weight) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            this.Weight = Weight;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            this.BType = BType;
            this.EType = EType;

        }
        public Car(EngineType EType, BodyType BType, TransmissionType TType) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            this.BType = BType;
            this.EType = EType;
            this.TType = TType;
        }
        public Car(EngineType EType, BodyType BType,double Weight, TransmissionType TType) : base(KindsOfTransport.Terrestrial)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            this.Weight = Weight;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            this.BType = BType;
            this.EType = EType;
            this.TType = TType;
        }
        public Car(EngineType EType, BodyType BType, double Weight, TransmissionType TType, ConsoleColor Color) : base(KindsOfTransport.Terrestrial, Color)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            this.Weight = Weight;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            this.BType = BType;
            this.EType = EType;
            this.TType = TType;
        }
        public Car(ConsoleColor Color) : base(KindsOfTransport.Terrestrial , Color)
        {
            TransportInfo = "Car";
            Year = 2003;
            Country = "";
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            DoorCount = 4;
        }
        public Car(string Country, ConsoleColor Color) : base(KindsOfTransport.Terrestrial, Country, Color)
        {
            TransportInfo = "Car";
            Year = 2003;
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            DoorCount = 4;
        }
        public Car(int Year, string Country) : base(KindsOfTransport.Terrestrial, Country)
        {
            TransportInfo = "Car";
            this.Year = Year;
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            DoorCount = 4;
        }
        public Car(int Year, string Country, ConsoleColor Color) : base(KindsOfTransport.Terrestrial, Country, Color)
        {
            TransportInfo = "Car";
            this.Year = Year;
            Fuel = 0;
            MaxFuel = 80;
            Weight = 1.5;
            FuelConsumption = 12;
            MaxSpeed = 240;
            SeatsCount = 4;
            WheelsCount = 4;
            BType = BodyType.Sedan;
            EType = EngineType.Petrol;
            DoorCount = 4;
        }
        //Getters
        public BodyType GetBodyType()
        {
            return BType;
        }
        public EngineType GetEngineType()
        {
            return EType;
        }
        public string GetRegistrationNumber()
        {
            return RegistrationNumber;
        }
        //Setters
        public virtual void SetRegistrationNumber(string RegistrationNumber)
        {
            this.RegistrationNumber = RegistrationNumber;
            TransportInfo = "Car [" + RegistrationNumber + "]";
        }
        public virtual void TakeOffRegistrationNumber()
        {
            RegistrationNumber = "";
            TransportInfo = "Car without registraton number";
        }
        protected override void PrintTransportInfo()
        {
            base.PrintTransportInfo();
            if(RegistrationNumber != "")
            {
                Console.WriteLine("Registration Number: " + RegistrationNumber);
            } else
            {
                Console.WriteLine("Without registration number");
            }
        }
        protected override void PrintAppearance()
        {
            base.PrintAppearance();
            Console.WriteLine("Body type: " + BType);
            Console.WriteLine(GetDesignInfo());
        }
        protected override void PrintHiddenInfo()
        {
            base.PrintHiddenInfo();
            Console.WriteLine("Engine type: " + EType);
            Console.WriteLine("Transmission type: " + TType);
        }
    }
}
