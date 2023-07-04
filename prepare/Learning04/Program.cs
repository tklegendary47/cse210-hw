using System;

class Program
{
    static void Main(string[] args)
    {
        // MathAssignment mathAssignment = new MathAssignment("Daniel Faria", "Inheritence", "7.3", "8-19");
        WritingAssignment writingAssignment = new WritingAssignment("Daniel Faria", "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());


    }
}