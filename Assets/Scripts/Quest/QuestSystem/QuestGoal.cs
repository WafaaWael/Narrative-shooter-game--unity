using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptables/Quest/QuestGoal")]
public abstract class QuestGoal : ScriptableObject
{
    public string Description;
    public int CurrentAmount { get; set; }
    public int RequiredAmount = 1;
    public bool Completed= false;
    public UnityEvent GoaleCompleted;
    public string Name;
  
    public virtual string GetDescription()
    {
        return Description;
    }

    public virtual void Intialize()
    {
        Completed = false;
        GoaleCompleted = new UnityEvent();
    }

    protected void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        GoaleCompleted.Invoke();
        GoaleCompleted.RemoveAllListeners();
    }
    public void SetCurrentAmoutn(int CurrentAmount)
    {
        this.CurrentAmount = CurrentAmount;
    }
    public void SetComplete(bool Completed)
    {
        this.Completed= Completed;
    }
}