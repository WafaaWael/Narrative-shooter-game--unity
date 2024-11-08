using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManger : MonoBehaviour
{
    [SerializeField] private QuestUI UI;

    public void Build(string BuildingName)
    {
        EventManger.Instance.QueueEvent(evt: new DoorGameEvent(BuildingName));
    }

    private void OnQuestCompleted(Quest quest)
    {
        // questContent.GetChild(CurrentQuest.IndexOf(quest)).Find("Checkmark").gameObject.SetActive(true);
    }

    private void OnEnable()
    {
    }

    public void updateUI(Quest quest)
    {
        foreach (var goal in quest.Goals)
        {
            UI.UpdateQuestUI(quest);

            if (!quest.CheckGoals())
            {
                quest.Intialize();
                quest.QuestCompleted.AddListener(OnQuestCompleted);

                {
                    if (!goal.Completed)
                    {
                        UI.UpdateGoalUI(goal);
                    }
                }
            }
            else if (quest.CheckGoals())
            {
            }
        }
    }

    public void UpdateRem(QuestGoal goal)
    {
        if (goal.CurrentAmount < goal.RequiredAmount)
        {
            goal.CurrentAmount++;
            UI.updateRem(goal);
        }
        else
        {
            goal.Complete();
        }
    }

    public void StartGoal(QuestGoal goal)
    {
        goal.SetCurrentAmoutn(0);
        UI.updateRem(goal);
        goal.SetComplete(false);
    }
}