using System;
using System.Collections.Generic;
using System.Linq;

public class Menu
{
    private List<Recipe> recipes;

    public Menu()
    {
        recipes = new List<Recipe>();
    }

    public void AddRecipe()
    {
        Console.WriteLine("Enter the recipe name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the recipe type (Entree, Dessert, Vegetarian):");
        string recipeType = Console.ReadLine();
        List<string> ingredients = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter an ingredient (or 'done' to finish):");
            string ingredient = Console.ReadLine();
            if (ingredient.ToLower() == "done")
            {
                break;
            }
            ingredients.Add(ingredient);
        }
        Console.WriteLine("Enter the recipe instructions:");
        string instructions = Console.ReadLine();
        Recipe recipe;
        switch (recipeType.ToLower())
        {
            case "entree":
                Console.WriteLine("Enter the main ingredient:");
                string mainIngredient = Console.ReadLine();
                recipe = new Entree(name, ingredients, instructions, mainIngredient);
                break;
            case "dessert":
                Console.WriteLine("Enter the oven temperature:");
                int ovenTemperature = int.Parse(Console.ReadLine());
                recipe = new Dessert(name, ingredients, instructions, ovenTemperature);
                break;
            case "vegetarian":
                Console.WriteLine("Is this recipe vegan? (yes or no):");
                bool isVegan = Console.ReadLine().ToLower() == "yes";
                recipe = new Vegetarian(name, ingredients, instructions, isVegan);
                break;
            default:
                Console.WriteLine("Invalid recipe type.");
                return;
        }
        recipes.Add(recipe);
        Console.WriteLine($"Recipe '{recipe.Name}' has been added.");
    }

    public void ViewRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        Console.WriteLine("Recipes:");
        foreach (Recipe recipe in recipes)
        {
            Console.WriteLine($"{recipe.Name} ({recipe.GetRecipeType()})");
        }
    }

    public void EditRecipe()
    {
        Console.WriteLine("Enter the name of the recipe to edit:");
        string name = Console.ReadLine();
        Recipe recipe = recipes.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
        if (recipe == null)
        {
            Console.WriteLine($"Recipe '{name}' not found.");
            return;
        }
        Console.WriteLine($"Editing recipe '{recipe.Name}'. Press enter to keep current value.");
        Console.WriteLine($"Current type: {recipe.GetRecipeType()}");
        Console.WriteLine("Enter new type (Entree, Dessert, Vegetarian):");
        string recipeType = Console.ReadLine();
        if (!string.IsNullOrEmpty(recipeType))
        {
            switch (recipeType.ToLower())
            {
                case "entree":
                    Console.WriteLine($"Current main ingredient: {((Entree)recipe).MainIngredient}");
                    Console.WriteLine("Enter new main ingredient:");
                    string mainIngredient = Console.ReadLine();
                    if (!string.IsNullOrEmpty(mainIngredient))
                    {
                        ((Entree)recipe).MainIngredient = mainIngredient;
                    }
                    break;
                case "dessert":
                    Console.WriteLine($"Current oven temperature: {((Dessert)recipe).OvenTemperature}");
                    Console.WriteLine("Enter new oven temperature:");
                    string ovenTemperatureString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ovenTemperatureString))
                    {
                        int ovenTemperature = int.Parse(ovenTemperatureString);
                        ((Dessert)recipe).OvenTemperature = ovenTemperature;
                    }
                    break;
                case "vegetarian":
                    Console.WriteLine($"Current vegan: {((Vegetarian)recipe).IsVegan}");
                    Console.WriteLine("Is this recipe vegan? (yes or no):");
                    string isVeganString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(isVeganString))
                    {
                        bool isVegan = isVeganString.ToLower() == "yes";
                        ((Vegetarian)recipe).IsVegan = isVegan;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid recipe type.");
                    return;
            }
            Console.WriteLine($"Recipe type updated to {recipeType}.");
        }
        List<string> ingredients = recipe.Ingredients;
        while (true)
        {
            Console.WriteLine($"Current ingredients: {string.Join(", ", ingredients)}");
            Console.WriteLine("Enter an ingredient to add or remove (or 'done' to finish):");
            string ingredient = Console.ReadLine();
            if (ingredient.ToLower() == "done")
            {
                break;
            }
            if (ingredients.Contains(ingredient))
            {
                ingredients.Remove(ingredient);
                Console.WriteLine($"Removed ingredient '{ingredient}'.");
            }
            else
            {
                ingredients.Add(ingredient);
                Console.WriteLine($"Added ingredient '{ingredient}'.");
            }
        }
        recipe.Ingredients = ingredients;
        Console.WriteLine("Enter new instructions:");
        string instructions = Console.ReadLine();
        if (!string.IsNullOrEmpty(instructions))
        {
            recipe.Instructions = instructions;
            Console.WriteLine("Instructions updated.");
        }
    }

    public void SearchRecipeOnline()
    {
        Console.WriteLine("Enter a search term:");
        string searchTerm = Console.ReadLine();
        // Code to search for recipes online
    }

    public void GenerateShoppingList()
    {
        List<string> shoppingList = new List<string>();
        foreach (Recipe recipe in recipes)
        {
            foreach (string ingredient in recipe.Ingredients)
            {
                if (!shoppingList.Contains(ingredient))
                {
                    shoppingList.Add(ingredient);
                }
            }
        }
        if (shoppingList.Count == 0)
        {
            Console.WriteLine("No ingredients found.");
            return;
        }
        shoppingList.Sort();
        Console.WriteLine("Shopping List:");
        foreach (string ingredient in shoppingList)
        {
            Console.WriteLine(ingredient);
        }
    }

    public void PlanMeals()
    {
        // Code to plan meals for the week
    }
}
