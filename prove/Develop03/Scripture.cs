using System;
using System.Collections.Generic;

class Scripture{

    private Reference _reference;
    private List<Word> _words; 
    private List<Word> _hiddenWords;

    public bool AllWordsHidden{
        get{
            return _hiddenWords.Count == _words.Count;
        }
    }

    public Scripture(string textReference, string textScripture){

        _reference = new Reference(textReference);
        _words = SplitWords(textScripture);
        _hiddenWords = new List<Word>();
    }

    public void Display(){
        _reference.Display();
        foreach(Word word in _words){
            if (_hiddenWords.Contains(word)){
                Console.Write("___ ");
            }
            else{
                Console.Write(word._text + " ");
            }
        }
        Console.WriteLine();
    }

    public void DisplayHidden(){
        _reference.Display();
        foreach(Word word in _words){
            Console.Write("___ ");
        }
        Console.WriteLine();
    }

    public void HideRandomWord(){
        if (AllWordsHidden){
            return;
        }
        Random random  = new Random();
        int randomIndex;

        do {
            randomIndex = random.Next(_words.Count);
        } while (_hiddenWords.Contains(_words[randomIndex]));
        _hiddenWords.Add(_words[randomIndex]);
    }


    private List<Word> SplitWords(string text){
        
        string[] stringWords = text.Split(' ');
        List<Word> wordList = new List<Word>();

        foreach(string stringWord in stringWords){
            Word word = new Word(stringWord);
            wordList.Add(word);
        }
        return wordList;
    }
}