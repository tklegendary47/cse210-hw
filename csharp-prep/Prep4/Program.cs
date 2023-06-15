using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();

        while (true){
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int inputNumber = Int32.Parse(input);
            numbers.Add(inputNumber);
            if (inputNumber != 0){
                continue;
            }
            else{
                int total = numbers.Sum();
                double average = numbers.Average();
                int max = numbers.Max();
                Console.WriteLine($"The total sum is {total}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The max number is: {max}");
                break;
            }
        }
    }
}