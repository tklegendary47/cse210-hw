public class Journal{

    public string _entry = "";
    List<string> _entryList = new List<string>();

    
    public void SaveEntries(string _entry,string prompt){
        var todayDate = DateTime.Today;
        string strToday = todayDate.ToString("MM/dd/yyyy");
        _entryList.Add($"Date: {strToday} - Prompt: {prompt} My answer: {_entry}");
    }

    public void DisplayEntries(){
        foreach(string i in _entryList){
            Console.WriteLine(i);
            
        }
    }

    public void SaveToFile(string filename){
        string path = $"{filename}";
        using (StreamWriter sw = File.CreateText(path)){
            foreach(string l in _entryList){
                sw.WriteLine(l);
            }
        }  
        }
    public void LoadFile(string filename){
        string theFile = $"./prove/Develop02/{filename}";
        string[] lines  = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines){
            Console.WriteLine("\t" + line);
        }
    }
    
}