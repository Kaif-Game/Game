using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] AudioSource soundtrack;
    [SerializeField] GameObject panel;
    private bool isPaused = false;

    void Start()
    {
        soundtrack.Play();
        panel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                PauseGame();
            } 
            else
            {
                ContinueGame();
            } 
        }    
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        panel.SetActive(true);
        soundtrack.Pause();
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        panel.SetActive(false);
        soundtrack.UnPause();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
