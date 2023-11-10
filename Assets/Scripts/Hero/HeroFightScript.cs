using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HeroFightScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject hero;

    EnemyScript enemyScript;
    
    public bool canFight = true;
    public GameObject camFight;
    public GameObject baseEnemy;
    
    public AudioClip audioclip;

    private void Start()
    {
        enemyScript = enemy.GetComponent<EnemyScript>();
    }

    public void Atk1()
    {
        GetComponent<AudioSource>().PlayOneShot(audioclip);
        if (canFight)
        {
            iTween.MoveFrom(gameObject, enemy.transform.position, 1);
            enemyScript.vie -= PlayerPrefs.GetInt("force", 3);
            enemyScript.setLifePoint();
            if (enemyScript.vie <= 0)
            { 
                camFight.SetActive(false);
                baseEnemy.SetActive(false);
                enemy.SetActive(false);
                HeroStats hs = GameObject.FindObjectOfType<HeroStats>().GetComponent<HeroStats>();
                hs.xp += 20;
                hs.gold += 100;
                hs.LevelUp();
                hs.SetGUIVals();
            }
            canFight = false;
        }
        enemyScript.canFight = true;
        enemyScript.AtkHero();
    }
    
    public void Atk1Boss()
    {
        GetComponent<AudioSource>().PlayOneShot(audioclip);
        if (canFight)
        {
            iTween.MoveFrom(gameObject, enemy.transform.position, 1);
            enemyScript.vie -= PlayerPrefs.GetInt("force", 3);
            enemyScript.setLifePoint();
            if (enemyScript.vie <= 0)
            { 
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(4);
            }
            canFight = false;
        }
        enemyScript.canFight = true;
        enemyScript.AtkHero();
    }
}
