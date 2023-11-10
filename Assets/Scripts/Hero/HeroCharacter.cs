using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroCharacter : MonoBehaviour
{
    // Movement
    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator animator;
    Vector2 dir;
    private int dirValue = 0; // 0 = Idle, 1 = Down, 2 = Side, 3 = Up

    void Update()
    {
        HandleKey();
        HandleMove();
    }

    // Movement
    public void HandleKey()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // Fl�che du haut
        {
            dir = Vector2.up;
            dirValue = 3;
        }
        else if (Input.GetKey(KeyCode.RightArrow))  // Fl�che de Droite
        {
            dir = Vector2.right;
            dirValue = 2;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))  // Fl�che du Bas
        {
            dir = Vector2.down;
            dirValue = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))  // Fl�che de Gauche
        {
            dir = Vector2.left;
            dirValue = 2;
            sprite.flipX = false;
        }
        else  // Rien
        {
            dir = Vector2.zero;
            dirValue = 0;
        }
    }
    public void HandleMove()
    {
        rb.MovePosition(rb.position + dir * (moveSpeed * Time.deltaTime));
        animator.SetInteger("dir", dirValue);
    }
}
