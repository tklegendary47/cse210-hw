public class PromptGenerator{

    public string _prompt = "";
    public List<string> _prompts = new List<string>();

    public string GetRandomPrompt(){
        var random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}