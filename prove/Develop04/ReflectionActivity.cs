
class ReflectionActivity : Activity
{
    private string _randomPhrase;
    private string _questionsToReflect;

    public ReflectionActivity(string name, string description, string duration, string message): base(name, description, duration, message)
    {
        _randomPhrase = SelectRandomPhrase();
        _questionsToReflect = SelectRandomQuestionsToReflect();
    }

    public string SelectRandomPhrase()
    {
        Random random = new Random();
        int index = random.Next(phrases.Count);
        return phrases[index];
    }

    List<string> phrases = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public string SelectRandomQuestionsToReflect()
    {
        Random random = new Random();
        int index = random.Next(questionsToReflect.Count);
        return questionsToReflect[index];
    }

    List<string> questionsToReflect = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void StartReflectionActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        BreathingActivity breathingActivity = new BreathingActivity("", "", "", "");
        breathingActivity.slashInCircling(3);
        Console.WriteLine(" ");
        Console.WriteLine("--- " + _randomPhrase + " ---");
        Console.WriteLine(" ");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadKey();
        Console.WriteLine("");
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
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
        Console.Clear();
        DateTime startTime = DateTime.Now;
        TimeSpan duration = TimeSpan.FromSeconds(int.Parse(base.GetDuration()));

        while (DateTime.Now - startTime < duration)
        {
            _questionsToReflect = SelectRandomQuestionsToReflect();
            Console.Write("> " + _questionsToReflect);
            breathingActivity.slashInCircling(10);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Well done!!!");
        Console.WriteLine(" ");
        int durationSeconds = (int)duration.TotalSeconds;
        Console.WriteLine("You have completed another " + durationSeconds + " seconds of the Reflecting Activity.");
        breathingActivity.slashInCircling(5);
    }

}