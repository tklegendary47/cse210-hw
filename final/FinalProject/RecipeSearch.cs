using System.Collections.Generic;

public static class RecipeSearch
{
    public static List<Recipe> Search(List<Recipe> recipes, string query)
    {
        List<Recipe> results = new List<Recipe>();
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Name.ToLower().Contains(query.ToLower()))
            {
                results.Add(recipe);
            }
        }
        return results;
    }
}
