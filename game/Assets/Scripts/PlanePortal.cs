using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanePortal : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private GameObject player;

    private GameObject plane;
    //static private GameObject myPlane;
    public static bool isPlane = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!isPlane)
            {
                PlayerMovement.ChangePlaneCondition(true);
                plane = Instantiate(planePrefab); 
                plane.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y - 0.2f);
                player.transform.rotation = Quaternion.identity;
                plane.transform.SetParent(collision.transform);
                plane.transform.rotation = Quaternion.Euler(0, 0, 0);
                isPlane = true;
            }
            else
            {
                Destroy(plane);
                isPlane = false;
                PlayerMovement.ChangePlaneCondition(false);
            }

        }
    }
}


