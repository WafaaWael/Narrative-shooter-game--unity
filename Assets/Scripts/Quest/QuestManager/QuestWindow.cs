using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject goalPrefab;
    [SerializeField] private Transform goalsContents;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Initialize(Quest quest)
    {
        titleText.text = quest.Information.Name;
        descriptionText.text = quest.Information.Description;
        foreach (var goal in quest.Goals)
        {
            GameObject goalObj = Instantiate(goalPrefab, goalsContents);
            goalObj.transform.Find("Text").GetComponent<TextMeshProUGUI>().text=goal.GetDescription();

            GameObject countObj = goalObj.transform.Find("Count").gameObject;
            GameObject skiObj = goalObj.transform.Find("Skip").gameObject;
            if (goal.Completed)
            {
                countObj.SetActive(false);
                skiObj.SetActive(false);
                goalObj.transform.Find("Done").gameObject.SetActive(true);
            }
            else
            {
                countObj.GetComponent<TextMeshProUGUI>().text = goal.CurrentAmount+"/"+goal.RequiredAmount;
                skiObj.GetComponent<Button>().onClick.AddListener(delegate

                {
                    countObj.SetActive(false);
                    skiObj.SetActive(false);
                    goalObj.transform.Find("Done").gameObject.SetActive(true);
                });
            }
            xpText.text = quest.Reward.xp.ToString();
            scoreText.text=quest.Reward.Score.ToString();
        }
    }

}