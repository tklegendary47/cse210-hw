public abstract class Shape{

    private String _color;

    public Shape(String color){
        _color = color;
    }

    public String GetColor(){
        return this._color;
    }

    public void SetColor(string color){
        _color = color;
    }

    public abstract double GetArea();

}