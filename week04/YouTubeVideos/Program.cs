using System;

class Program
{
    static void Main(string[] args)
    {

        // New videos
        Video video1 = new("Hack Pack - Introduction to Arduino", "CrunchLabs", 1331);
        Video video2 = new("I Recreated Star Wars out of Cardboard", "Zach King", 3160);
        Video video3 = new("How a SECOND-RATE language humiliated FIRST-RATE languages - Python", "fatdev;", 1029);
        Video video4 = new("The Psychology of People Who Know How to Fix Everything", "The Invisible Psychology", 576);

        // Extra video with no comments, to handle this case.
        Video video5 = new("Is ThereSomething Faster Than the Speed of Light?", "Veritasium", 2752);

        // Video #1 Comments (5)
        video1.AddComment("yobgow", "I just think of how different my life could have been if I had more teachers that could engage their audience like you do Mark. Love your work.");
        video1.AddComment("pacsmile", "You definitely need to know how to code, people can copy/paste whatever they want, but if they don't understand what they're reading they can't really tweak the stuff.");
        video1.AddComment("michaelbryson5870", "I'm an electrical/computer engineer and I love using Arduino for projects. This is a great big picture explanation of how it all works together. Nicely done!");
        video1.AddComment("Thatstruefact", "You said electrons move from the positive terminal to the negative terminal of the battery, but in reality, the opposite happens.");
        video1.AddComment("e_10y-o7x", "What i love about Marks videos are that they are for all ages. He explains it in a way that makes sence to all ❤");

        // Video #2 Comments (4)
        video2.AddComment("UnreliableStudios", "This feels like old youtube. I love it.");
        video2.AddComment("SGCSmith", "This is what makes YouTube. Not AI slop. Not advertisements. Just people having fun making movies.");
        video2.AddComment("DaClancy", "I think I just experienced what the first Star Wars fans witnessed in 1977. Stunning");
        video2.AddComment("bluered3228", "How does this only have 160k views after 9 days!  Come on YouTube!  It's fantastic.");

        // Video #3 Comments (4)
        video3.AddComment("AnimeHyperDimension", "Even AI said so... Python seems like it was designed for AI to use and create projects, given its compact structures and the indentation feature.");
        video3.AddComment("dariemperez6833", "Nobody remembers that Instagram was programmed in Python + Django. For all those who say they wouldn't use Python for 'serious' projects.");
        video3.AddComment("fdrautodidata", "I'm a programmer, always have been. I started with Japanese mini PCs when I was 13, and with BASIC 37 years ago. I know most languages, but when I discovered Python, it was pure common sense. Natural language.");
        video3.AddComment("Ignacio-yj8ow", "Python is great for scripting and quick automation, but for serious projects I would go with C#, Java, or Rust.");

        // Video #4 Comments (3)
        video4.AddComment("harley443", "I love taking things apart, seeing how they work, and how to fix them. I feel super happy when I manage to fix something. I've always been curious, and that's led me to learn about everything. And the video is exactly as it says.");
        video4.AddComment("Alejandro Gonzalez-uz3dx", "It's better to fail doing something than to fail doing nothing.");
        video4.AddComment("elvengador223", "I learned to repair things since childhood thanks to my grandfather.");

        List<Video> videos = [video1, video2, video3, video4, video5];

        foreach(Video video in videos)
        {
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(video.GetDisplayText());
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Comments: ");            
            if (video.TotalComments() > 0)
            {
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine(comment.GetDisplayText());
                }
            }
            else
            {
                Console.WriteLine("No Comments");                
            }
        }
    }
}