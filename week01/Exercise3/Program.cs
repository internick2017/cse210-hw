using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize play again variable
        string playAgain = "yes";

        // Loop to allow playing multiple games
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            // Initialize guess variable and guess counter
            int guess = -1;
            int guessCount = 0;

            // Game introduction
            Console.WriteLine("\nWelcome to the Guess My Number game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            // Loop until the user guesses the magic number
            while (guess != magicNumber)
            {
                // Ask for user's guess
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();
                guess = int.Parse(userInput);

                // Increment guess counter
                guessCount++;

                // Check if the guess is correct, too high, or too low
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("\nWould you like to play again? (yes/no) ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("\nThank you for playing Guess My Number! Goodbye!");
    }
}