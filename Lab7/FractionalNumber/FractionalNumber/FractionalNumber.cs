using System;
using System.Text.RegularExpressions;

namespace FractionalNumber
{
    class FractionalNumber : IComparable<FractionalNumber>, ICloneable, IFormattable, IConvertible
    {
        public FractionalNumber()
        {
            Numerator = 0;
            Denominator = 1;
        }
        public FractionalNumber(int Numerator)
        {
            this.Numerator = Numerator;
            Denominator = 1;
        }
        public FractionalNumber(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
        }
        public FractionalNumber(FractionalNumber Number)
        {
            Numerator = Number.Numerator;
            Denominator = Number.Denominator;
        }
        private int Numerator;
        public int GetNumerator()
        {
            return Numerator;
        }
        private static int GetGreatestCommonFactor(int First, int Second)
        {
            int Min = Math.Min(First, Second);
            int Max = Math.Max(First, Second);
            while (Min != 0)
            {
                First = Max - Min;
                Second = Min;
                Min = Math.Min(First, Second);
                Max = Math.Max(First, Second);
            }
            return Max;
        }
        public void SetNumerator(int Numerator)
        {
            int GreatestCommonFactor;
            this.Numerator = Numerator;
            if (Numerator != 0 && Denominator != 0)
            {
                GreatestCommonFactor = GetGreatestCommonFactor(Math.Abs(Numerator), Math.Abs(Denominator));
                Numerator /= GreatestCommonFactor;
                Denominator /= GreatestCommonFactor;
            }
        }
        private int Denominator;
        public int GetDenominator()
        {
            return Denominator;
        }
        public void SetDenominator(int Denominator)
        {
            if (Denominator == 0)
            {
                throw new Exception("Denominator is ziro");
            }
            int GreatestCommonFactor;
            this.Denominator = Denominator;
            if (Numerator != 0)
            {
                GreatestCommonFactor = GetGreatestCommonFactor(Math.Abs(Numerator), Math.Abs(Denominator));
                Numerator /= GreatestCommonFactor;
                Denominator /= GreatestCommonFactor;
            }
        }
        public void Reverse()
        {
            if (Numerator != 0 && Denominator != 0)
            {
                Numerator += Denominator;
                Denominator = Numerator - Denominator;
                Numerator -= Denominator;
            }
            else
            {
                throw new Exception("Error of reversing");
            }
        }
        public object Clone()
        {
            return new FractionalNumber(Numerator, Denominator);
        }
        public string ToString(string Format, IFormatProvider FormatProvider)
        {
            if (string.IsNullOrEmpty(Format))
            {
                Format = "D";
            }
            if (Format == "D")
            {
                return ((double)(Numerator) / (double)(Denominator)).ToString();
            }
            if (Format == "WPF")
            {
                if (Math.Abs(Numerator) > Denominator && Denominator != 1)
                {
                    return (Numerator / Denominator) + "(" + (Math.Abs(Numerator) % Denominator) + "/" + Denominator + ")";
                }
                else if(Numerator == 0)
                {
                    return "0";
                }
                else
                {
                    Format = "WP";
                }
            }
            if (Format == "WP")
            {
                if (Math.Abs(Numerator) > Denominator)
                {
                    return (Numerator / Denominator).ToString();
                }
                else if (Numerator == 0)
                {
                    return "0";
                }
                else
                {
                    Format = "F";
                }
            }
            if (Format == "F")
            {
                return Numerator + "/" + Denominator;
            }
            throw new Exception("Wrong format");
        }
        public string ToString(string Format)
        {
            return ToString(Format, null);
        }
        public override string ToString()
        {
            return ToString("D", null);
        }
        public static bool TryParse(string StringNumber, out FractionalNumber Number)
        {
            Regex DoubleNumber = new Regex(@"^(\d*)[.](\d*)$");
            Regex FractionalString = new Regex(@"^(\d*)[/](\d*)$");
            Regex IntegerNumber = new Regex(@"^\d*$");
            if (DoubleNumber.IsMatch(StringNumber))
            {
                string[] Line = StringNumber.Split(new char[] { '.' });
                Number = new FractionalNumber(int.Parse(Line[0]), int.Parse(Line[1]));
                return true;
            }
            else
            if (FractionalString.IsMatch(StringNumber))
            {
                string[] Line = StringNumber.Split(new char[] { '/' });
                Number = new FractionalNumber(int.Parse(Line[0]), int.Parse(Line[1]));
                return true;
            }
            else if (IntegerNumber.IsMatch(StringNumber))
            {
                Number = new FractionalNumber(int.Parse(StringNumber), 1);
                return true;
            }
            else
            {
                Number = null;
                return false;
            }
                
        }
        public static FractionalNumber Parse(string StringNumber)
        {
            FractionalNumber Number;
            if (TryParse(StringNumber, out Number))
            {
                return Number;
            }   
            throw new Exception("Wrong string");
        }
        private double GetDouble()
        {
            return (double)(Numerator) / (double)(Denominator);
        }
        public bool ToBoolean(IFormatProvider formatProvider)
        {
            return Numerator != 0;
        }
        public double ToDouble(IFormatProvider formatProvider)
        {
            return GetDouble();
        }
        public byte ToByte(IFormatProvider formatProvider)
        {
            return Convert.ToByte(GetDouble());
        }
        public char ToChar(IFormatProvider formatProvider)
        {
            return Convert.ToChar(GetDouble());
        }
        public DateTime ToDateTime(IFormatProvider formatProvider)
        {
            return Convert.ToDateTime(GetDouble());
        }
        public decimal ToDecimal(IFormatProvider formatProvider)
        {
            return Convert.ToDecimal(GetDouble());
        }
        public short ToInt16(IFormatProvider formatProvider)
        {
            return Convert.ToInt16(GetDouble());
        }
        public int ToInt32(IFormatProvider formatProvider)
        {
            return Convert.ToInt32(GetDouble());
        }
        public long ToInt64(IFormatProvider formatProvider)
        {
            return Convert.ToInt64(GetDouble());
        }
        public sbyte ToSByte(IFormatProvider formatProvider)
        {
            return Convert.ToSByte(GetDouble());
        }
        public float ToSingle(IFormatProvider formatProvider)
        {
            return Convert.ToSingle(GetDouble());
        }
        public string ToString(IFormatProvider formatProvider)
        {
            return ToString("D", formatProvider);
        }
        public object ToType(Type conversionType, IFormatProvider formatProvider)
        {
            return Convert.ChangeType(GetDouble(), conversionType);
        }
        public ushort ToUInt16(IFormatProvider formatProvider)
        {
            return Convert.ToUInt16(GetDouble());
        }
        public uint ToUInt32(IFormatProvider formatProvider)
        {
            return Convert.ToUInt32(GetDouble());
        }
        public ulong ToUInt64(IFormatProvider formatProvider)
        {
            return Convert.ToUInt64(GetDouble());
        }

        public static FractionalNumber operator - (FractionalNumber Number)
        {
            return new FractionalNumber(Number.Numerator * (-1), Number.Denominator);
        }
        public static FractionalNumber operator + (FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            int NewDenominator = FirstNumber.Denominator * SecondNumber.Denominator / GetGreatestCommonFactor(Math.Abs(FirstNumber.Denominator), Math.Abs(SecondNumber.Denominator));
            return new FractionalNumber(FirstNumber.Numerator * NewDenominator / FirstNumber.Denominator + SecondNumber.Numerator * NewDenominator / SecondNumber.Denominator, NewDenominator);
        }
        public static FractionalNumber operator - (FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber + (-SecondNumber);
        }
        public static FractionalNumber operator * (FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            int GreatestCommonFactor = GetGreatestCommonFactor(FirstNumber.Numerator * SecondNumber.Numerator, FirstNumber.Denominator * SecondNumber.Denominator);
            return new FractionalNumber(FirstNumber.Numerator * SecondNumber.Numerator / GreatestCommonFactor, FirstNumber.Denominator * SecondNumber.Denominator / GreatestCommonFactor);
        }
        public static FractionalNumber operator / (FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            SecondNumber.Reverse();
            return FirstNumber * SecondNumber;
        }

        public int CompareTo(FractionalNumber other)
        {
            if ((this - other).GetDouble() > 0)
            {
                return -1;
            }
            else if ((this - other).GetDouble() < 0)
            {
                return -1;
            }else
            {
                return 0;
            }
        }
        public override bool Equals(object obj)
        {
            return obj is FractionalNumber Number && CompareTo(Number) == 0;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
        
        public static bool operator <(FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber.CompareTo(SecondNumber) < 0;
        }
        public static bool operator >(FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber.CompareTo(SecondNumber) > 0;
        }
        public static bool operator <=(FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber.CompareTo(SecondNumber) <= 0;
        }
        public static bool operator >=(FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber.CompareTo(SecondNumber) >= 0;
        }
        public static bool operator ==(FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber.CompareTo(SecondNumber) == 0;
        }
        public static bool operator !=(FractionalNumber FirstNumber, FractionalNumber SecondNumber)
        {
            return FirstNumber.CompareTo(SecondNumber) != 0;
        }
    }
}
