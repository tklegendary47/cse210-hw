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

    // Save the recipe to a text file
    string fileName = $"{name}.txt";
    using (StreamWriter writer = new StreamWriter(fileName))
    {
        writer.WriteLine($"Name: {name}");
        writer.WriteLine($"Type: {recipeType}");
        writer.WriteLine("Ingredients:");
        foreach (string ingredient in ingredients)
        {
            writer.WriteLine($"- {ingredient}");
        }
        writer.WriteLine("Instructions:");
        writer.WriteLine(instructions);
    }

    Console.WriteLine($"Recipe '{recipe.Name}' has been added successfully and saved to '{fileName}'!.");
}

   public void ViewRecipes()
{
    string[] files = Directory.GetFiles(".", "*.txt");
    if (files.Length == 0)
    {
        Console.WriteLine("No recipes found.");
        return;
    }

    for (int i = 0; i < files.Length; i++)
    {
        string fileName = Path.GetFileName(files[i]);
        using (StreamReader reader = new StreamReader(files[i]))
        {
            string name = reader.ReadLine().Split(':')[1].Trim();
            string type = reader.ReadLine().Split(':')[1].Trim();
            Console.WriteLine($"{i+1}. {name} ({type})");
        }
    }
}


   public void EditRecipe()
{
    Console.WriteLine("Enter the number of the recipe you want to edit:");
    ViewRecipes();
    int recipeNum = int.Parse(Console.ReadLine());

    string fileName = Path.GetFileName(Directory.GetFiles(".", "*.txt")[recipeNum-1]);
    using (StreamReader reader = new StreamReader(fileName))
    {
        string name = reader.ReadLine().Split(':')[1].Trim();
        string type = reader.ReadLine().Split(':')[1].Trim();
        List<string> ingredients = new List<string>();
        string line;
        while ((line = reader.ReadLine()) != null && line != "Instructions:")
        {
            if (line.StartsWith("-"))
            {
                ingredients.Add(line.Substring(2));
            }
        }
        string instructions = reader.ReadToEnd();

        Console.WriteLine($"Editing recipe '{name}' ({type})");

        Console.WriteLine("Enter the new recipe name:");
        string newName = Console.ReadLine();
        Console.WriteLine("Enter the new recipe type (Entree, Dessert, Vegetarian):");
        string newType = Console.ReadLine();
        List<string> newIngredients = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter a new ingredient (or 'done' to finish):");
            string ingredient = Console.ReadLine();
            if (ingredient.ToLower() == "done")
            {
                break;
            }
            newIngredients.Add(ingredient);
        }
        Console.WriteLine("Enter the new recipe instructions:");
        string newInstructions = Console.ReadLine();

        Recipe recipe;
        switch (newType.ToLower())
        {
            case "entree":
                Console.WriteLine("Enter the new main ingredient:");
                string mainIngredient = Console.ReadLine();
                recipe = new Entree(newName, newIngredients, newInstructions, mainIngredient);
                break;
            case "dessert":
                Console.WriteLine("Enter the new oven temperature:");
                int ovenTemperature = int.Parse(Console.ReadLine());
                recipe = new Dessert(newName, newIngredients, newInstructions, ovenTemperature);
                break;
            case "vegetarian":
                Console.WriteLine("Is this recipe vegan? (yes or no):");
                bool isVegan = Console.ReadLine().ToLower() == "yes";
                recipe = new Vegetarian(newName, newIngredients, newInstructions, isVegan);
                break;
            default:
                Console.WriteLine("Invalid recipe type.");
                return;
        }

        // Save the modified recipe to the text file
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Name: {newName}");
            writer.WriteLine($"Type: {newType}");
            writer.WriteLine("Ingredients:");
            foreach (string ingredient in newIngredients)
            {
                writer.WriteLine($"- {ingredient}");
            }
            writer.WriteLine("Instructions:");
            writer.WriteLine(newInstructions);
        }

        Console.WriteLine($"Recipe '{name}' has been updated to '{newName}' successfully and saved to '{fileName}'!.");
    }
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

private Vegetarian CreateVegetarian()
{
    Console.WriteLine("Enter recipe name:");
    string name = Console.ReadLine();

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

    Console.WriteLine("Is this recipe vegan? (yes or no):");
    bool isVegan = Console.ReadLine().ToLower() == "yes";

    return new Vegetarian(name, ingredients, instructions, isVegan);
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
    Console.WriteLine("Enter a search query:");
    string query = Console.ReadLine();

    List<Recipe> matchingRecipes = new List<Recipe>();
    foreach (string fileName in Directory.GetFiles(".", "*.txt"))
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string name = reader.ReadLine().Split(':')[1].Trim();
            List<string> ingredients = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null && line != "Instructions:")
            {
                if (line.StartsWith("-"))
                {
                    ingredients.Add(line.Substring(2));
                }
            }
            if (name.ToLower().Contains(query.ToLower()) || ingredients.Any(i => i.ToLower().Contains(query.ToLower())))
            {
                string type = reader.ReadLine().Split(':')[1].Trim();
                string instructions = reader.ReadToEnd();
                Recipe recipe;
                switch (type.ToLower())
                {
                    case "entree":
                        string mainIngredient = ingredients[0];
                        recipe = new Entree(name, ingredients.Skip(1).ToList(), instructions, mainIngredient);
                        break;
                    case "dessert":
                        int ovenTemperature = int.Parse(ingredients[0]);
                        recipe = new Dessert(name, ingredients.Skip(1).ToList(), instructions, ovenTemperature);
                        break;
                    case "vegetarian":
                        bool isVegan = ingredients[0].ToLower() == "true";
                        recipe = new Vegetarian(name, ingredients.Skip(1).ToList(), instructions, isVegan);
                        break;
                    default:
                        continue;
                }
                matchingRecipes.Add(recipe);
            }
        }
    }

    if (matchingRecipes.Count == 0)
    {
        Console.WriteLine($"No recipes found that contain '{query}'.");
    }
    else
    {
        Console.WriteLine($"Found {matchingRecipes.Count} recipes that contain '{query}':");
        foreach (Recipe recipe in matchingRecipes)
        {
            Console.WriteLine($"{recipe.Name} ({recipe.GetRecipeType()})");
        }
    }
}


}

