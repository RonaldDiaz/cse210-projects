using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._company = "LUZ";
        job1._jobTitle = "Professor";
        job1._startYear = 2027;
        job1._endYear = 2047;

        Job job2 = new("BYU", "Student", 2025, 2028);

        Resume resume1 = new();
        resume1._name = "Ronald Díaz";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();      
    }
}