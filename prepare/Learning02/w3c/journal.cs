using System.IO;
using System.Collections.Generic;


public class Journal
{
    public List<string> _prompts = new List<string>()
    {"What was the best part of your day? ",
    "What is your favorite food? ",
    "What is something you learned these past few weeks? ",
    "What is something that motivates you to do your best every day? "};
    public List<Entry> _entries = new List<Entry>();

    public Journal()
    {

    }

    public void Write()
    {   
        Random rnd = new Random();
        int num = rnd.Next(_prompts.Count);

        string prompt = _prompts[num];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        Entry entry = new Entry();
        entry._dateTime = dateText;
        entry._prompt = prompt;
        entry._message = response;

        _entries.Add(entry);
    }

    public void DisplayIt()
    {
        foreach(Entry entry in  _entries)
        {
            entry.Display();
        }
    }

    public void Load()
    {
        Console.WriteLine("What is the filename? ");
        string file = Console.ReadLine();

        using (StreamReader sr = new StreamReader(file))
        {
            // Read the stream to a string, and write the string to the console
            string line = sr.ReadToEnd();
            Console.WriteLine(line);
        }
    }

    public void Save()
    {
        Console.WriteLine("to which file? ");
        string file = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"Date: {entry._dateTime} - {entry._prompt}");
                outputFile.WriteLine($"{entry._message}");
            }
        }
    } 
}