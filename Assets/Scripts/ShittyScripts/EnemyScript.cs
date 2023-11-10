using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public int vie;
    public int force;

    public GameObject barreVie;
    float scaleX;

    public GameObject hero;
    
    private int _vie;
    
    HeroFightScript hfs;

    public bool canFight = true;
    
    private void Start()
    {
        hfs = hero.GetComponent<HeroFightScript>(); 
        scaleX = barreVie.transform.localScale.x / vie;
    }

    public void setLifePoint()
    {
        barreVie.transform.localScale = new Vector3(scaleX - vie, 0.125f, 1);
    }
    
    public void AtkHero()
    {
        if (canFight)
        {
            iTween.MoveFrom(gameObject, hero.transform.position, 3);
            HeroStats hs = GameObject.FindObjectOfType<HeroStats>().GetComponent<HeroStats>();
            _vie = PlayerPrefs.GetInt("vie", 10) - force;
            PlayerPrefs.SetInt("vie", _vie);
            hs.SetGUIVals();
            _vie = PlayerPrefs.GetInt("vie", 10);
            if (_vie <= 0)
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(5);
            }
            canFight = false;
        }
        hfs.canFight = true;
    }
}
