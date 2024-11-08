using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGoal : QuestGoal
{
    public string goal;
    public override string GetDescription()
    {
        return  goal;
    }
    public override void Intialize()
    {
        base.Intialize();
        EventManger.Instance.AddListener<DoorGameEvent>(OnBuilding);
    }
    private void OnBuilding(DoorGameEvent eveninfo)
    {
        if (eveninfo.Doornum == goal)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
 
}
