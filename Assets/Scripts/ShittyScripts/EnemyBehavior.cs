using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform[] pathPoints;
    public float speed;
    public SpriteRenderer sprite;
    private Vector2 dir;

    private void Start()
    {
        dir = Vector2.right;
    }

    private void Update()
    {
        transform.Translate(dir * (speed * Time.deltaTime));
        if (transform.position.x > pathPoints[1].position.x)
        {
            dir = Vector2.left;
            sprite.flipX = true;
        }
        if (transform.position.x < pathPoints[0].position.x)
        {
            dir = Vector2.right;
            sprite.flipX = false;
        }
    }
}
