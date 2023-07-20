using System.Collections.Generic;

public class Dessert : Recipe
{
    public int OvenTemperature { get; set; }

    public Dessert(string name, List<string> ingredients, string instructions, int ovenTemperature)
        : base(name, ingredients, instructions)
    {
        OvenTemperature = ovenTemperature;
    }

    public override string GetRecipeType()
    {
        return "Dessert";
    }
}
