using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Create a list to hold all the video objects
        List<Video> videos = new List<Video>();

        // ---------------------------------------------
        // --- Video 1: Programming Tutorial (3 comments) ---
        // ---------------------------------------------
        Video video1 = new Video("C# Classes Explained", "CodeMaster", 580);
        
        video1.AddComment(new Comment("LearnerX", "Great explanation of abstraction."));
        video1.AddComment(new Comment("DevGuru", "Helpful breakdown of fields vs. methods."));
        video1.AddComment(new Comment("User99", "I found the constructor part confusing."));
        
        videos.Add(video1);

        // ---------------------------------------------
        // --- Video 2: Travel Vlog (4 comments) ---
        // ---------------------------------------------
        Video video2 = new Video("Patagonia Hiking Vlog", "Wanderer", 1250);
        
        video2.AddComment(new Comment("TravelBug", "Beautiful cinematography!"));
        video2.AddComment(new Comment("NatureLover", "What kind of camera did you use?"));
        video2.AddComment(new Comment("Backpacker", "How long was the hike in total?"));
        video2.AddComment(new Comment("HikerDude", "Amazing views!"));
        
        videos.Add(video2);

        // ---------------------------------------------
        // --- Video 3: Cooking Recipe (4 comments) ---
        // ---------------------------------------------
        Video video3 = new Video("Quick 15-Minute Dinner", "ChefBake", 245);
        
        video3.AddComment(new Comment("FoodieFan", "Looks delicious and easy!"));
        video3.AddComment(new Comment("KitchenKing", "What kind of oil did you use?"));
        video3.AddComment(new Comment("NoSalt", "I tried this and it was a huge success."));
        video3.AddComment(new Comment("BestFood", "My kids loved it!"));
        
        videos.Add(video3);

        // ---------------------------------------------
        // 4. Iterate and Display Results
        // ---------------------------------------------
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}