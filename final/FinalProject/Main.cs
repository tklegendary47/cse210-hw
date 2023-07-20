using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        while (true)
        {
           Console.WriteLine("RECIPE MANAGER");
           Console.WriteLine("==============");

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add recipe");
            Console.WriteLine("2. View recipes");
            Console.WriteLine("3. View recipe details");
            Console.WriteLine("4. Search recipes");
            Console.WriteLine("5. Remove recipe");
            Console.WriteLine("6. Exit");
            Console.Write("Enter a menu option (1-6): ");
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
                    menu.ViewRecipeDetails();
                    break;
                case "4":
                    menu.SearchRecipes();
                    break;
                case "5":
                    menu.RemoveRecipe();
                    break;
                case "6":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid menu option.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
