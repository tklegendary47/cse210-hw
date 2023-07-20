using System;
using System.Collections.Generic;

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

    public void ViewRecipeDetails()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        Console.WriteLine("Enter the name of the recipe:");
        string recipeName = Console.ReadLine();
        Recipe selectedRecipe = null;
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase))
            {
                selectedRecipe = recipe;
                break;
            }
        }
        if (selectedRecipe != null)
        {
            Console.WriteLine($"Name: {selectedRecipe.Name}");
            Console.WriteLine($"Type: {selectedRecipe.GetRecipeType()}");
            Console.WriteLine("Ingredients:");
            foreach (string ingredient in selectedRecipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine($"Instructions: {selectedRecipe.Instructions}");
        }
        else
        {
            Console.WriteLine($"Recipe '{recipeName}' not found.");
        }
    }

    public void SearchRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        Console.WriteLine("Enter a search query:");
        string query = Console.ReadLine();
        List<Recipe> searchResults = RecipeSearch.Search(recipes, query);
        if (searchResults.Count == 0)
        {
            Console.WriteLine("No results found.");
            return;
        }
        Console.WriteLine("Search results:");
        foreach (Recipe recipe in searchResults)
        {
            Console.WriteLine($"{recipe.Name} ({recipe.GetRecipeType()})");
        }
    }

    public void RemoveRecipe()
    {
        Console.WriteLine("Enter the name of the recipe you want to remove:");
        string recipeName = Console.ReadLine();
        Recipe recipeToRemove = null;
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase))
            {
                recipeToRemove = recipe;
                break;
            }
        }
        if (recipeToRemove != null)
        {
            recipes.Remove(recipeToRemove);
            Console.WriteLine($"Recipe '{recipeToRemove.Name}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Recipe '{recipeName}' not found.");
        }
    }
}
