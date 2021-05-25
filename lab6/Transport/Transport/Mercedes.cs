using System;

namespace Transport
{
    class Mercedes : Car, IDesignable
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
            Console.WriteLine(TransportInfo + " get the registration number [" + RegistrationNumber + "]");
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
        public void Facing()
        {
            CountOfDesignActions++;
            switch (CountOfDesignActions)
            {
                case 1:
                    DesignInfo += "\n1. Print '" + ToString(Model) + "' on the left side";
                    Console.WriteLine("'" + ToString(Model) + "' has been printed on the left side of " + TransportInfo);
                    break;
                case 2:
                    DesignInfo += "\n2. Print '" + ToString(Model) + "' on the right side";
                    Console.WriteLine("'" + ToString(Model) + "' has been printed on the right side of " + TransportInfo);
                    break;
                case 3:
                    DesignInfo += "\n3. Print 'Mercedes' on the wheels";
                    Console.WriteLine("'Mercedes' has been printed on the wheels of " + TransportInfo);
                    break;
                default:
                    Console.WriteLine("There is no more print for " + TransportInfo);
                    CountOfDesignActions--;
                    break;
            }
        } 
    }
}