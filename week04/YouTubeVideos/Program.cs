using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Exploring the Alps", "AdventureTube", 300);
        video1.AddComment(new Comment("Alice", "Beautiful scenery!"));
        video1.AddComment(new Comment("John", "I want to visit now."));
        video1.AddComment(new Comment("Sophie", "Amazing drone shots!"));

        Video video2 = new Video("How to Bake a Cake", "ChefJoy", 600);
        video2.AddComment(new Comment("Mark", "Looks delicious!"));
        video2.AddComment(new Comment("Jenny", "Tried it and loved it."));
        video2.AddComment(new Comment("Paul", "Great tutorial, thanks!"));

        Video video3 = new Video("Top 10 Programming Tips", "CodeMaster", 480);
        video3.AddComment(new Comment("Sam", "Tip #5 changed my life."));
        video3.AddComment(new Comment("Lily", "Clear and concise."));
        video3.AddComment(new Comment("Mike", "Subscribed instantly!"));

        Video video4 = new Video("Morning Yoga Routine", "ZenDaily", 720);
        video4.AddComment(new Comment("Anna", "Perfect for my mornings."));
        video4.AddComment(new Comment("Leo", "I feel relaxed already."));
        video4.AddComment(new Comment("Grace", "Thanks for the calm vibe."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display information for each video
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}

