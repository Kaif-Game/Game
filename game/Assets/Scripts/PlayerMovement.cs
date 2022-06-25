using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ЕБАТЬ ЧТО Я ТУТ ДЕЛАЮ

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        if (Input.GetKeyDown("space"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
        if (Input.GetKeyDown("left"))
        {
            rigidbody.velocity = new Vector2(-2, rigidbody.velocity.y);
        }
        if (Input.GetKeyDown("right"))
        {
            rigidbody.velocity = new Vector2(2, rigidbody.velocity.y);
        }
    }
}
