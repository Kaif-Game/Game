using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    public Button[] levels;

    public void Select(int NumberInBuild)
    {
        SceneManager.LoadScene(NumberInBuild);
    }
}
