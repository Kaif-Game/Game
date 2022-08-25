using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    public Button[] levels;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(int NumberInBuild)
    {
        SceneManager.LoadScene(NumberInBuild);
    }
}
