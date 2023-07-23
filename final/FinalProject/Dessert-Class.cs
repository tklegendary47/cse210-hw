public class Dessert : Recipe
{
    private int _ovenTemperature;

    public Dessert(string name, List<string> ingredients, string instructions, int ovenTemperature)
        : base(name, ingredients, instructions)
    {
        _ovenTemperature = ovenTemperature;
    }

    public int OvenTemperature
    {
        get { return _ovenTemperature; }
        set { _ovenTemperature = value; }
    }

    public override string GetRecipeType()
    {
        return "Dessert";
    }
}
