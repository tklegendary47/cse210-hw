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

    public void RemoveRecipe(Recipe recipe)
    {
        _recipes.Remove(recipe);
    }

    public List<string> GetRecipeNames()
    {
        return _recipes.Select(r => r.Name).ToList();
    }

    public IEnumerable<Recipe> Recipes
    {
        get { return _recipes; }
        set { _recipes = value.ToList(); }
    }
}
