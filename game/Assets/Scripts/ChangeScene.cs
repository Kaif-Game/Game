using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    public Button[] levels;

    public void Select(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
