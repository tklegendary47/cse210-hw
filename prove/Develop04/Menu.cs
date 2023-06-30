class Menu
{
    public void MenuOptions()
    {
        bool isValidChoice = false;

        while (!isValidChoice)
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine(" 1. Start Breathing Activity");
            Console.WriteLine(" 2. Start Reflecting Activity");
            Console.WriteLine(" 3. Start Listening Activity");
            Console.WriteLine(" 4. Show the Record File");
            Console.WriteLine(" 5. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                 case "1":
                    Console.Clear();
                    string activityName = "Breathing Activity";
                    BreathingActivity breathingActivity = null;
                    Console.WriteLine("Welcome to the Breathing Activity");
                    Console.Write("How long, in seconds, would you like for your session? ");
                    string duration = Console.ReadLine();
                    breathingActivity = new BreathingActivity(activityName, "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration, "You have completed another " + duration + " seconds of the " + activityName);
                    breathingActivity.StartBreathing();
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    activityName = "Reflecting Activity";
                    ReflectionActivity reflectionActivity = null;
                    string message = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
                    Console.WriteLine("Welcome to the Reflecting Activity.");
                    Console.WriteLine();
                    Console.WriteLine(message);
                    Console.WriteLine();        
                    Console.Write("How long, in seconds, would you like for your session? ");
                    duration = Console.ReadLine();
                    reflectionActivity = new ReflectionActivity(activityName, message, duration, "You have completed another " + duration + " seconds of the ");
                    reflectionActivity.StartReflectionActivity();
                    break;
                case "3":
                    Console.Clear();  
                    activityName = "Listening Activity";
                    ListeningActivity listeningActivity = null;
                    Console.WriteLine("Welcome to the Listening Activity.");
                    message = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
                    Console.WriteLine();
                    Console.WriteLine(message);
                    Console.WriteLine();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    duration = Console.ReadLine();
                    listeningActivity = new ListeningActivity(activityName, message, duration, "You have completed another " + duration + " seconds of the ");
                    listeningActivity.StartListeningActivity();
                    break;
                case "4":
                    Console.Clear();
                    string[] lines = File.ReadAllLines("record.txt");
                    for (int i = 0; i < lines.Length; i++)
                        {
                            Console.WriteLine(lines[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();

                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    isValidChoice = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
