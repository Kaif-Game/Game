using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanePortal : MonoBehaviour
{
    [SerializeField] public GameObject plane;
    static private GameObject myPlane = null;
    private static bool isPlane = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name  == "Player")
        {
            if (!isPlane)
            {
                PlayerMovement.ChangePlaneCondion(true);
                myPlane = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Plane.prefab");
                myPlane.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y - 0.2f, 0);
                myPlane.transform.SetParent(collision.transform);
                myPlane.transform.rotation = Quaternion.Euler(0, 0, 0); ;
                isPlane = true;
            }
            else
            {
                Destroy(myPlane);
                isPlane = false;
                PlayerMovement.ChangePlaneCondion(false);
            }
            
        }
    }



}
