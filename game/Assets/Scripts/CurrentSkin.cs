using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSkin : MonoBehaviour
{
    private SpriteRenderer currSprite;
    void Start()
    {
        currSprite = GetComponent<SpriteRenderer>();
        currSprite.sprite = PlayerLook.GetCurrentSprite();
        currSprite.color = PlayerLook.GetCurrentColor();
    }

    private void Update()
    {
        currSprite.sprite = PlayerLook.sprite;
        currSprite.color =  PlayerLook.color;
    }
}
