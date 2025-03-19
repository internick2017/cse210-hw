using System;

namespace Fractions
{
    public class Fraction
    {
        // Private attributes for encapsulation
        private int _numerator;
        private int _denominator;

        // Constructor with no parameters (initializes to 1/1)
        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        // Constructor with one parameter (initializes to n/1)
        public Fraction(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        // Constructor with two parameters (initializes to n/d)
        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        // Getter and setter for the numerator (top number)
        public int GetNumerator()
        {
            return _numerator;
        }

        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
        }

        // Getter and setter for the denominator (bottom number)
        public int GetDenominator()
        {
            return _denominator;
        }

        public void SetDenominator(int denominator)
        {
            _denominator = denominator;
        }

        // Method to return the fraction in string format (e.g., "3/4")
        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        // Method to return the decimal value of the fraction
        public double GetDecimalValue()
        {
            return (double)_numerator / _denominator;
        }
    }
}