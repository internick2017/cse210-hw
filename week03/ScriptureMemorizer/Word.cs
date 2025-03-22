using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide this word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show this word
    public void Show()
    {
        _isHidden = false;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the display text (either the word or underscores if hidden)
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace each character with an underscore
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}