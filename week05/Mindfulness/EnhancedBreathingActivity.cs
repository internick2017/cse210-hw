using System;
using System.Collections.Generic;

public class EnhancedBreathingActivity : BreathingActivity
{
    private int _inhaleTime;
    private int _exhaleTime;
    private int _holdTime;
    private string _patternName;
    private Dictionary<string, (int inhale, int hold, int exhale)> _breathingPatterns;

    public EnhancedBreathingActivity() : base()
    {
        _patternName = "Default";
        _inhaleTime = 4;
        _holdTime = 0;
        _exhaleTime = 6;
        InitializeBreathingPatterns();
    }

    private void InitializeBreathingPatterns()
    {
        _breathingPatterns = new Dictionary<string, (int, int, int)>
        {
            { "Default", (4, 0, 6) },
            { "Box Breathing", (4, 4, 4) },
            { "4-7-8 Technique", (4, 7, 8) },
            { "Relaxing Breath", (6, 0, 8) },
            { "Custom", (0, 0, 0) }
        };
    }

    public new void Run()
    {
        SelectBreathingPattern();
        DisplayStartingMessage();

        // Main activity logic
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Console.WriteLine();
        Console.WriteLine($"You selected the {_patternName} breathing pattern.");
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            // Inhale phase
            Console.Write("Breathe in");
            if (_inhaleTime > 0)
            {
                Console.Write("...");
                ShowGrowingText(_inhaleTime);
            }
            Console.WriteLine();

            // Hold phase if applicable
            if (_holdTime > 0)
            {
                Console.Write("Hold your breath...");
                ShowCountDown(_holdTime);
                Console.WriteLine();
            }

            // Exhale phase
            Console.Write("Breathe out");
            if (_exhaleTime > 0)
            {
                Console.Write("...");
                ShowShrinkingText(_exhaleTime);
            }
            Console.WriteLine();

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private void SelectBreathingPattern()
    {
        Console.Clear();
        Console.WriteLine("Select a breathing pattern:");
        Console.WriteLine("  1. Default (4-0-6)");
        Console.WriteLine("  2. Box Breathing (4-4-4)");
        Console.WriteLine("  3. 4-7-8 Technique");
        Console.WriteLine("  4. Relaxing Breath (6-0-8)");
        Console.WriteLine("  5. Custom");
        Console.Write("Enter your choice: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _patternName = "Default";
                (_inhaleTime, _holdTime, _exhaleTime) = _breathingPatterns[_patternName];
                break;
            case "2":
                _patternName = "Box Breathing";
                (_inhaleTime, _holdTime, _exhaleTime) = _breathingPatterns[_patternName];
                break;
            case "3":
                _patternName = "4-7-8 Technique";
                (_inhaleTime, _holdTime, _exhaleTime) = _breathingPatterns[_patternName];
                break;
            case "4":
                _patternName = "Relaxing Breath";
                (_inhaleTime, _holdTime, _exhaleTime) = _breathingPatterns[_patternName];
                break;
            case "5":
                _patternName = "Custom";
                SetCustomBreathingPattern();
                break;
            default:
                _patternName = "Default";
                (_inhaleTime, _holdTime, _exhaleTime) = _breathingPatterns[_patternName];
                break;
        }
    }

    private void SetCustomBreathingPattern()
    {
        Console.WriteLine("Set your custom breathing pattern:");

        Console.Write("Inhale time (seconds): ");
        _inhaleTime = int.Parse(Console.ReadLine());

        Console.Write("Hold time (seconds): ");
        _holdTime = int.Parse(Console.ReadLine());

        Console.Write("Exhale time (seconds): ");
        _exhaleTime = int.Parse(Console.ReadLine());

        // Update the custom pattern in the dictionary
        _breathingPatterns["Custom"] = (_inhaleTime, _holdTime, _exhaleTime);
    }

    private void ShowGrowingText(int seconds)
    {
        string animation = "o O Ο";
        string[] frames = animation.Split(' ');

        for (int i = 0; i < seconds; i++)
        {
            foreach (string frame in frames)
            {
                Console.Write(frame);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }

    private void ShowShrinkingText(int seconds)
    {
        string animation = "Ο O o";
        string[] frames = animation.Split(' ');

        for (int i = 0; i < seconds; i++)
        {
            foreach (string frame in frames)
            {
                Console.Write(frame);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }
}