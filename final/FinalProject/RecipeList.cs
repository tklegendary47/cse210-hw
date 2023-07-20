public class RecipeList
{
    private List<Recipe> _recipes;

    public RecipeList()
    {
        _recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        _recipes.Add(recipe);
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _recipes.Remove(recipe);
    }

    public List<string> GetRecipeNames()
    {
        return _recipes.Select(r => r.Name).ToList();
    }

    public Recipe GetRecipe(int index)
    {
        return _recipes[index];
    }
}
