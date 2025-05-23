using System;
using System.Text.RegularExpressions;

namespace Acme.Hotel.ValueObjects
{
    public class Email : IEquatable<Email>
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.", nameof(value));
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Invalid email format.", nameof(value));
            Value = value;
        }

        public override string ToString() => Value;
        public override bool Equals(object obj) => Equals(obj as Email);
        public bool Equals(Email other) => other != null && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
        public static implicit operator string(Email email) => email.Value;
        public static explicit operator Email(string value) => new Email(value);
    }
}
