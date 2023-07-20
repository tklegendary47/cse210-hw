using System;
using System.Collections.Generic;

public class RecipeManager
{
    private List<Recipe> _recipes;

    public RecipeManager()
    {
        _recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
        Console.WriteLine("Recipe added successfully.");
    }

    public void RemoveRecipe(Recipe recipe)
    {
        if (_recipes.Remove(recipe))
        {
            Console.WriteLine("Recipe removed successfully.");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }

    public void EditRecipe(Recipe recipe)
    {
        int index = _recipes.IndexOf(recipe);
        if (index != -1)
        {
            Console.WriteLine("Enter new recipe name:");
            string name = UserInput.GetString("> ");
            Console.WriteLine("Enter new recipe ingredients (comma-separated):");
            string[] ingredientsArray = UserInput.GetString("> ").Split(',');
            List<string> ingredients = new List<string>();
            foreach (string ingredient in ingredientsArray)
            {
                ingredients.Add(ingredient.Trim());
            }
            Console.WriteLine("Enter new recipe instructions:");
            string instructions = UserInput.GetString("> ");
            _recipes[index] = recipe switch
            {
                Entree => new Entree(name, ingredients, instructions, ((Entree)recipe).MainIngredient),
                Dessert => new Dessert(name, ingredients, instructions, ((Dessert)recipe).OvenTemperature),
                Vegetarian => new Vegetarian(name, ingredients, instructions, ((Vegetarian)recipe).IsVegan),
                _ => throw new InvalidOperationException("Invalid recipe type.")
            };
            Console.WriteLine("Recipe edited successfully.");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }

    public void ViewRecipes()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
        }
        else
        {
            Console.WriteLine($"{_recipes.Count} recipes found:");
            foreach (Recipe recipe in _recipes)
            {
                Console.WriteLine($"{recipe.Name} ({recipe.GetRecipeType()})");
            }
        }
    }

    public void SearchRecipes()
    {
        Console.WriteLine("Enter search query:");
        string query = UserInput.GetString("> ");
        List<Recipe> results = RecipeSearch.Search(_recipes, query);
        if (results.Count == 0)
        {
            Console.WriteLine("No recipes found.");
        }
        else
        {
            Console.WriteLine($"{results.Count} recipes found:");
            foreach (Recipe recipe in results)
            {
                Console.WriteLine($"{recipe.Name} ({recipe.GetRecipeType()})");
            }
        }
    }

    public void GenerateShoppingList(List<Recipe> recipes)
    {
        Dictionary<string, int> shoppingList = new Dictionary<string, int>();
        foreach (Recipe recipe in recipes)
        {
            foreach (string ingredient in recipe.Ingredients)
            {
                if (shoppingList.ContainsKey(ingredient))
                {
                    shoppingList[ingredient]++;
                }
                else
                {
                    shoppingList[ingredient] = 1;
                }
            }
        }
        Console.WriteLine("Shopping list:");
        foreach (KeyValuePair<string, int> item in shoppingList)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    public void PlanMeals()
    {
        Console.WriteLine("Enter number of days to plan meals for:");
        int numDays = UserInput.GetInt("> ");
        List<Recipe> mealPlan = new List<Recipe>();
        for (int i = 0; i < numDays; i++)
        {
            Console.WriteLine($"Day {i + 1}:");
            Console.WriteLine("Enter recipe name:");
            string recipeName = UserInput.GetString("> ");
            Recipe recipe = _recipes.Find(r => r.Name.ToLower() == recipeName.ToLower());
            if (recipe != null)
            {
                mealPlan.Add(recipe);
                Console.WriteLine("Recipe added to meal plan.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
                i--;
            }
        }
        GenerateShoppingList(mealPlan);
    }
}
