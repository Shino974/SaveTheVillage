using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject square;
    public GameObject btn;
    public GameObject txt;
    
    public void Btn_click()
    {
        txt.SetActive(false);
        square.SetActive(true);
        btn.SetActive(false);
    }

    public void Btnquit()
    {
        Application.Quit();
    }
}
