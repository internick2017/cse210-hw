using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Video Tracking Program");
        Console.WriteLine("------------------------------");

        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create first video
        Video video1 = new Video("Learn C# in 30 Minutes", "Programming with John", 1800);
        video1.AddComment(new Comment("Sarah Johnson", "This tutorial was super helpful! Thanks for making it so easy to understand."));
        video1.AddComment(new Comment("Mike Smith", "I've been struggling with C# for weeks, and this finally made it click!"));
        video1.AddComment(new Comment("Dev_Enthusiast", "Could you make a follow-up on advanced topics?"));
        videos.Add(video1);

        // Create second video
        Video video2 = new Video("DIY Home Automation on a Budget", "Tech Savvy", 1260);
        video2.AddComment(new Comment("HomeBuilder22", "I implemented this in my apartment and it works great!"));
        video2.AddComment(new Comment("ElectronicsWizard", "Which microcontroller would you recommend for outdoor sensors?"));
        video2.AddComment(new Comment("Jane Doe", "Love this series, please keep them coming!"));
        video2.AddComment(new Comment("SmartHome Guru", "I've been doing this professionally for years and your approach is innovative."));
        videos.Add(video2);

        // Create third video
        Video video3 = new Video("Beginner's Guide to Digital Art", "Creative Canvas", 2340);
        video3.AddComment(new Comment("ArtStudent", "This helped me so much with my class project!"));
        video3.AddComment(new Comment("Painter123", "Which tablet do you recommend for beginners?"));
        video3.AddComment(new Comment("DigitalDreamer", "Your techniques transformed my artwork!"));
        videos.Add(video3);

        // Create fourth video
        Video video4 = new Video("Healthy Meal Prep for the Week", "Nutrition Matters", 1500);
        video4.AddComment(new Comment("FitnessFan", "Made all of these on Sunday, and my weekday meals are sorted!"));
        video4.AddComment(new Comment("NutritionNewbie", "Are there vegetarian alternatives for these recipes?"));
        video4.AddComment(new Comment("MealPrepMaster", "The storage tips are game-changing. My food stays fresh all week now."));
        videos.Add(video4);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {FormatTime(video.LengthInSeconds)}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
        }

        Console.WriteLine("\n------------------------------");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    // Helper method to format seconds into minutes and seconds
    static string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        return $"{minutes}:{remainingSeconds:D2}";
    }
}