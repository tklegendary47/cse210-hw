using System.Collections.Generic;

public abstract class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }

    public Recipe(string name, List<string> ingredients, string instructions)
    {
        Name = name;
        Ingredients = ingredients;
        Instructions = instructions;
    }

    public abstract string GetRecipeType();
}
