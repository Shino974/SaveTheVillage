using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    public GameObject panelStats;
    public IncreaseStats increaseStats;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            increaseStats.RefreshStatsPoint();
            Time.timeScale = 0;
            panelStats.SetActive(true);
        }
    }

    public void SetTimeScale()
    {
        Time.timeScale = 1;
    }
}
