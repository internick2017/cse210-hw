using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("This program helps you memorize scriptures by gradually hiding words.");
        Console.WriteLine();

        // Initialize the scripture library
        ScriptureLibrary library = InitializeLibrary();

        // Main menu loop
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Memorize a scripture from the library");
            Console.WriteLine("2. Enter a custom scripture");
            Console.WriteLine("3. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MemorizeFromLibrary(library);
                    break;
                case "2":
                    MemorizeCustomScripture();
                    break;
                case "3":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using Scripture Memorizer!");
    }

    static ScriptureLibrary InitializeLibrary()
    {
        ScriptureLibrary library = new ScriptureLibrary();

        // Add some default scriptures
        library.AddScripture(new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

        library.AddScripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");

        library.AddScripture(new Reference("1 Nephi", 3, 7),
            "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        // Try to load scriptures from file if it exists
        try
        {
            if (File.Exists("scriptures.txt"))
            {
                string[] lines = File.ReadAllLines("scriptures.txt");
                for (int i = 0; i < lines.Length; i += 2)
                {
                    if (i + 1 < lines.Length)
                    {
                        string referenceText = lines[i];
                        string scriptureText = lines[i + 1];

                        Reference reference = ParseReference(referenceText);
                        if (reference != null)
                        {
                            library.AddScripture(reference, scriptureText);
                        }
                    }
                }
                Console.WriteLine($"Loaded {lines.Length / 2} scriptures from file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures from file: {ex.Message}");
        }

        return library;
    }

    static Reference ParseReference(string referenceText)
    {
        try
        {
            // Split the reference into book and verses
            int lastSpace = referenceText.LastIndexOf(' ');
            if (lastSpace == -1) return null;

            string book = referenceText.Substring(0, lastSpace);
            string verseRef = referenceText.Substring(lastSpace + 1);

            // Split chapter and verse(s)
            string[] parts = verseRef.Split(':');
            if (parts.Length != 2) return null;

            int chapter = int.Parse(parts[0]);

            // Check if it's a verse range
            if (parts[1].Contains("-"))
            {
                string[] verses = parts[1].Split('-');
                int startVerse = int.Parse(verses[0]);
                int endVerse = int.Parse(verses[1]);
                return new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(parts[1]);
                return new Reference(book, chapter, verse);
            }
        }
        catch
        {
            return null;
        }
    }

    static void MemorizeFromLibrary(ScriptureLibrary library)
    {
        if (library.Count == 0)
        {
            Console.WriteLine("The scripture library is empty. Please add a custom scripture.");
            return;
        }

        // Let user choose a scripture or get a random one
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Choose a specific scripture");
        Console.WriteLine("2. Get a random scripture");

        string choice = Console.ReadLine();
        Scripture scripture = null;

        if (choice == "1")
        {
            // Display available scriptures
            library.ListAllScriptures();

            Console.WriteLine("Enter the number of the scripture you want to memorize:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= library.Count)
            {
                scripture = library.GetScripture(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return;
            }
        }
        else
        {
            scripture = library.GetRandomScripture();
            Console.WriteLine("Selected a random scripture for you!");
        }

        MemorizeScripture(scripture);
    }

    static void MemorizeCustomScripture()
    {
        Console.WriteLine("Enter the scripture reference (e.g., 'John 3:16' or 'Proverbs 3:5-6'):");
        string referenceText = Console.ReadLine();

        Reference reference = ParseReference(referenceText);
        if (reference == null)
        {
            Console.WriteLine("Invalid reference format. Please try again.");
            return;
        }

        Console.WriteLine("Enter the scripture text:");
        string scriptureText = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(scriptureText))
        {
            Console.WriteLine("Scripture text cannot be empty.");
            return;
        }

        Scripture scripture = new Scripture(reference, scriptureText);

        // Ask if they want to save this scripture to the library
        Console.WriteLine("Would you like to save this scripture to your library? (yes/no)");
        string saveChoice = Console.ReadLine().ToLower();

        if (saveChoice == "yes" || saveChoice == "y")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("scriptures.txt", true))
                {
                    writer.WriteLine(referenceText);
                    writer.WriteLine(scriptureText);
                }
                Console.WriteLine("Scripture saved to library.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving scripture: {ex.Message}");
            }
        }

        MemorizeScripture(scripture);
    }

    static void MemorizeScripture(Scripture scripture)
    {
        Console.WriteLine("How many words would you like to hide at a time? (default is 3)");
        if (!int.TryParse(Console.ReadLine(), out int wordsToHide))
        {
            wordsToHide = 3;
        }

        if (wordsToHide <= 0)
        {
            wordsToHide = 3;
        }

        bool quit = false;

        while (!quit)
        {
            // Clear the console
            Console.Clear();

            // Display the scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            // Get user input
            string userInput = Console.ReadLine();

            // Check if the user wants to quit or if all words are hidden
            if (userInput.ToLower() == "quit" || scripture.IsCompletelyHidden())
            {
                quit = true;
            }
            else
            {
                // Hide more words
                scripture.HideRandomWords(wordsToHide);
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Congratulations! You've memorized the entire scripture!");
        }

        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}

/*
EXCEEDING REQUIREMENTS:
1. Added a full menu system for better user experience
2. Implemented a Scripture Library to store multiple scriptures
3. Added ability to save scriptures to a file and load them when the program starts
4. Added option to choose a specific scripture or get a random one
5. Allows users to customize how many words to hide at a time
6. Includes proper error handling for file operations and user input
7. Only selects from words that are not already hidden (implemented in the Scripture class)
8. Added congratulatory message when the scripture is fully memorized
*/