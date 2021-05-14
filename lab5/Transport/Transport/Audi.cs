using System;

namespace Transport
{
    class Audi : Car
    {
        public enum AudiModel
        {
            Audi_60, Audi_100, Audi_80, Audi_50, Audi_100_Coupe_S, Audi_200, Audi_90, Audi_Coupe_GT, Audi_Sport_Quattro, Audi_V8, Audi_Coup, Audi_100_Duo,
            Audi_Cabriolet, Audi_A8, Audi_A4, Audi_A3, Audi_A6, Audi_A4_Duo, Audi_TT_Coupe, Audi_TT_Roadster, Audi_A2, Audi_A4_Cabriolet, Audi_A3_Sportback,
            Audi_Q7, Audi_A6_Allroad_Quattro, Audi_TT, Audi_A5, Audi_Q5, Audi_R8, Audi_R8_V10, Audi_A1, Audi_A7, Audi_Q2
        }
        private AudiModel Model = AudiModel.Audi_A6;
        private static string ToString(AudiModel Model)
        {
            return Model.ToString().Replace('_', ' ');
        }
        
        protected override void PrintTransportInfo()
        {
            base.PrintTransportInfo();
            Console.WriteLine("Car Brand: Audi");
            Console.WriteLine("Model: " + ToString(Model));
        }
        public Audi() : base("Germany")
        {
            if (RegistrationNumber != "")
            {
                TransportInfo = ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = ToString(Model) + " without registration number";
            }
        }
        public Audi(ConsoleColor Color) : base("Germany", Color)
        {
            if (RegistrationNumber != "")
            {
                TransportInfo = ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = ToString(Model) + " without registration number";
            }
        }
        public Audi(AudiModel Model, ConsoleColor Color) : base("Germany", Color)
        {
            this.Model = Model;
            if (RegistrationNumber != "")
            {
                TransportInfo = ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = ToString(Model) + " without registration number";
            }
        }
        public Audi(AudiModel Model) : base("Germany")
        {

            this.Model = Model;
            if (RegistrationNumber != "")
            {
                TransportInfo = ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = ToString(Model) + " without registration number";
            }
        }
        public override void SetRegistrationNumber(string RegistrationNumber)
        {
            this.RegistrationNumber = RegistrationNumber;
            TransportInfo = ToString(Model) + "[" + RegistrationNumber + "]";
        }
        public override void TakeOffRegistrationNumber()
        {
            RegistrationNumber = "";
            TransportInfo = ToString(Model) + " without registration number";
        }
        //Getters
        public AudiModel GetModel()
        {
            return Model;
        }
    }
}
