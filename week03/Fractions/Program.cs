using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test the first constructor (no parameters, initializes to 1/1)
            Fraction fraction1 = new Fraction();
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());

            // Test the second constructor (one parameter, initializes to n/1)
            Fraction fraction2 = new Fraction(5);
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction2.GetDecimalValue());

            // Test the third constructor (two parameters, initializes to n/d)
            Fraction fraction3 = new Fraction(3, 4);
            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());

            // Test one more fraction
            Fraction fraction4 = new Fraction(1, 3);
            Console.WriteLine(fraction4.GetFractionString());
            Console.WriteLine(fraction4.GetDecimalValue());

            // Test getters and setters
            Console.WriteLine("\nTesting getters and setters:");
            Fraction fraction5 = new Fraction(1, 2);
            Console.WriteLine($"Original fraction: {fraction5.GetFractionString()}");

            // Change values using setters
            fraction5.SetNumerator(5);
            fraction5.SetDenominator(8);

            // Retrieve and display using getters
            Console.WriteLine($"Numerator: {fraction5.GetNumerator()}");
            Console.WriteLine($"Denominator: {fraction5.GetDenominator()}");
            Console.WriteLine($"Modified fraction: {fraction5.GetFractionString()}");
            Console.WriteLine($"Decimal value: {fraction5.GetDecimalValue()}");
        }
    }
}