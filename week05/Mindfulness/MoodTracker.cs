using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class MoodTracker
{
    private List<MoodEntry> _moodEntries;
    private string _moodFilePath;

    public MoodTracker()
    {
        _moodEntries = new List<MoodEntry>();
        _moodFilePath = "mood_entries.json";
        LoadMoodEntries();
    }

    public void TrackMoodForActivity(string activityName, int duration)
    {
        // Get mood before activity
        Console.Clear();
        Console.WriteLine("Before we begin, how would you rate your current mood?");
        int beforeMood = GetMoodRating();

        // Activity runs here (outside this class)

        // Get mood after activity
        Console.Clear();
        Console.WriteLine("Now that you've completed the activity, how would you rate your current mood?");
        int afterMood = GetMoodRating();

        // Record the mood change
        MoodEntry entry = new MoodEntry
        {
            ActivityName = activityName,
            Duration = duration,
            MoodBefore = beforeMood,
            MoodAfter = afterMood,
            DateTime = DateTime.Now
        };

        _moodEntries.Add(entry);
        SaveMoodEntries();
    }

    private int GetMoodRating()
    {
        Console.WriteLine("Rate from 1-10 (1 = very low, 10 = excellent):");
        Console.WriteLine("1   2   3   4   5   6   7   8   9   10");
        Console.WriteLine("👎                 😐                 👍");
        Console.Write("Your rating: ");

        while (true)
        {
            try
            {
                int rating = int.Parse(Console.ReadLine());
                if (rating >= 1 && rating <= 10)
                {
                    return rating;
                }
                Console.Write("Please enter a number between 1 and 10: ");
            }
            catch
            {
                Console.Write("Please enter a valid number: ");
            }
        }
    }

    public void DisplayMoodStats()
    {
        Console.Clear();
        Console.WriteLine("===== Mood Improvement Statistics =====");
        Console.WriteLine();

        if (_moodEntries.Count == 0)
        {
            Console.WriteLine("No mood data has been recorded yet.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            return;
        }

        // Calculate average mood change by activity type
        var moodChangeByActivity = _moodEntries
            .GroupBy(entry => entry.ActivityName)
            .Select(group => new
            {
                ActivityName = group.Key,
                AverageMoodChange = group.Average(entry => entry.MoodAfter - entry.MoodBefore),
                Count = group.Count()
            })
            .OrderByDescending(item => item.AverageMoodChange)
            .ToList();

        Console.WriteLine("Average mood improvement by activity:");
        foreach (var activity in moodChangeByActivity)
        {
            string direction = activity.AverageMoodChange >= 0 ? "increase" : "decrease";
            Console.WriteLine($"- {activity.ActivityName}: {Math.Abs(activity.AverageMoodChange):F1} point {direction} (from {activity.Count} sessions)");
        }

        // Find the most effective activity for mood improvement
        var bestActivity = moodChangeByActivity.OrderByDescending(a => a.AverageMoodChange).FirstOrDefault();
        if (bestActivity != null && bestActivity.AverageMoodChange > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"The most effective activity for improving your mood is: {bestActivity.ActivityName}");
            Console.WriteLine($"It improves your mood by an average of {bestActivity.AverageMoodChange:F1} points.");
        }

        // Show trend over time
        Console.WriteLine();
        Console.WriteLine("Your recent mood trend:");
        var recentEntries = _moodEntries.OrderByDescending(e => e.DateTime).Take(5).Reverse().ToList();
        foreach (var entry in recentEntries)
        {
            string change = entry.MoodAfter > entry.MoodBefore ? "↑" : (entry.MoodAfter < entry.MoodBefore ? "↓" : "→");
            Console.WriteLine($"- {entry.DateTime.ToShortDateString()}: {entry.MoodBefore} {change} {entry.MoodAfter} ({entry.ActivityName})");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private void SaveMoodEntries()
    {
        string jsonString = JsonSerializer.Serialize(_moodEntries);
        File.WriteAllText(_moodFilePath, jsonString);
    }

    private void LoadMoodEntries()
    {
        if (File.Exists(_moodFilePath))
        {
            string jsonString = File.ReadAllText(_moodFilePath);
            _moodEntries = JsonSerializer.Deserialize<List<MoodEntry>>(jsonString) ?? new List<MoodEntry>();
        }
    }
}

public class MoodEntry
{
    public string ActivityName { get; set; }
    public int Duration { get; set; }
    public int MoodBefore { get; set; }
    public int MoodAfter { get; set; }
    public DateTime DateTime { get; set; }
}