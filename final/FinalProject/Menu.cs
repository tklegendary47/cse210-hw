using System;
using System.Collections.Generic;

class Menu
{
    private List<Recipe> _recipes = new List<Recipe>();

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
        _recipes.Add(recipe);
        Console.WriteLine($"Recipe '{recipe.Name}' has been added successfully!.");
    }
    public void ViewRecipes()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }

        for (int i = 0; i < _recipes.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_recipes[i].Name} ({_recipes[i].GetRecipeType()})");
        }
    }

    public void EditRecipe()
    {
        Console.WriteLine("Enter the number of the recipe you want to edit:");
        ViewRecipes();
        int recipeNum = int.Parse(Console.ReadLine());

        Recipe recipe = _recipes[recipeNum - 1];

        Console.WriteLine($"Editing recipe '{recipe.Name}' ({recipe.GetRecipeType()})");

        Console.WriteLine("Enter new recipe name (leave blank to keep current name):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            recipe.Name = newName;
            Console.WriteLine("Recipe name updated successfully!");
        }

        if (recipe is Dessert)
        {
            Dessert dessert = (Dessert)recipe;

            Console.WriteLine("Enter new oven temperature (leave blank to keep current temperature):");
            string newTempInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTempInput))
            {
                dessert.OvenTemperature = int.Parse(newTempInput);
                Console.WriteLine("Oven temperature updated successfully!");
            }
        }
        else if (recipe is Entree)
        {
            Entree entree = (Entree)recipe;

            Console.WriteLine("Enter new main ingredient (leave blank to keep current ingredient):");
            string newIngredient = Console.ReadLine();
            if (!string.IsNullOrEmpty(newIngredient))
            {
                entree.MainIngredient = newIngredient;
                Console.WriteLine("Main ingredient updated successfully!");
            }
        }

        Console.WriteLine($"Recipe '{recipe.Name}' updated successfully!");
    }

    public void searchRecipeOnline()
    {
        // TODO: Implement search recipe online
    }

    public void GenerateShoppingList()
    {
        // TODO: Implement generate shopping list
    }

    public void PlanMeals()
    {
        Console.Write("Enter the number of days you want to plan meals for: ");
        int numDays = int.Parse(Console.ReadLine());

        Dictionary<string, List<Recipe>> mealPlan = new Dictionary<string, List<Recipe>>()
        {
            {"Breakfast", new List<Recipe>()},
            {"Lunch", new List<Recipe>()},
            {"Dinner", new List<Recipe>()}
        };

        for (int i = 0; i < numDays; i++)
        {
            Console.WriteLine($"Day {i+1}:");

            foreach (string mealType in mealPlan.Keys)
            {
                Console.WriteLine($"{mealType}:");

                if (_recipes.Count == 0)
                {
                    Console.WriteLine("No recipes found.");
                    return;
                }

                ViewRecipes();

                Console.Write($"Select a {mealType} recipe by number: ");
                int recipeNum = int.Parse(Console.ReadLine());

                Recipe selectedRecipe = _recipes[recipeNum - 1];
                mealPlan[mealType].Add(selectedRecipe);
            }
        }

        Console.WriteLine("Meal Plan:");
        foreach (string mealType in mealPlan.Keys)
        {
            Console.WriteLine($"{mealType}:");
            foreach (Recipe recipe in mealPlan[mealType])
            {
                Console.WriteLine(recipe.Name);
            }
            Console.WriteLine();
        }
    }

    private Dessert CreateDessert()
    {
        Console.WriteLine("Enter oven temperature:");
        int ovenTemp = int.Parse(Console.ReadLine());

        List<string> ingredients = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter an ingredient (or 'done' to finish):");
            string ingredient = Console.ReadLine();
            if (ingredient == "done")
            {
                break;
            }
            ingredients.Add(ingredient);
        }

        Console.WriteLine("Enter instructions:");
        string instructions = Console.ReadLine();

        return new Dessert("", ingredients, instructions, ovenTemp);
    }

    private Entree CreateEntree()
    {
        Console.WriteLine("Enter main ingredient:");
        string mainIngredient = Console.ReadLine();

        List<string> ingredients = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter an ingredient (or 'done' to finish):");
            string ingredient = Console.ReadLine();
            if (ingredient == "done")
            {
                break;
            }
            ingredients.Add(ingredient);
        }

        Console.WriteLine("Enter instructions:");
        string instructions = Console.ReadLine();

        return new Entree("", ingredients, instructions, mainIngredient);
    }
 public void RemoveRecipe()
    {
        Console.WriteLine("Enter the name of the recipe you want to remove:");
        string recipeName = Console.ReadLine();
        Recipe recipeToRemove = null;
        foreach (Recipe recipe in _recipes)
        {
            if (recipe.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase))
            {
                recipeToRemove = recipe;
                break;
            }
        }
        if (recipeToRemove != null)
        {
            _recipes.Remove(recipeToRemove);
            Console.WriteLine($"Recipe '{recipeToRemove.Name}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Recipe '{recipeName}' not found.");
        }
    }

 public void SearchRecipes()
    {
        if (_recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        Console.WriteLine("Enter a search query:");
        string query = Console.ReadLine();
        List<Recipe> searchResults = RecipeSearch.Search(_recipes, query);
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


}

