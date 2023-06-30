class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, string duration, string message) : base(name, description, duration, message)
    {
    }

    public void StartBreathing()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        slashInCircling(3);
        Console.Clear();
        timing();
    }

    public void slashInCircling(int times)
    {
        for (int i = 0; i < times; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("—");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    public void breathIn()
    {
        Console.Write("Breathe in....");
        for (int i = 3; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b\b\b");
        }
        Console.Write("Breathe out....");
    }

    public void timing()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b\b\b");
        }
        breathIn();
    }
}
