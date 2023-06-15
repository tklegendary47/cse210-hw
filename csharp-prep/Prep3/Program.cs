using System;

class Program
{
    static void Main(string[] args)
    {   

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        while (true){
            
            Console.Write("What is your guess? ");
            string myGuess = Console.ReadLine();
            int guess = Int32.Parse(myGuess);
            

            if (guess < number){
                Console.WriteLine("Higher");
            }
            else if (guess > number){
                Console.WriteLine("Lower");
            }
            else{
                Console.WriteLine("You guessed it");
                Console.Write("Do you want to play again? ");
                string answer = Console.ReadLine();
                if (answer == "yes"){
                    number = randomGenerator.Next(1, 100);
                    continue;
                }
                else{
                    break;
                }
            }
        }
    }
}