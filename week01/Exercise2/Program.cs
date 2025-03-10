using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();

        // Convert input to integer
        int percentage = int.Parse(userInput);

        // Initialize the letter grade and sign variables
        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+ or -)
        // Get the last digit of the percentage
        int lastDigit = percentage % 10;

        // Apply the sign according to the last digit
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Handle exceptional cases
        // No A+ grade
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // No F+ or F- grade
        if (letter == "F")
        {
            sign = "";
        }

        // Display the grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if the user passed the course (>= 70)
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't be discouraged! You can do better next time.");
        }
    }
}