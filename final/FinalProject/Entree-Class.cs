using System.Collections.Generic;

public class Entree : Recipe
{
    public string MainIngredient { get; set; }

    public Entree(string name, List<string> ingredients, string instructions, string mainIngredient)
        : base(name, ingredients, instructions)
    {
        MainIngredient = mainIngredient;
    }

    public override string GetRecipeType()
    {
        return "Entree";
    }
}
