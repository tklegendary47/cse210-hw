using System;

class Reference{

    public string _text {get;}

    public Reference(string text){

        _text = text; 
    }

    public void Display(){

        Console.WriteLine(_text);
    }
}