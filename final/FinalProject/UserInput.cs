public static class UserInput
{
    public static string GetString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int GetInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }
}
