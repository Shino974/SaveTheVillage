using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseFight : MonoBehaviour
{
    public GameObject mob; 
    EnemyScript es;
    public HeroFightScript hfs;
    
    public void InitFight()
    {
        mob.SetActive(true);
        es = mob.GetComponent<EnemyScript>();
        es.vie = 3;
        hfs.canFight = true;
        es.setLifePoint();
    }
    
    public void InitFightBoss()
    {
        mob.SetActive(true);
        es = mob.GetComponent<EnemyScript>();
        es.vie = 50;
        hfs.canFight = true;
        es.setLifePoint();
    }
}
