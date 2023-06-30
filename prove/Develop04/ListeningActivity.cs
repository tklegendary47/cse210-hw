class ListeningActivity: Activity{

    private string _randomPhrase;
    public ListeningActivity(string name, string description, string duration, string message): base(name, description, duration, message)
    {
        _randomPhrase = SelectRandomPhrase();
    }

    List<string> phrases = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public string SelectRandomPhrase()
    {
        Random random = new Random();
        int index = random.Next(phrases.Count);
        return phrases[index];
    }

    public void StartListeningActivity(){
        Console.Clear();
        Console.WriteLine("Get ready...");
        BreathingActivity breathingActivity = new BreathingActivity("", "", "", "");
        breathingActivity.slashInCircling(3);
        Console.WriteLine(" ");
        Console.WriteLine("List as meny responses you can to the following prompt:");
        Console.WriteLine("--- " + _randomPhrase + " ---");
        Console.WriteLine(" "); 
        File.AppendAllText("record.txt", _randomPhrase + Environment.NewLine);
        Console.Write("You may begin in: ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i != 1)
            {
                Console.Write("\b \b");
            }
        }
        Console.WriteLine(" "); 

        DateTime startTime = DateTime.Now;
        TimeSpan duration = TimeSpan.FromSeconds(int.Parse(base.GetDuration()));

        List<String> userResponses = new List<string>();

        
        while (DateTime.Now - startTime < duration)
        {
            Console.Write("> ");
            string userInput = Console.ReadLine();
            Console.WriteLine(" ");
            userResponses.Add(userInput);


        }
        File.AppendAllLines("record.txt", userResponses);
    }

}

