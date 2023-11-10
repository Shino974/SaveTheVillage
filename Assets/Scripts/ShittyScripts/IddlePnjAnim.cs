using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddlePnjAnim : MonoBehaviour
{
    public Vector3 amount;
    public float time;

    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
            "x", amount.x,
            "y", amount.y,
            "z", amount.z,
            "time", time,
            "looptype", iTween.LoopType.pingPong
        ));
    }
}
