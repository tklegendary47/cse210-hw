class ChecklistGoals: Goals{

    private Boolean _did;
    private string _name;
    private string _description;
    private int _points;
    private int _times;
    private int _extraPoints;
    private int _timesDid = 0;

    public ChecklistGoals(string name, string description, int points, int times, int extraPoints){
        id = Goals.numberOfGoals;
        _did = false;
        _name = name;
        _description = description;
        _points = points;
        _times = times;
        _extraPoints = extraPoints;
        _timesDid = 0;
    }
public Boolean GetDid(){
        return _did;
    }
    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints(){
        return _points;
    }

    public int GetTimes(){
        return _times;
    }

    public int GetExtraPoints(){
        return _extraPoints;
    }

    public int GetTimesDid(){
        return _timesDid;
    }

    public void SetTimesDid(int timesDid){
        _timesDid = timesDid;
    }

}