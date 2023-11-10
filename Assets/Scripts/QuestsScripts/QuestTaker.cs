using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTaker : MonoBehaviour
{
    QuestGiver qg;
    HeroStats hs;

    private void Start()
    {
        hs = GetComponent<HeroStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("quest_giver"))
        {
            if (qg == null)
            {
                qg = other.gameObject.GetComponent<QuestGiver>();
                int isQuestDone = PlayerPrefs.GetInt(qg.questName, 0);
                if (!qg.quest.isActive && isQuestDone == 0)
                {
                    qg.questPanel.SetActive(true);
                    qg.questInfos[0].text = qg.quest.tittle;
                    qg.questInfos[1].text = qg.quest.description;
                    qg.questInfos[2].text = "XP :" + qg.quest.xp + " | Golg :" + qg.quest.gold;
                }
                else
                {
                    if (qg.quest.isComplete && qg.xp > 0)
                    {
                        qg.HideObjAfterQuest();
                        GetComponent<HeroCharactereCollision>().ShowDialCanvasTxt(qg.completeQuestTxt);
                        hs.xp += qg.xp;
                        hs.gold += qg.gold;
                        qg.xp = 0;
                        qg.gold = 0;
                        hs.LevelUp();
                        hs.SetGUIVals();
                        PlayerPrefs.SetInt(qg.questName, 1);
                    }
                }
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("quest_giver"))
        {
            qg.questPanel.SetActive(false);
            qg = null;
            GetComponent<HeroCharactereCollision>().HideDialCanvas();
        }
    }

    public void TakeQuest()
    {
        qg.quest.isActive = true;
        qg.questPanel.SetActive(false);
    }
}
