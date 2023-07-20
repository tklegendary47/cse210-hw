using System;

public static class UserInput
{
    public static string GetString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int GetInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    public static double GetDouble(string prompt)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
