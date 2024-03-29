using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanePortal : MonoBehaviour
{
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private GameObject player;

    private GameObject plane;
    public static bool isPlane = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!isPlane)
            {
                PlayerMovement.SetPlaneCondition(true);
                //create plane object
                plane = Instantiate(planePrefab);

                //set no rotation to plane and player
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                plane.transform.rotation = Quaternion.Euler(0, 0, 0);

                //set plane position to player and bind their transform
                plane.transform.position = new Vector2(collision.transform.position.x - 0.05f, collision.transform.position.y - 0.35f);
                plane.transform.SetParent(collision.transform);

                isPlane = true;
            }
            else
            {
                Destroy(plane);
                isPlane = false;
                PlayerMovement.SetPlaneCondition(false);
            }

        }
    }
}


