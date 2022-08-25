using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanePortal : MonoBehaviour
{
    [SerializeField] public GameObject planePrefab;

    private GameObject plane;
    //static private GameObject myPlane;
    private static bool isPlane = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name  == "Player")
        {
            if (!isPlane)
            {
                PlayerMovement.ChangePlaneCondition(true);
                plane = Instantiate(planePrefab); // = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Plane.prefab");
                plane.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y - 0.2f, 0);
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
