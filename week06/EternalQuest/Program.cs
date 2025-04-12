using System;

namespace EternalQuest
{
    static class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            int choice = -1;

            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine($"You have {goalManager.GetTotalPoints()} points. {goalManager.GetLevel()}\n");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  0. Quit");
                Console.Write("Select a choice from the menu: ");

                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        goalManager.CreateGoal();
                        break;
                    case 2:
                        goalManager.ListGoals();
                        break;
                    case 3:
                        goalManager.SaveGoals();
                        break;
                    case 4:
                        goalManager.LoadGoals();
                        break;
                    case 5:
                        goalManager.RecordGoalEvent();
                        break;
                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            // EXCEEDS REQUIREMENTS: You can add level-up features or penalties for missing goals.
        }
    }
}