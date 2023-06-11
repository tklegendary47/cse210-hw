using System;

class Program
{
    static void Main(string[] args)
    {

        Options option1 = new Options();
        option1._introduction = "Please select one of the following choices";
        option1._first = "Write";
        option1._second = "Display";
        option1._third = "Load";
        option1._fourth = "Save";
        option1._fifth = "Quit";

        option1.Display();
        
        string first_response = "-1";

        Journal journal = new Journal();

        do
        {
            Console.WriteLine("What would you like to do?");
            string first_responsee = Console.ReadLine();
            

            if (first_responsee == "1")                
            {   
                journal.Write();
            }
            if (first_responsee == "2")
            {
                journal.DisplayIt();
            }
            if (first_responsee == "3")
            {
                journal.Load();
            }         
            if (first_responsee == "4")
            {
                journal.Save();
            }
            else if (first_responsee == "5")
            {
                first_response = "5";
            }
        }
        while (first_response != "5");

    }
}