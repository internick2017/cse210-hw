using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int count)
    {
        // Get a list of indices of words that are not hidden
        List<int> unhiddenIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                unhiddenIndices.Add(i);
            }
        }

        // Count cannot be larger than the number of unhidden words
        count = Math.Min(count, unhiddenIndices.Count);

        // If there are no more words to hide, return
        if (count <= 0)
        {
            return;
        }

        // Hide random words that are not already hidden
        for (int i = 0; i < count; i++)
        {
            // Get a random index from the unhidden indices
            int randomIndexPosition = _random.Next(unhiddenIndices.Count);
            int randomIndex = unhiddenIndices[randomIndexPosition];

            // Hide the word at that index
            _words[randomIndex].Hide();

            // Remove this index from the list so we don't select it again
            unhiddenIndices.RemoveAt(randomIndexPosition);
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();

        // Join all words (hidden or visible) with spaces
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));

        return $"{referenceText}\n{scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        // Check if all words are hidden
        return _words.All(w => w.IsHidden());
    }
}