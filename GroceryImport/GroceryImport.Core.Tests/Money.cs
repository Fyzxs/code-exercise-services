using System;

namespace GroceryImport.Core.Tests
{
    /// <summary>
    /// Super simple Money object. If you deal with money and don't have SOMETHING wrapping the raw data - you're doing it wrong.
    /// </summary>
    public sealed class Money : IEquatable<Money>
    {
        public static implicit operator string(Money origin) => origin._amount.ToString("C");
        public static implicit operator double(Money origin) => origin._amount;

        public static readonly Money None = new Money(0);

        private readonly double _amount;

        public Money(double amount) => _amount = amount;

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _amount.Equals(other._amount);
        }

        public override bool Equals(object obj) => Equals(obj as Money);

        public override int GetHashCode() => _amount.GetHashCode();
    }
}