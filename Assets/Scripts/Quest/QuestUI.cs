using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI questTitle;
    [SerializeField] TextMeshProUGUI remItem;

    //[SerializeField] Quest quest;


    public void UpdateGoalUI(QuestGoal goal)
    {
        {
            Description.text = goal.Description;
            Title.text = goal.Name;
        }
    }
    public void UpdateQuestUI(Quest quest)
    {
      //  this.quest = quest;
        questTitle.text = quest.Information.Name;
        //quest.Intialize();
    }
    public void updateRem(QuestGoal goal)
    {
        remItem.text = $"{goal.CurrentAmount}/{goal.RequiredAmount}";
    }
}
