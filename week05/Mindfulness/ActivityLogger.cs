using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class ActivityLogger
{
    private List<ActivityLog> _logs;
    private string _logFilePath;

    public ActivityLogger()
    {
        _logs = new List<ActivityLog>();
        _logFilePath = "mindfulness_logs.json";
        LoadLogs();
    }

    public void LogActivity(string activityName, int duration)
    {
        ActivityLog log = new ActivityLog
        {
            ActivityName = activityName,
            Duration = duration,
            DateTime = DateTime.Now
        };

        _logs.Add(log);
        SaveLogs();
    }

    public void DisplayStats()
    {
        Console.Clear();
        Console.WriteLine("===== Mindfulness Activity Statistics =====");
        Console.WriteLine();

        if (_logs.Count == 0)
        {
            Console.WriteLine("No activities have been logged yet.");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            return;
        }

        int totalActivities = _logs.Count;
        int totalDuration = _logs.Sum(log => log.Duration);

        var activityCounts = _logs
            .GroupBy(log => log.ActivityName)
            .Select(group => new { Name = group.Key, Count = group.Count(), TotalDuration = group.Sum(log => log.Duration) })
            .OrderByDescending(item => item.Count)
            .ToList();

        Console.WriteLine($"Total Activities Completed: {totalActivities}");
        Console.WriteLine($"Total Time Spent: {totalDuration} seconds ({totalDuration / 60.0:F1} minutes)");
        Console.WriteLine();
        Console.WriteLine("Activities by frequency:");

        foreach (var activity in activityCounts)
        {
            Console.WriteLine($"- {activity.Name}: {activity.Count} times ({activity.TotalDuration / 60.0:F1} minutes)");
        }

        // Display activity by day of week
        var byDayOfWeek = _logs
            .GroupBy(log => log.DateTime.DayOfWeek)
            .Select(group => new { DayOfWeek = group.Key, Count = group.Count() })
            .OrderByDescending(item => item.Count)
            .ToList();

        Console.WriteLine();
        Console.WriteLine("Most active days:");
        foreach (var day in byDayOfWeek)
        {
            Console.WriteLine($"- {day.DayOfWeek}: {day.Count} activities");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    private void SaveLogs()
    {
        string jsonString = JsonSerializer.Serialize(_logs);
        File.WriteAllText(_logFilePath, jsonString);
    }

    private void LoadLogs()
    {
        if (File.Exists(_logFilePath))
        {
            string jsonString = File.ReadAllText(_logFilePath);
            _logs = JsonSerializer.Deserialize<List<ActivityLog>>(jsonString) ?? new List<ActivityLog>();
        }
    }
}

public class ActivityLog
{
    public string ActivityName { get; set; }
    public int Duration { get; set; }
    public DateTime DateTime { get; set; }
}