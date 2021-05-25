using System;

namespace Transport
{
    class Audi : Car, IDesignable
    {
        public event TransportIformer AudiNotify;
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
                AudiNotify.Invoke(TransportInfo + " get the registration number [" + RegistrationNumber + "]");
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
            AudiNotify?.Invoke(TransportInfo + " get the registration number [" + RegistrationNumber + "]");
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
        public void Facing()
        {
            CountOfDesignActions++;
            switch (CountOfDesignActions)
            {
                case 1:
                    DesignInfo += "\n1. Print '" + ToString(Model) + "' on the left side";
                    AudiNotify?.Invoke("'" + ToString(Model) + "' has been printed on the left side of " + TransportInfo);
                    break;
                case 2:
                    DesignInfo += "\n2. Print '" + ToString(Model) + "' on the right side";
                    AudiNotify?.Invoke("'" + ToString(Model) + "' has been printed on the right side of " + TransportInfo);
                    break;
                case 3:
                    DesignInfo += "\n3. Print 'Audi' on the wheels";
                    AudiNotify?.Invoke("'Audi' has been printed on the wheels of " + TransportInfo);
                    break;
                case 4:
                    if (GetBodyType() == BodyType.Sedan) {
                        DesignInfo += "\n4. Print 'Audi sport' on the back window";
                        AudiNotify?.Invoke("'Audi sport' has been printed on the back window of " + TransportInfo);
                    } else
                    {
                        DesignInfo += "\n4. Print 'Audi' on the back window";
                        AudiNotify?.Invoke("'Audi' has been printed on the back window of " + TransportInfo);
                    }
                    break;
                default:
                    AudiNotify?.Invoke("There is no more print for " + TransportInfo);
                    CountOfDesignActions--;
                    break;
            }
        }
    }
}
