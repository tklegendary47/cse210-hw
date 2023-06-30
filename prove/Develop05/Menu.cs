class Menu
{
    public void MenuOptions()
    {
        bool isValidChoice = false;
        while (!isValidChoice)
        {
            Console.WriteLine("");
            
            Goals.GettingPointsfile();
            Console.WriteLine("");
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GoalMenu creatingNewGoalMenu = new GoalMenu();
                    creatingNewGoalMenu.StartNewGoalMenu();
                    break;
                case "2":
                    if (Goals.goalsBeingCreated.Count ==  0){ 
                        Goals.PrintingSavedGoals();
                    }else{
                        Goals.PrintingList();
                        Goals.SlashInCircling(3);
                    }
                    break;
                case "3":
                    Goals.SaveGoalsToFile();
                    break;
                case "4":
                    Goals.LoadingGoals();
                    
                    break;
                case "5":

                    Goals.RecordingEvent();
                    break;
                case "6":
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