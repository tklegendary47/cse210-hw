class Activity{
    private String _name;
    private String _description;
    private String _duration;
    private String _message;

    public Activity(string name, string description, string duration, string message){
        _name = name;
        _description = description;
        _duration = duration;
        _message = message;

    }
    public Activity(){

    }
    
    public string GetDuration()
    {
        return _duration;
    }

    public void SetDuration(string duration)
    {
        _duration = duration;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetMessage()
    {
        return _message;
    }
}