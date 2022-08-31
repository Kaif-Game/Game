using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] AudioSource soundtrack;
    [SerializeField] GameObject panel;
    private bool isPaused = false;

    private bool hasSound = true;
    [SerializeField] Button soundButton;
    //sprites of button
    [SerializeField] Sprite soundSprite;
    [SerializeField] Sprite not_soundSprite;

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
        isPaused = false;
        Time.timeScale = 1f;
        PlayerLife.ResetAttemptCount();
        SceneManager.LoadScene("Menu");
    }

    public void ChangeSound()
    {
        hasSound = !hasSound;
        soundtrack.volume = (hasSound ? 1f : 0f);
        soundButton.image.sprite = (hasSound ? soundSprite : not_soundSprite);
    }
}
