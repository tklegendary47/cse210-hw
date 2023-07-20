using System.Collections.Generic;

public class Vegetarian : Recipe
{
    public bool IsVegan { get; set; }

    public Vegetarian(string name, List<string> ingredients, string instructions, bool isVegan)
        : base(name, ingredients, instructions)
    {
        IsVegan = isVegan;
    }

    public override string GetRecipeType()
    {
        return "Vegetarian";
    }
}
