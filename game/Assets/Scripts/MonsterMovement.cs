using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    private float speed = 3f;
    private new Rigidbody2D rigidbody;
    [SerializeField] private float startPoint = -1.5f;
    [SerializeField] private float endPoint = 8f;
    private short upDown = 1;
    private bool flag = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (transform.position.y < endPoint && flag)
        {
            upDown = 1;
        }
        else if (transform.position.y > startPoint)
        {
            flag = false;
            upDown = -1;
        }
        else
        {
            flag = true;
        }
        rigidbody.velocity = new Vector2(0, speed * upDown);
    }
}