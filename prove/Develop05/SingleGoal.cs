using System;


class SingleGoal : Goals
{
    private string _name;
    private string _description;
    private int _points;
    private Boolean _did;
    public SingleGoal(Boolean did, string name, string description, int points)
    {
        _did = did;
        id = Goals.numberOfGoals;
        _name = name;
        _description = description;
        _points = points;
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

}