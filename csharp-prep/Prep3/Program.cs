using System;

class Program
{
    static void Main(string[] args)
    {

   Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

   int guess = -1;

      //   Console.Write("What is the magic number? ");
      // magicNumber = int.Parse(Console.ReadLine()); 

  while (guess != magicNumber)

    {


     Console.Write("What is your guess?");
        guess = int.Parse(Console.ReadLine());

     if (guess > magicNumber)
{
  Console.WriteLine("Lower");
}

   else if (guess < magicNumber)
   {
  Console.WriteLine("Higher");
}
  
else  
     {
      
      Console.WriteLine("Congratulations! You guessed correctly!");

    } 
    }
    
    }
}