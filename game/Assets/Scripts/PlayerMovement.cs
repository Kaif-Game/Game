using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed;

    bool isSpacePressed = false;
    //true if cube pass through portal
    private static bool isPlane = false;

    private bool isOnGround = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

        //jump only if player on ground
        if ((Input.GetKeyDown(KeyCode.Space) || isSpacePressed) && (isOnGround || isPlane))
        {
            isSpacePressed = true;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce / (1 + Convert.ToInt32(isPlane) * 1.1f));
            if (!isPlane)
            {
                transform.Rotate(0, 0, 90);
            } 
        }

        //for keeping space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacePressed = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            rigidbody.velocity = Vector2.down;
        }
        if (collision.gameObject.CompareTag("Jumper"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce * 2);
            isOnGround = false; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    static public void ChangePlaneCondition(bool condition)
    {
        isPlane = condition;
    }
}
