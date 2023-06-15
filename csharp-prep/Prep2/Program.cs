using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        

        string result = Console.ReadLine();
        int number = int.Parse(result);

        string grade = "";
        
        if(number >=90){
            grade = "A";
        }
        else if(number >=80){
           grade = "B";
        }
        else if(number >=70){
            grade = "C";
        }
        else if(number >=60){
            grade = "D";
        }
        else{
            grade = "F";
        }
        Console.WriteLine($"Your grade is: {grade}");

        if(number >=70){
            Console.WriteLine("Congratulations you passed the class");
        }
        else if(number < 70){
            Console.WriteLine("Sorry, you didn't pass the course, we encourage you to try your best the next semester.");
        }
    }
}