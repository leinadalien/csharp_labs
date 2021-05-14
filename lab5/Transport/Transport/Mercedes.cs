using System;

namespace Transport
{
    class Mercedes : Car
    {
        public enum MercedesModel
        {
            A_Class, B_Class, C_Class, E_Class, S_Class, V_Class, GLE, SLS, SLK, GLK, SL, GL, Vito, 
        }
        private MercedesModel Model = MercedesModel.A_Class;
        private static string ToString(MercedesModel Model)
        {
            return Model.ToString().Replace('_', ' ');
        }

        protected override void PrintTransportInfo()
        {
            base.PrintTransportInfo();
            Console.WriteLine("Car Brand: Mercedes");
            Console.WriteLine("Model: " + ToString(Model));
        }
        public Mercedes() : base("Germany")
        {
            if (RegistrationNumber != "")
            {
                TransportInfo = "Mercedes " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Mercedes " + ToString(Model) + " without registration number";
            }
        }
        public Mercedes(ConsoleColor Color) : base("Germany", Color)
        {
            if (RegistrationNumber != "")
            {
                TransportInfo = "Mercedes " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Mercedes " + ToString(Model) + " without registration number";
            }
        }
        public Mercedes(MercedesModel Model, ConsoleColor Color) : base("Germany", Color)
        {
            this.Model = Model;
            if (RegistrationNumber != "")
            {
                TransportInfo = "Mercedes " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Mercedes " + ToString(Model) + " without registration number";
            }
        }
        public Mercedes(MercedesModel Model) : base("Germany")
        {

            this.Model = Model;
            if (RegistrationNumber != "")
            {
                TransportInfo = "Mercedes " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Mercedes " + ToString(Model) + " without registration number";
            }
        }
        public override void SetRegistrationNumber(string RegistrationNumber)
        {
            this.RegistrationNumber = RegistrationNumber;
            TransportInfo = "Mercedes " + ToString(Model) + "[" + RegistrationNumber + "]";
        }
        public override void TakeOffRegistrationNumber()
        {
            RegistrationNumber = "";
            TransportInfo = "Mercedes " + ToString(Model) + " without registration number";
        }
        //Getters
        public MercedesModel GetModel()
        {
            return Model;
        }
    }
}