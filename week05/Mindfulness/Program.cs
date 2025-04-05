using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        ActivityLogger logger = new ActivityLogger();
        MoodTracker moodTracker = new MoodTracker();

        while (!quit)
        {
            // Display menu
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("==================");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start enhanced breathing activity");
            Console.WriteLine("  5. View activity statistics");
            Console.WriteLine("  6. View mood statistics");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    moodTracker.TrackMoodForActivity("Breathing Activity", breathingActivity._duration);
                    breathingActivity.Run();
                    // Log the activity
                    logger.LogActivity("Breathing Activity", breathingActivity._duration);
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    moodTracker.TrackMoodForActivity("Reflecting Activity", reflectingActivity._duration);
                    reflectingActivity.Run();
                    // Log the activity
                    logger.LogActivity("Reflecting Activity", reflectingActivity._duration);
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    moodTracker.TrackMoodForActivity("Listing Activity", listingActivity._duration);
                    listingActivity.Run();
                    // Log the activity
                    logger.LogActivity("Listing Activity", listingActivity._duration);
                    break;
                case "4":
                    EnhancedBreathingActivity enhancedBreathing = new EnhancedBreathingActivity();
                    moodTracker.TrackMoodForActivity("Enhanced Breathing", enhancedBreathing._duration);
                    enhancedBreathing.Run();
                    // Log the activity
                    logger.LogActivity("Enhanced Breathing", enhancedBreathing._duration);
                    break;
                case "5":
                    logger.DisplayStats();
                    break;
                case "6":
                    moodTracker.DisplayMoodStats();
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}

/*
Exceeded Requirements:

1. Added customizable breathing patterns (implemented in EnhancedBreathingActivity.cs):
   - Users can select from different breathing techniques (Default, Box Breathing, 4-7-8)
   - Custom breathing patterns with configurable inhale, hold, and exhale times
   - Visual animations that grow and shrink with breathing

2. Added activity logging (implemented in ActivityLogger.cs):
   - Keeps track of which activities were performed and when
   - Saves activity logs to a JSON file for persistence between sessions
   - Provides statistics on most frequent activities and total mindfulness time
   - Analyzes patterns by day of week

3. Added mood tracking (implemented in MoodTracker.cs):
   - Asks users about their mood before and after activities
   - Provides insights on which activities improve their mood most effectively
   - Shows trends in mood improvement over time
   - Recommends the most effective activity for mood improvement

4. Visual improvements:
   - Enhanced spinner animations
   - Text-based visualization for the breathing exercises
   - Better formatted menu with title
*/