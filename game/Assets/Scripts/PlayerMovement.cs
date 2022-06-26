using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed;

    bool isSpacePressed = false; 

    [SerializeField] private LayerMask jumpableGround;
    private bool isOnGround = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

        //jump only if player on ground
        if ((Input.GetKeyDown(KeyCode.Space) || isSpacePressed) && isOnGround)
        {
            isSpacePressed = true;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            transform.Rotate(0, 0, 90);
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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
