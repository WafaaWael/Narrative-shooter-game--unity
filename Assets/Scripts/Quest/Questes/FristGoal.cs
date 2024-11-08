using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FristGoal : QuestGoal
{
    private void Awake()
    {
        Completed = false;
        CurrentAmount = 0;
    }
    public string door;
    public override string GetDescription()
    {
        return $"open  the  (door )";
    }
    public override void Intialize()
    {
        base.Intialize();
        EventManger.Instance.AddListener<DoorGameEvent>(OnBuilding);
    }
    private void OnBuilding(DoorGameEvent eveninfo)
    {
        if(eveninfo.Doornum==door) {
        CurrentAmount++;
            Evaluate();
        }
        
    }
}
