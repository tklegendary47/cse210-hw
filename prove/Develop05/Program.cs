using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
    
    bool replay = true;

    
    GoalManager game = new GoalManager();
    
    while (replay)
    
    {

       game.Start();

       string choice = Console.ReadLine();

        if (choice == "1")
        {
            game.CreateGoaL();

        } else if (choice == "2")
        {
            game.ListGoalsDetails();

        } else if (choice == "3") 
        {
            game.SaveGoals();

        } else if (choice =="4")
        {

            game.LoadGoals();

        } else if (choice == "5") 
        {

            game.RecordEvent();


        } else if (choice == "6")
        {
            Console.Clear();
            Console.WriteLine("End of the program");
            replay = false;
            
        }
    

    }
    
    }
}