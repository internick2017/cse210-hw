using System;
using System.Collections.Generic;

public class Video
{
    // Properties to track the title, author, and length of the video
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    // List to store comments on the video
    private List<Comment> _comments = new List<Comment>();

    // Constructor to initialize the video with title, author, and length
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get all comments
    public List<Comment> GetComments()
    {
        return _comments;
    }
}