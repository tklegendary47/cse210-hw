public class Entry
{
    public string _dateTime;
    public string _prompt;
    public string _message;
    
    public void Display()
    {
        Console.WriteLine($"Date: {_dateTime} - {_prompt}");
        Console.WriteLine($"{_message}");
    }

}