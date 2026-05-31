using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("Ronald Diaz", "Programming with Classes");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new("Diego Diaz", "Calculus", "19", "19-25");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WrittingAssignment writtingAssignment = new("Verónica Hernández", "Contemporary History", "The Oil Nationalization");
        Console.WriteLine(writtingAssignment.GetSummary());
        Console.WriteLine(writtingAssignment.GetWrittingInformation());
    }
}