using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfQuestDone : MonoBehaviour
{
    public string questName;
    void Start()
    {
        if (PlayerPrefs.GetInt(questName, 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
