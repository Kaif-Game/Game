using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class PlayerLook : MonoBehaviour
{
    public static Sprite sprite = null;

    public static void SetSkinSprite(int num)
    {
        var sprite_name = $"icon_{num}";
        sprite = Resources.Load<Sprite>(sprite_name);
        //log skin to file
        FileStream fstream = File.OpenWrite("skin_log.txt");
        if (fstream != null)
        {
            fstream.Write(Encoding.ASCII.GetBytes(sprite_name));
        }
        fstream.Close();
    }

    public static Sprite GetCurrentSprite()
    {
        FileStream fstream = null;
        if (File.Exists("skin_log.txt"))
        {
            fstream = File.OpenRead("skin_log.txt");
        }
        else
        {
            fstream = File.Create("skin_log.txt");
            byte[] data = new byte[20];
            data = Encoding.ASCII.GetBytes("icon_1");
            fstream.Write(data);
        }
        
        if (fstream != null)
        {
            Debug.Log("fstream is open");
            byte[] buffer = new byte[20];
            fstream.Read(buffer, 0, buffer.Length);
            sprite = Resources.Load<Sprite>(Encoding.ASCII.GetString(buffer));
        }
        else
        {
            Debug.Log("fstream is NOT open");
        }
        fstream.Close();
        return sprite;
    }
}
