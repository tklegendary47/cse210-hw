public class Entree : Recipe
{
    private string _mainIngredient;

    public Entree(string name, List<string> ingredients, string instructions, string mainIngredient)
        : base(name, ingredients, instructions)
    {
        _mainIngredient = mainIngredient;
    }

    public string MainIngredient
    {
        get { return _mainIngredient; }
        set { _mainIngredient = value; }
    }

    public override string GetRecipeType()
    {
        return "Entree";
    }
}
