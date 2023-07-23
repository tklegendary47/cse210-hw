public class MealPlanner
{
    private IEnumerable<Recipe> _recipeList;
    private Dictionary<DayOfWeek, Recipe> _mealPlan;

    public MealPlanner(IEnumerable<Recipe> recipeList)
    {
        _recipeList = recipeList;
        _mealPlan = new Dictionary<DayOfWeek, Recipe>();
    }

    public void PlanMeal(DayOfWeek day)
    {
        Console.WriteLine($"Enter recipe name for {day}:");
        string recipeName = UserInput.GetString("> ");
        Recipe recipe = _recipeList.FirstOrDefault(r => r.Name == recipeName);
        if (recipe != null)
        {
            if (_mealPlan.ContainsKey(day))
            {
                Console.WriteLine($"Replace {_mealPlan[day].Name} with {recipe.Name} for {day}? (Y/N)");
                string answer = UserInput.GetString("> ").ToLower();
                if (answer == "y")
                {
                    _mealPlan[day] = recipe;
                    Console.WriteLine($"{recipe.Name} added to {day} meal plan.");
                }
                else if (answer == "n")
                {
                    Console.WriteLine("Meal plan not updated.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Meal plan not updated.");
                }
            }
            else
            {
                _mealPlan.Add(day, recipe);
                Console.WriteLine($"{recipe.Name} added to {day} meal plan.");
            }
        }
        else
        {
            Console.WriteLine("Recipe not found. Meal plan not updated.");
        }
    }

    public void ViewMealPlan()
    {
        foreach (KeyValuePair<DayOfWeek, Recipe> entry in _mealPlan)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value.Name}");
        }
    }
}
