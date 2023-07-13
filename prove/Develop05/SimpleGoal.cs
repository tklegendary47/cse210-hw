using System;

public class SimpleGoal : Goal 
{
    private bool _IsComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _IsComplete = false;
    }

    public override void RecordEvent()
    {
        _IsComplete = true;


    }

    public override bool IsComplete()
    {
        return _IsComplete;
    }

    public override string GetStringRepresentation()
    {
        string representation = $"SimpleGoal:{base.GetName()},{base.GetDescription()},{base.GetPoints()},{_IsComplete}";

        return representation;
    }

  
}