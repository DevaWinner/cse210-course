using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Cook Spaghetti", "Chef John", 300);
        Video video2 = new Video("Yoga for Beginners", "Sarah Smith", 450);
        Video video3 = new Video("Travel Vlog: Japan", "Mike Adventures", 600);
        Video video4 = new Video("DIY Home Decor", "Emily Crafts", 400);

        // Add comments to Chef John's video
        video1.AddComment(new Comment("Alice", "Great recipe, my family loved it!"));
        video1.AddComment(new Comment("Bob", "Very easy to follow, thanks!"));
        video1.AddComment(new Comment("Charlie", "Delicious! I added extra garlic."));

        // Add comments to Sarah Smith's video
        video2.AddComment(new Comment("Dana", "Perfect for beginners!"));
        video2.AddComment(new Comment("Eli", "I feel so relaxed now."));
        video2.AddComment(new Comment("Fay", "Excellent instructions, thank you!"));

        // Add comments to Mike Adventures' video
        video3.AddComment(new Comment("George", "Loved the places you visited!"));
        video3.AddComment(new Comment("Hannah", "Makes me want to travel there."));
        video3.AddComment(new Comment("Ian", "Great vlog, very informative."));

        // Add comments to Emily Crafts' video
        video4.AddComment(new Comment("Jack", "Awesome ideas for home decor."));
        video4.AddComment(new Comment("Kira", "Can't wait to try these DIYs."));
        video4.AddComment(new Comment("Liam", "Simple and creative, well done!"));

        // List of videos
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video details and comments for each video
        Console.Clear();
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
