using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===");
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine(); // Add a blank line between entries
        }
    }

    public void SearchEntries(string searchTerm)
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to search.");
            return;
        }

        Console.WriteLine($"\n=== Search Results for '{searchTerm}' ===");

        // Convert search term to lowercase for case-insensitive search
        searchTerm = searchTerm.ToLower();

        int matchCount = 0;

        foreach (Entry entry in _entries)
        {
            // Check if the search term exists in the text, prompt, or date (case insensitive)
            if (entry.Text.ToLower().Contains(searchTerm) ||
                entry.Prompt.ToLower().Contains(searchTerm) ||
                entry.Date.ToLower().Contains(searchTerm))
            {
                entry.Display();
                Console.WriteLine(); // Add a blank line between entries
                matchCount++;
            }
        }

        if (matchCount == 0)
        {
            Console.WriteLine("No entries found matching your search term.");
        }
        else
        {
            Console.WriteLine($"Found {matchCount} matching entries.");
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Save in format: date~|~prompt~|~text
                    outputFile.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Text}");
                }
            }

            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            _entries.Clear(); // Clear existing entries

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");

                if (parts.Length >= 3)
                {
                    Entry entry = new Entry();
                    entry.Date = parts[0];
                    entry.Prompt = parts[1];
                    entry.Text = parts[2];

                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}