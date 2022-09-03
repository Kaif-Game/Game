using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource bg_music;

    void Start()
    {
        bg_music.Play();
    }

}
