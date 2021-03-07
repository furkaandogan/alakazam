using System;

namespace Alakazam.Framework
{
    [Serializable]
    public struct Money
        : IComparable<Money>, IComparable
    {

        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }
        public sbyte Round { get; private set; }
        // public MidpointRounding Rounding { get; private set; }

        public Money(decimal amount)
            : this(amount, Currency.TL, 2)
        {
            Amount = amount;
        }
        public Money(decimal amount, Currency currency, sbyte round/*, MidpointRounding midpointRounding*/)
        {
            Amount = decimal.Round(amount, round/*, midpointRounding*/);
            Round = round;
            Currency = currency;
            // Rounding = midpointRounding;
        }

        public static implicit operator Money(decimal amount)
        {
            return new Money(amount);
        }

        public static Money operator +(Money m, Money m2)
        {
            return new Money(m.Amount + m2.Amount, m.Currency, m.Round);
        }
        public static Money operator /(Money m, decimal d)
        {
            return new Money(m.Amount / d, m.Currency, m.Round);
        }
        public static Money operator *(Money m, decimal d)
        {
            return new Money(m.Amount * d, m.Currency, m.Round);
        }
        public static Money operator /(Money m, ushort d)
        {
            return new Money(m.Amount / d, m.Currency, m.Round);
        }
        public static Money operator *(Money m, ushort d)
        {
            return new Money(m.Amount * d, m.Currency, m.Round);
        }
        public static Money operator /(Money m, sbyte d)
        {
            return new Money(m.Amount / d, m.Currency, m.Round);
        }
        public static Money operator *(Money m, sbyte d)
        {
            return new Money(m.Amount * d, m.Currency, m.Round);
        }
        public static bool operator >=(Money m, decimal d)
        {
            return m.Amount >= d;
        }
        public static bool operator <=(Money m, decimal d)
        {
            return m.Amount <= d;
        }
        public static bool operator >=(Money m, Money d)
        {
            return m.Amount >= d.Amount;
        }
        public static bool operator <=(Money m, Money d)
        {
            return m.Amount <= d.Amount;
        }

        public bool Equals(Money other)
        {
            return !ReferenceEquals(null, other) && Amount == other.Amount && Currency.Code == other.Currency.Code;
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && obj is Money && Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(Money other)
        {
            return Amount.CompareTo(other.Amount);
        }
        public int CompareTo(object obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return CompareTo((Money)obj);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Amount, Currency.ToString());
        }
    }
}