using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject questPanel;
    public Text[] questInfos;

    public string completeQuestTxt;
    public int xp = 50;
    public int gold = 500;

    public GameObject[] toHideAfterQuestCompleted;
    public GameObject[] toShowAfterQuestCompleted;

    public string questName;

    public void HideObjAfterQuest()
    {
        foreach(GameObject go in toHideAfterQuestCompleted)
        {
            go.SetActive(false);
        }
    }
    public void ShowObjAfterQuest()
    {
        foreach (GameObject go in toShowAfterQuestCompleted)
        {
            go.SetActive(true);
        }
    }
}
