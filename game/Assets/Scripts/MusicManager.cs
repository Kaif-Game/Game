using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource bg_music;
    private string tag = "BGMusic";

    void Awake()
    {
        var gameObject = GameObject.FindWithTag(tag);
        if (gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = tag;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level")
        {
            Destroy(this.gameObject);
        }
    }

}
