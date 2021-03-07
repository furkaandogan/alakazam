using System;

namespace Alakazam.Framework
{
    public sealed class Currency
        : IComparable<Currency>, IComparable
    {
        public static Currency TL { get; private set; }

        public string Code { get; private set; }

        static Currency()
        {
            TL = new Currency("try");
        }

        public Currency(string code)
        {
            Code = code;
        }


        public bool Equals(Currency currency)
        {
            return !ReferenceEquals(null, currency) &&
                    Code == currency.Code;
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Currency && Equals((Currency)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Currency other)
        {
            if (other is null) 
                throw new ArgumentNullException(nameof(other));

            return Code.CompareTo(other.Code);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Currency)obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}