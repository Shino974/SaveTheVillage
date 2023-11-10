using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroCharactereCollision : MonoBehaviour
{
    Collider2D otherObj;
    public GameObject dialWorldCanvas;
    public TMP_Text dialWorldTxt;
    
    public IncreaseStats iStats;
    
    public GameObject dialCanvas;
    public Text dialCanvasTxt;

    public QuestGiver[] quests;

    public GameObject camFight;

    private void Start()
    {
        iStats = gameObject.GetComponent<IncreaseStats>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && otherObj != null)
        {
            if (otherObj.gameObject.CompareTag("sign"))
                ShowWorldDial();
            if (otherObj.gameObject.CompareTag("flower"))
            {
                otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                otherObj.gameObject.SetActive(false);
                otherObj = null;
                quests[0].quest.IncrementCount();
            }
        }
    }

    // Collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("sign"))
        {
            otherObj = other;
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(true);
            dialWorldTxt.SetText(sb.signText);
        }
        if (other.gameObject.CompareTag("flower"))
        {
            otherObj = other;
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("exit"))
        {
            string point = other.gameObject.GetComponent<ExitBehaviour>().teleportPoint;
            PlayerPrefs.SetString("Point", point);
            SceneManager.LoadScene(other.gameObject.name);
        }
        if (other.gameObject.CompareTag("mob") && !camFight.activeInHierarchy)
        {
            camFight.SetActive(true);
            InitialiseFight initF = camFight.GetComponent<InitialiseFight>();
            initF.hfs.baseEnemy = other.gameObject;
            initF.InitFight();
        }
        if (other.gameObject.CompareTag("boss"))
        {
            camFight.SetActive(true);
            InitialiseFight initF = camFight.GetComponent<InitialiseFight>();
            initF.hfs.baseEnemy = other.gameObject;
            initF.InitFightBoss();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("sign"))
        {
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(false);
            otherObj = null;
            Invoke("HideDialWorlPanel", 1);
        }
        if (other.gameObject.CompareTag("flower"))
        {
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(false);
            otherObj = null;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("guard"))
        {
            ShowDialCanvasTxt(other.gameObject.GetComponent<PnjSimpleDial>().simpleDial);
        }
        if (other.gameObject.CompareTag("pnj"))
        {
            ShowDialCanvasTxt(other.gameObject.GetComponent<PnjSimpleDial>().simpleDial);
        }
        if (other.gameObject.CompareTag("futureMe"))
        {
            ShowDialCanvasTxt(other.gameObject.GetComponent<PnjSimpleDial>().simpleDial);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("guard"))
        {
            HideDialCanvas();
        }
        if (other.gameObject.CompareTag("pnj"))
        {
            HideDialCanvas();
        }
        if (other.gameObject.CompareTag("futureMe"))
        {
            HideDialCanvas();
        }
    }

    public void HideDialWorlPanel()
    {
        dialWorldCanvas.SetActive(false);
    }

    public void ShowWorldDial()
    {
        SignBehaviour sb = otherObj.gameObject.GetComponent<SignBehaviour>();
        sb.ui.SetActive(false);
        dialWorldCanvas.SetActive(true);
        dialWorldTxt.SetText(sb.signText);
    }

    public void ShowDialCanvasTxt(string msg)
    {
        dialCanvas.SetActive(true);
        dialCanvasTxt.text = msg;
    }

    public void HideDialCanvas()
    {
        dialCanvas.SetActive(false);
    }
}
