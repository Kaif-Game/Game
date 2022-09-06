using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinManager : MonoBehaviour
{
    public void ChangeCurrentSkin(int num)
    {
        PlayerLook.SetSkinSprite(num);
    }

    public void ChangeCurrentColor(string color)
    {
        Debug.Log(color);
        PlayerLook.SetSkinColor(color);
    }
}
