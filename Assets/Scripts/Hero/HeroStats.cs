using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class HeroStats : MonoBehaviour
{
    public Text lvlTxt;
    public Text goldTxt;
    public Text xpTxt;
    
    public int vie;
    public int force;

    public int lvl;
    public int xp;
    public int gold;

    private int nextLevelXp = 20;

    private void Start()
    {
        vie = PlayerPrefs.GetInt("vie", 10);
        force = PlayerPrefs.GetInt("force", 3);
        lvl = PlayerPrefs.GetInt("level", 1);
        xp = PlayerPrefs.GetInt("xp", 0);
        gold = PlayerPrefs.GetInt("gold", 0);
        SetGUIVals();
    }

    public void LevelUp()
    {
        if (xp >= nextLevelXp)
        {
            xp -= nextLevelXp;   
            lvl++;
            LevelUp();
            int statePoints = PlayerPrefs.GetInt("statPoints", 0);
            PlayerPrefs.SetInt("statPoints", statePoints+ 5);
        }
    }
    
    public void SetGUIVals()
    {
        lvlTxt.text = "Level " + lvl;        
        goldTxt.text = "Gold: " + gold;
        xpTxt.text = "XP: " + xp + "/" + nextLevelXp;
        SaveHeroStats();
    }

    public void SaveHeroStats()
    {
        PlayerPrefs.SetInt("level", lvl);
        PlayerPrefs.SetInt("xp", xp);
        PlayerPrefs.SetInt("gold", gold);
    }
}
