using System;

/*
* EXCEEDING REQUIREMENTS:
* This program exceeds the core requirements by implementing a search functionality
* that allows users to search through their journal entries. The search feature works as follows:
*
* 1. Users can search for any text within entry content, prompts, or dates
* 2. The search is case-insensitive for better user experience
* 3. The program displays all matching entries and a count of how many were found
* 4. If no entries match the search term, the user is informed accordingly
*
* This feature adds significant value by helping users find specific memories or topics
* they've written about, especially as their journal grows larger over time.
*/

class Program
{
    static void Main(string[] args)
    {
        // Create instances of the needed classes
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            // Display menu
            Console.WriteLine("\nJournal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Exit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write a new entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry.Date = DateTime.Now.ToShortDateString();
                    newEntry.Prompt = prompt;
                    newEntry.Text = response;

                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    // Display the journal
                    journal.DisplayAll();
                    break;

                case "3":
                    // Save the journal to a file
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    // Load the journal from a file
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    // Search entries
                    Console.Write("Enter search term: ");
                    string searchTerm = Console.ReadLine();
                    journal.SearchEntries(searchTerm);
                    break;

                case "6":
                    // Exit
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}