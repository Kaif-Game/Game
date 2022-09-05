using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement2 : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private new Rigidbody2D rigidbody;
    [SerializeField] private float startPoint = 0f;
    [SerializeField] private float endPoint = 0f;
    private short rightLeft = 1;
    private bool flag = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (transform.position.x < endPoint && flag)
        {
            rightLeft = 1;
        }
        else if (transform.position.x > startPoint)
        {
            flag = false;
            rightLeft = -1;
        }
        else
        {
            flag = true;
        }
        rigidbody.velocity = new Vector2(speed * rightLeft, 0);
    }
}
