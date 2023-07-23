public class Vegetarian : Recipe
{
    private bool _isVegan;

    public Vegetarian(string name, List<string> ingredients, string instructions, bool isVegan)
        : base(name, ingredients, instructions)
    {
        _isVegan = isVegan;
    }

    public bool IsVegan
    {
        get { return _isVegan; }
        set { _isVegan = value; }
    }

    public override string GetRecipeType()
    {
        return "Vegetarian";
    }
}
