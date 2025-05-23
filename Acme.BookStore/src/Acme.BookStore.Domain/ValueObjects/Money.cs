using System;
using System.Globalization;

namespace Acme.Hotel.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency = "USD")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required.", nameof(currency));
            Amount = decimal.Round(amount, 2);
            Currency = currency.ToUpper(CultureInfo.InvariantCulture);
        }

        public override string ToString() => $"{Amount} {Currency}";
        public override bool Equals(object obj) => Equals(obj as Money);
        public bool Equals(Money other) => other != null && Amount == other.Amount && Currency == other.Currency;
        public override int GetHashCode() => HashCode.Combine(Amount, Currency);
    }
}
