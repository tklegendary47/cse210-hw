using System;

class MainClass
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        while (true)
        {
           Console.WriteLine("Welcome to your RECIPE MANAGER '(^<>^)' ! ");
           Console.WriteLine("==============");


            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add recipe");
            Console.WriteLine("2. View recipes");
            Console.WriteLine("3. Edit recipe");
            Console.WriteLine("4. Search for recipe ");
            Console.WriteLine("5. Generate shopping list");
            Console.WriteLine("6. Plan meals");
            Console.WriteLine("0. Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    menu.AddRecipe();
                    break;
                case "2":
                    menu.ViewRecipes();
                    break;
                case "3":
                    menu.EditRecipe();
                    break;
                case "4":
                    menu.SearchRecipeOnline();
                    break;
                case "5":
                    menu.GenerateShoppingList();
                    break;
                case "6":
                    menu.PlanMeals();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
