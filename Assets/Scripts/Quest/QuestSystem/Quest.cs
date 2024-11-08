using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

[CreateAssetMenu(menuName = "Scriptables/Quest/Quest")]

public class Quest : ScriptableObject
{
    [System.Serializable]
    public struct info
    {
        public string Name;
        public Sprite Icone;
        public string Description;
    }
    
    [Header("info")]public info Information;
   
    [System.Serializable]
    public struct state
    {
        public int Score;
        public int xp;
    }
    [Header("Reward")] public state Reward=new state { Score = 10, xp = 10 };
    [System.Serializable]
    public struct questGoal
    {
        public QuestGoal goal;

    }
    [Header("Goal")] public state Goal ;
    public List<QuestGoal> Goals;
    public QuestEvent QuestCompleted;
    public bool completed = false;


    public virtual void Intialize()
    {
        completed = false;
        QuestCompleted = new QuestEvent();
        foreach (var goal in Goals)
        {
            goal.Intialize();
            goal.GoaleCompleted.AddListener(delegate { CheckGoals(); });
        }
    }


    public bool CheckGoals()
    {
        completed = Goals.All(g => g.Completed);
        if(completed )
        {

            QuestCompleted?.Invoke(this);
           // QuestCompleted.RemoveAllListeners();
            return true;
        }
        else
        {
            return false;
        }
    }
}
