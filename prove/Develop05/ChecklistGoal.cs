using System;



public class ChecklistGoal : Goal 
{

    protected int  _amountCompleted;

    private int _target;

    private int _bonus;

    public ChecklistGoal(string name, string description, string points,int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }


    public override void RecordEvent()
    {
       _amountCompleted++;

       if (_target == _amountCompleted)
       {
        int totalPoints = GetPoints() + _bonus;
        SetPoints(totalPoints);
       }
       
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
           
            return true;
        
        } else

        {

        return false;
        }
    }

    public override string GetStringRepresentation()
    {
        string representation = $"ChecklistGoal:{base.GetName()},{base.GetDescription()},{base.GetPoints()},{_bonus},{_target},{_amountCompleted}";

        return representation;
    }

    public override string GetDetailsString()
    {
        return ($"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}");
    }

    public void SetAmount(int amount)
    {
        _amountCompleted = amount;
    }


}
