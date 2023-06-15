using System;


class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Proverbs 13:20"," Walk with the wise and become wise, for a companion of fools suffers harm.");

        

        while(!scripture.AllWordsHidden){

            Console.Clear();    
            scripture.Display();
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            
            string input = Console.ReadLine();

            if (input.ToLower() == "quit"){
                break;
            }
            else{
                scripture.HideRandomWord();
            }
        }

        Console.Clear();
        scripture.DisplayHidden();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
