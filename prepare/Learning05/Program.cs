using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();
        Square square = new Square("Blue", 4);

        Rectangle rectangle = new Rectangle("Green", 2, 4);

        Circle circle = new Circle("red", 10);
   
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach(Shape shape in shapes){
            Console.WriteLine($"The area of the object is: " + shape.GetArea());
            Console.WriteLine($"The color of the object is: " + shape.GetColor());
        }

    }
}