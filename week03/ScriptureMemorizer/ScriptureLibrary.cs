using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public int Count { get { return _scriptures.Count; } }

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }

    public void AddScripture(Reference reference, string text)
    {
        Scripture scripture = new Scripture(reference, text);
        _scriptures.Add(scripture);
    }

    public Scripture GetScripture(int index)
    {
        if (index >= 0 && index < _scriptures.Count)
        {
            return _scriptures[index];
        }
        return null;
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            return null;
        }

        int randomIndex = _random.Next(_scriptures.Count);
        return _scriptures[randomIndex];
    }

    public void ListAllScriptures()
    {
        Console.WriteLine("Available Scriptures:");
        for (int i = 0; i < _scriptures.Count; i++)
        {
            // Create a temporary scripture to get its display text, then extract just the reference
            string displayText = _scriptures[i].GetDisplayText();
            string reference = displayText.Split('\n')[0];

            Console.WriteLine($"{i + 1}. {reference}");
        }
    }
}