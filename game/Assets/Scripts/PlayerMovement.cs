using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ЕБАТЬ ЧТО Я ТУТ ДЕЛАЮ

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed;

    private float rotationInAir = 0;
    [SerializeField] private float deltaAngle = 0f;
    private float angle = 0;


    [SerializeField] private LayerMask jumpableGround;
    private bool isOnGround = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

        //jump only if player on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

        //rotation in air
        //if (!isOnGround)
        //{
        //    Debug.Log(rotationInAir);
        //    angle -= deltaAngle;
        //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        //}
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
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
