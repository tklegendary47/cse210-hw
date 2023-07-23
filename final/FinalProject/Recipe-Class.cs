public abstract class Recipe
{
    private string _name;
    private List<string> _ingredients;
    private string _instructions;

    public Recipe(string name, List<string> ingredients, string instructions)
    {
        _name = name;
        _ingredients = ingredients;
        _instructions = instructions;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public List<string> Ingredients
    {
        get { return _ingredients; }
        set { _ingredients = value; }
    }

    public string Instructions
    {
        get { return _instructions; }
        set { _instructions = value; }
    }

    public abstract string GetRecipeType();
}
