public class Resume
{
    public string _name = "";
    public List<Job> _jobs = [];

    public Resume() {}

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Experience:");
        
        foreach (Job job in _jobs)
        {
            job.Display();
        }        
    }
}