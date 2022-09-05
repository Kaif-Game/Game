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
    private static string spriteName = "icon_1";
    public static Color color = Color.white;
    private static string colorName = "red**";

    const string templateForSkinLogFile = "icon_1 red**";

    public static void SetSkinSprite(int num)
    {
        spriteName = $"icon_{num}";
        sprite = Resources.Load<Sprite>(spriteName);
        //log skin to file
        FileStream fstream = File.OpenWrite("skin_log.txt");
        if (fstream != null)
        {
            fstream.Write(Encoding.ASCII.GetBytes(spriteName + ' ' + colorName));
        }
        fstream.Close();
    }

    public static void SetSkinColor(string color_name)
    {
        //log color to file
        colorName = color_name;
        switch (color_name)
        {
            case "red**": color = Color.red; break;
            case "blue*": color = Color.blue; break;
            case "green": color = Color.green; break;
            case "cyan*": color = Color.cyan; break;
            case "yellw": color = Color.yellow; break;
            case "pink*": color = Color.magenta; break;
            default: color = Color.white; break;
        }
        FileStream fstream = File.OpenWrite("skin_log.txt");
        if (fstream != null)
        {
            fstream.Write(Encoding.ASCII.GetBytes(spriteName + ' ' + colorName));
        }
        fstream.Close();
    }

    public static Sprite GetCurrentSprite()
    {
        FileStream fstream = null;
        if (File.Exists("skin_log.txt"))
        {
            fstream = File.Open("skin_log.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        else
        {
            fstream = File.Create("skin_log.txt");
            byte[] data = new byte[20];
            data = Encoding.ASCII.GetBytes(templateForSkinLogFile);
            fstream.Write(data);
        }

        if (fstream != null)
        {
            byte[] buffer = new byte[20];
            fstream.Read(buffer, 0, buffer.Length);
            var info = Encoding.ASCII.GetString(buffer);
            try
            {
                sprite = Resources.Load<Sprite>(info.Split(' ')[0]);
                if (sprite == null) throw new NullReferenceException();
            }
            catch (Exception)
            {
                //rewrite log file 
                fstream.Write(Encoding.ASCII.GetBytes(templateForSkinLogFile));
            }
        }
        fstream.Close();
        return sprite;
    }

    public static Color GetCurrentColor()
    {
        FileStream fstream = null;
        if (File.Exists("skin_log.txt"))
        {
            fstream = File.Open("skin_log.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        else
        {
            fstream = File.Create("skin_log.txt");
            byte[] data = new byte[20];
            data = Encoding.ASCII.GetBytes(templateForSkinLogFile);
            fstream.Write(data);
        }

        if (fstream != null)
        {
            byte[] buffer = new byte[20];
            fstream.Read(buffer, 0, buffer.Length);
            try
            {
                colorName = Encoding.ASCII.GetString(buffer).Split()[1];
            } catch(Exception)
            {
                //clear and rewrite log file 
                fstream.Write(Encoding.ASCII.GetBytes(templateForSkinLogFile));
            }
        }
        fstream.Close();
        switch (colorName)
        {
            case "red**": return color = Color.red;
            case "blue*": return color = Color.blue;
            case "green": return color = Color.green;
            case "cyan*": return color = Color.cyan;
            case "yellw": return color = Color.yellow;
            case "pink*": return color = Color.magenta;
            default: return color = Color.white;
        }
    }
}
