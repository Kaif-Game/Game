using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ЕБАТЬ ЧТО Я ТУТ ДЕЛАЮ

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float jumpForce = 7f;  

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }
}
