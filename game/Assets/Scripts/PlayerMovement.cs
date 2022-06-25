using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ЕБАТЬ ЧТО Я ТУТ ДЕЛАЮ

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed;

    [SerializeField] private float RotationInAir = 2f;

    private new BoxCollider2D collider;
    [SerializeField] private LayerMask jumpableGround;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);


        //jump only if player on ground
        bool isOnGround = IsOnGround();
        if (Input.GetKeyDown("space") && isOnGround)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce);
        }
        //rotation while floating
        if (!isOnGround)
        {
           transform.Rotate(0, 0, transform.rotation.z - RotationInAir);
        }
    }

    bool IsOnGround()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
