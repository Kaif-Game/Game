using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ЕБАТЬ ЧТО Я ТУТ ДЕЛАЮ

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed;

    //[SerializeField] private float deltaAngle = 0f;
    //private float angle = 0;
    //[SerializeField] private float roundDiff = 15f; 


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
        /*if (!isOnGround)
        {
            Debug.Log(Time.deltaTime);
            angle += deltaAngle * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            //transform.Rotate(Vector3.forward * deltaAngle);
        }
        */
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            rigidbody.velocity = Vector2.down;
        }
    }

    /*
    private void RoundAngle()
    {
        if(angle > -360 - roundDiff && angle < -roundDiff)
        {
            angle = 0;
        }
        else if (angle > -90 - roundDiff && angle < -90 + roundDiff)
        {
            angle = -90;
        }
        else if(angle > - 180 - roundDiff && angle < -180 + roundDiff)
        {
            angle = -180;
        }
        else if(angle > -270 - roundDiff && angle < -270 + roundDiff)
        {
            angle = -270;
        }
    }
    */

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
