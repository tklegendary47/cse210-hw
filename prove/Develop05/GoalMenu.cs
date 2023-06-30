class GoalMenu
{

    public void StartNewGoalMenu()
    {
        bool isValidChoice = false;

        while (!isValidChoice)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine());

                    Goals.numberOfGoals += 1;
                    SingleGoal singleGoal = new SingleGoal(false, name, description, points);

                    Goals.goalsBeingCreated.Add(singleGoal);

                    Console.WriteLine("You have " + Goals.totalPoints + " points");
                    Console.WriteLine(" ");

                    break;
                case "2":
                    
                    Console.Write("What is the name of your goal? ");
                    name = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this goal? ");
                    points = int.Parse(Console.ReadLine());

                    
                    Goals.numberOfGoals += 1;
                    EternalGoals eternalGoals = new EternalGoals(false, name, description, points);
                    
                    Goals.goalsBeingCreated.Add(eternalGoals);

                    Console.WriteLine("You have " + Goals.totalPoints + " points");

                    Goals.PrintingList();

                    break;
                case "3":
    	            Console.Write("What is the name of your goal? ");
                    name = Console.ReadLine();

                    Console.Write("What is a short description of it? ");
                    description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this goal? ");
                    points = int.Parse(Console.ReadLine());

                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int times = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int extraPoints = int.Parse(Console.ReadLine());

                    Goals.numberOfGoals += 1;
                    ChecklistGoals checklistGoals = new ChecklistGoals(name, description, points, times, extraPoints);
                    
                    Goals.goalsBeingCreated.Add(checklistGoals);
                    Console.WriteLine("You have " + Goals.totalPoints + " points");

                    break;
            }
            isValidChoice = true;
        } 
    }
}
