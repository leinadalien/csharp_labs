using System;

namespace Transport
{
    class Volkswagen : Car, IDesignable
    {
        public event TransportIformer VolkswagenNotify;
        public enum VolkswagenModel
        {
            Polo, Jetta, Passat, Golf, Taos, Tiguan, Teramont, Touareg, Caravelle, Caddy_Cargo, Transporter_Kasten, Crafter_Kasten, Caddy, Multivan, Caddy_California, California,
            Caddy_Kombi, Transporter_Kombi, Transporter_Pritsche, Crafter_Pritsche, Crafter_Touring_Bus
        }
        VolkswagenModel Model = VolkswagenModel.Passat;
        private static string ToString(VolkswagenModel Model)
        {
            return Model.ToString().Replace('_', ' ');
        }
        private string ModelInfo = "";
        public Volkswagen() : base("Germany")
        {
            if (RegistrationNumber != "")
            {
                TransportInfo = "Volkswagen " + ToString(Model) + "[" + RegistrationNumber + "]";
            } else
            {
                TransportInfo = "Volkswagen " + ToString(Model) + " without registration number";
            }
        }
        public Volkswagen(ConsoleColor Color) : base("Germany", Color)
        {
            if (RegistrationNumber != "")
            {
                TransportInfo = "Volkswagen " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Volkswagen " + ToString(Model) + " without registration number";
            }
        }
        public Volkswagen(VolkswagenModel Model, ConsoleColor Color) : base("Germany", Color)
        {
            this.Model = Model;
            if (RegistrationNumber != "")
            {
                TransportInfo = "Volkswagen " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Volkswagen " + ToString(Model) + " without registration number";
            }
        }
        public Volkswagen(VolkswagenModel Model) : base("Germany")
        {
            
            this.Model = Model;
            if (RegistrationNumber != "")
            {
                TransportInfo = "Volkswagen " + ToString(Model) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Volkswagen " + ToString(Model) + " without registration number";
            }
        }
        protected override void PrintTransportInfo()
        {
            base.PrintTransportInfo();
            Console.WriteLine("Car Brand: Volkswagen");
            Console.WriteLine("Model: " + ToString(Model) + " " + ModelInfo);
        }
        public void AddModelInfo(string ModelInfo)
        {
            this.ModelInfo = ModelInfo;
            if (RegistrationNumber != "")
            {
                TransportInfo = "Volkswagen " + GetModel(true) + "[" + RegistrationNumber + "]";
            }
            else
            {
                TransportInfo = "Volkswagen " + GetModel(true) + " without registration number";
            }
        }
        //Getters
        public VolkswagenModel GetModel()
        {
            return Model;
        }
        public override void SetRegistrationNumber(string RegistrationNumber)
        {
            this.RegistrationNumber = RegistrationNumber;
            VolkswagenNotify?.Invoke(TransportInfo + " get the registration number [" + RegistrationNumber + "]");
            TransportInfo = "Volkswagen " + ToString(Model) + " " + ModelInfo + "[" + RegistrationNumber + "]";
        }
        public override void TakeOffRegistrationNumber()
        {
            RegistrationNumber = "";
            TransportInfo = "Volkswagen " + ToString(Model) + " " + ModelInfo + " without registration number";
        }
        public string GetModel(bool AdditionalInfo)
        {
            if (AdditionalInfo)
            {
                if (ModelInfo != "")
                {
                    return ToString(Model) + " " + ModelInfo;
                }
                else
                {
                    return ToString(Model) + " No Info";
                }
            }
            else
            {
                return Model.ToString();
            }
        }
        public void Facing()
        {
            CountOfDesignActions++;
            switch (CountOfDesignActions)
            {
                case 1:
                    DesignInfo += "\n1. Print '" + ToString(Model) + "' on the left side";
                    VolkswagenNotify?.Invoke("'" + ToString(Model) + "' has been printed on the left side of " + TransportInfo);
                    break;
                case 2:
                    DesignInfo += "\n2. Print '" + ToString(Model) + "' on the right side";
                    VolkswagenNotify?.Invoke("'" + ToString(Model) + "' has been printed on the right side of " + TransportInfo);
                    break;
                case 3:
                    DesignInfo += "\n3. Print 'Volkswagen' on the wheels";
                    VolkswagenNotify?.Invoke("'Volkswagen' has been printed on the wheels of " + TransportInfo);
                    break;
                default:
                    VolkswagenNotify?.Invoke("There is no more print for " + TransportInfo);
                    CountOfDesignActions--;
                    break;
            }
        }
    }
}
