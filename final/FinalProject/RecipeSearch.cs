public static class RecipeSearch
{
    public static List<Recipe> Search(IEnumerable<Recipe> recipes, string query)
    {
        return recipes.Where(r => r.Name.Contains(query) || r.Ingredients.Any(i => i.Contains(query))).ToList();
    }
}
