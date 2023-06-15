using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction firstConstructor = new Fraction();
        Console.WriteLine(firstConstructor.GetFractionString());
        Console.WriteLine(firstConstructor.GetDecimalValue());

        Fraction secondConstructor = new Fraction(5);
        Console.WriteLine(secondConstructor.GetFractionString());
        Console.WriteLine(secondConstructor.GetDecimalValue());

        Fraction thirdConstructor = new Fraction(3,4);
        Console.WriteLine(thirdConstructor.GetFractionString());
        Console.WriteLine(thirdConstructor.GetDecimalValue());
    }
}