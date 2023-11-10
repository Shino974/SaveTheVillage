using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseStats : MonoBehaviour
{
    public int statsPoint = 10;

    public Text forceTxt;
    public Text vieTxt;

    private void Start()
    {
        SetTxt();
        RefreshStatsPoint();
    }

    public void RefreshStatsPoint()
    {
        statsPoint = PlayerPrefs.GetInt("statPoints", 10);
    }

    public void IncreaseSelectedStat(string name)
    {
        if (statsPoint > 0)
        {
            statsPoint--;
            PlayerPrefs.SetInt("statPoints", statsPoint);
            if (name == "force")
                PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name, 3) + 1);
            if (name == "vie")
                PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name, 10) + 1);
            SetTxt();
        }
    }

    public void SetTxt()
    {
        forceTxt.text = "Strength: " +  PlayerPrefs.GetInt("force", 3);
        vieTxt.text = "Life: " + PlayerPrefs.GetInt("vie", 10);
    }
}
