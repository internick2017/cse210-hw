// Comment.cs
using System;

public class Comment
{
    // Properties to track the commenter's name and the text of the comment
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Constructor to initialize the comment with commenter name and text
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}